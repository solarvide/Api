using AutoMapper;
using Domain;
using Context.Repo;
using GoogleAuthentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Util;
using Util.Security;
using System.Linq;
using App.Configurations;
using App.Dto.Autenticator;
using App.Dto.Default;
using App.DtoUsers;
using App;

namespace ZionSystemApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly ContextApp _context;
        private readonly IMapper _mapper;
        private readonly SettingsApp _settingsApp;

        public UserController(ContextApp context, IMapper mapper, SettingsApp settings)
        {
            _context = context;
            _mapper = mapper;
            _settingsApp = settings;
        }

        private async Task SendVerifyEmail(User oUser, string code)
        {
            string subject = Translator.Transl("mail_verify_subject", "Verify Your Email", Request);
            string title = Translator.Transl("mail_verify_title", "Use the code to verify your email", Request);
            string message = Translator.Transl("mail_verify_message", "To ensure the integrity of our platform's user base, we need you to confirm that you own this email account.<br/><br/>For this you can use the code below to validate the authenticity of your account.<br/><br/>Code to verify your email:<br/><strong>{0}</strong>", Request);

            message = string.Format(message, code);

            ProjectMailSender.Send(oUser.Email, subject, title, message, oUser.Name, Request);
        }

        private async Task SendRecoverPassEmail(User oUser, string code)
        {
            string subject = Translator.Transl("mail_user_recovery_subject", "Password recovery", Request);
            string title = Translator.Transl("mail_user_recovery_title", "Password recovery procedure", Request);
            string message = Translator.Transl("mail_user_recovery_message", "You received this message because you requested to recover your password.<br/></br>This is your new temporary password</br><br/><br/><strong>{0}</strong>", code);

            message = string.Format(message, code);

            ProjectMailSender.Send(oUser.Email, subject, title, message, oUser.Name, Request);
        }


        protected bool EmailDisponibleCheck(UserEmailDisponibleRequestDto request)
        {
            try
            {

                if (request.TargetEmail == request.CurrentEmail) return true;
                User oDonoDoEmail = _context.Users.Where(o => !o.Deleted && o.Email == request.TargetEmail).FirstOrDefault();

                if (oDonoDoEmail == null) return true;

                if (oDonoDoEmail.Email == request.CurrentEmail) return true;

                else return false;

            }
            catch (ExceptionControlled e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        private async Task SendLoginEmail(User oUser, SignInRequestDto request)
        {
            string subject = Translator.Transl("mail_user_login_subject", "New login detected - {0}", Request);
            string title = Translator.Transl("mail_user_login_title", "Login made to your account", Request);
            string message = Translator.Transl("mail_user_login_message", "We detected a new login attempt on {0} using your <strong>{1}</strong> account. If this action has not been taken by you, please contact support and change your password as soon as possible.<br/><br/>Date:<br/><strong>{2}</strong><br/><br/>Public IP:<br/><strong>{3}</strong>", Request);

            subject = string.Format(subject, request.PublicIp);
            message = string.Format(message, Tools.GetAppSetting("projectName"), oUser.Email, DateTime.Now.ToString("yyyy-MM-dd HH:mm tt"), request.PublicIp);

            ProjectMailSender.Send(oUser.Email, subject, title, message, oUser.Name, Request);
        }

        private async Task SendVerifiedCodeEmail(User oUser)
        {
            string subject = Translator.Transl("mail_verifiedcode_subject", "Your email has been verified", Request);
            string title = Translator.Transl("mail_verifiedcoed_title", "Your email has been verified", Request);
            string message = Translator.Transl("mail_verifiedcode_message", "Your e-mail {0}.com has been successfully verified.<br><br/>You can continue using the platform's services as usual.", Request);

            message = string.Format(message, "<strong>" + oUser.Email + "</strong>");

            ProjectMailSender.Send(oUser.Email, subject, title, message, oUser.Name, Request);
        }



        [HttpGet("{userId}")]
        public async Task<ActionResult<UserDefaultResponseDto>> GetUser(long userId)
        {
            try
            {
                var user = _context.Users
                    .Include(o => o.UserType)
                    .Include(o => o.Company)
                    .Where(o => o.Id == userId)
                    .FirstOrDefault();

                if (user == null)
                {
                    throw new ExceptionControlled("Usuario não encontrado pelo userId enviado", false, false);
                }
                var userMapped = _mapper.Map<User, UserDefaultResponseDto>(user);

                return Ok(new { BaseUrlimage = _settingsApp.AwsS3.BaseUrlS3, Data = userMapped });
            }
            catch (ExceptionControlled ex)
            {
                return BadRequest(ex.ResponseToJson());
            }
            catch (Exception ex)
            {

                return BadRequest(ExceptionControlled.ResponseToJson(ex));
            }

        }


        [HttpGet("List/")]
        public ActionResult<List<UserDefaultResponseDto>> ListUser(DefaultRequestDto request)
        {
            try
            {
                // pagination
                request.QtyByPage = request.QtyByPage == 0 ? 99 : request.QtyByPage;
                request.Page = request.Page == 0 ? 1 : request.Page;
                request.Skip = (request.Page - 1) * request.QtyByPage;

                var query = _context.Users
                    .Include(o => o.UserType)
                    .Where(o => !o.Deleted && (string.IsNullOrEmpty(request.Filter) || (o.Name.Contains(request.Filter) || o.SurName.Contains(request.Filter) || o.Email.Contains(request.Filter))))
                    .OrderBy(o => o.Name);

                int totalList = query.Count();
                var result = query.Skip(request.Skip).Take(request.QtyByPage).ToList();
                double totalPage = Math.Ceiling(totalList / (double)request.QtyByPage);

                // response
                var usersMapped = _mapper.Map<IEnumerable<User>, IEnumerable<UserDefaultResponseDto>>(result);

                return Ok(new { TotalRegister = totalList, TotalPage = totalPage, BaseUrlimage = _settingsApp.AwsS3.BaseUrlS3, Data = usersMapped });
            }
            catch (ExceptionControlled ex)
            {
                return BadRequest(ex.ResponseToJson());
            }
            catch (Exception ex)
            {

                return BadRequest(ExceptionControlled.ResponseToJson(ex));
            }

        }



        [HttpPut("{userId}")]
        public async Task<ActionResult> UpdateUser(long userId, UserUpdateDefaultRequestDto request)
        {
            try
            {
                var user = _context.Users.Where(o => o.Id == userId).FirstOrDefault();

                if (user == null)
                {
                    throw new ExceptionControlled("Falha ao atualizar o usuário mencionado", false, false);
                }

                if (request.RemovePhoto == true)
                {
                    Tools.S3DeleteItem(_settingsApp.AwsS3.KeyS3, _settingsApp.AwsS3.SecretKeyS3, _settingsApp.AwsS3.BucketName, user.PhotoUrl);
                    user.PhotoUrl = null;
                }

                if (request.PhotoUrl != null)
                {
                    Tools.S3DeleteItem(_settingsApp.AwsS3.KeyS3, _settingsApp.AwsS3.SecretKeyS3, _settingsApp.AwsS3.BucketName, user.PhotoUrl);
                    user.PhotoUrl = await Tools.UploadFileToS3(_settingsApp.AwsS3.KeyS3, _settingsApp.AwsS3.SecretKeyS3, _settingsApp.AwsS3.BucketName, request.PhotoUrl, true, Convert.ToInt32(ConfigTag.GetValue("default_percent_compress")));

                }

                if (request.Name != null) user.Name = request.Name;

                if (request.SurName != null) user.SurName = request.SurName;

                if (request.DocNumber != null) user.DocNumber = request.DocNumber;

                if (request.Birthday != null) user.Birthday = request.Birthday;

                if (request.Phone != null) user.Phone = request.Phone;

                if (request.Email != null) user.Email = request.Email;

                if (request.UserTypeId != null) user.UserTypeId = request.UserTypeId.Value;


                _context.Update(user);
                _context.SaveChanges();
                return Ok(true);

            }
            catch (ExceptionControlled ex)
            {
                return BadRequest(ex.ResponseToJson());
            }
            catch (Exception ex)
            {
                return BadRequest(ExceptionControlled.ResponseToJson(ex));
            }

        }


        [AllowAnonymous]
        [HttpPost("SignUp")]
        public async Task<ActionResult<UserSessionResponseDto>> SignUp([FromBody] UserSignUpRequestDto request, [FromServices] SigningConfigurations signingConfigurations, [FromServices] TokenConfigurations tokenConfigurations)
        {
            try
            {

                bool emailDisponivel = EmailDisponibleCheck(new UserEmailDisponibleRequestDto
                {
                    TargetEmail = request.Email,
                });
                var document = request.DocNumber.Replace(".", "").Replace("-", "");

                request.Phone = request.Phone.Replace("(", "").Replace(")", "").Replace("-", "");

                var checkDocnumber = _context.Users.Where(o => o.DocNumber == document).FirstOrDefault();

                if (checkDocnumber != null)
                {
                    string msg1 = Translator.Transl("docnumber_check_msg", "The document number entered is already in use.", Request);
                    string msg2 = Translator.Transl("docnumber_check_title", "Document number unavailable", Request);

                    throw new ExceptionControlled(msg1, msg2);
                }

                if (!emailDisponivel)
                {
                    string msg1 = Translator.Transl("mail_signup_email_error_msg", "The email entered is already in use.", Request);
                    string msg2 = Translator.Transl("mail_signup_email_error_title", "Email unavailable", Request);

                    throw new ExceptionControlled(msg1, msg2);
                }

                if (request.PhotoUrl != null)
                {
                    var imgUrl = await Tools.UploadFileToS3(_settingsApp.AwsS3.KeyS3, _settingsApp.AwsS3.SecretKeyS3, _settingsApp.AwsS3.BucketName, request.PhotoUrl, true, Convert.ToInt32(ConfigTag.GetValue("default_percent_compress")));
                    request.PhotoUrl = imgUrl;
                }
                //TODO: CRIAR ROTINA PARA CRIAÇÃO DE CODIGO ESPERIMENTAL
                var recomendationCode = Tools.RandomString(8);

                var oUser = _mapper.Map<UserSignUpRequestDto, User>(request);
                oUser.PinCode = Guid.NewGuid().GetHashCode().ToString();


                if (!string.IsNullOrWhiteSpace(request.PushNotificationKey))
                {
                    oUser.PushNotificationKeys.Add(new PushNotificationKey
                    {
                        PushKey = request.PushNotificationKey,
                        PublicIP = request.PublicIp,
                        CreatedOn = DateTime.Now,
                        Deleted = false,

                    });
                }

                string code = new Random().Next(10000, 90999).ToString();

                oUser.CodeValidations.Add(new CodeValidation()
                {
                    CreatedOn = DateTime.Now,
                    ExpirationDate = DateTime.Now.AddDays(1),
                    ValidationCode = code,
                    CodeType = "SingUp"
                });
                _context.Users.Add(oUser);

                await _context.SaveChangesAsync();

                await SendVerifyEmail(oUser, code);

                //Response
                var resultMapped = new ContainedResponseUserDto()
                {
                    User = _mapper.Map<User, UserDefaultResponseDto>(oUser),
                    UserTypeId = ConfigTag.GetValue("default_user_type_abreviations"),
                    Token = Tools.TokenGenerate(oUser, oUser.Id, signingConfigurations, tokenConfigurations)
                };

                return Ok(resultMapped);

            }
            catch (ExceptionControlled e)
            {
                return BadRequest(e.ResponseToJson());
            }
            catch (Exception e)
            {
                return BadRequest(ExceptionControlled.ResponseToJson(e));
            }
        }

        [AllowAnonymous]
        [HttpPost("SignIn")]

        public ActionResult<ContainedResponseUserDto> SignIn([FromBody] SignInRequestDto request, [FromServices] SigningConfigurations signingConfigurations, [FromServices] TokenConfigurations tokenConfigurations)
        {
            try
            {
                string senhaCritografada = Tools.MD5Hash(request.Password.Trim());
                var oUser = _context.Users
                   .Include(o => o.UserType)
                   .Include(o => o.PushNotificationKeys)
                   .Where(o => !o.Deleted && o.Email.Trim() == request.Email.Trim() && o.Password == senhaCritografada).FirstOrDefault();

                var msg1 = Translator.Transl("user_signin_email_error_msg", "Your email or password do not match. Make sure you typed it correctly.", Request);
                var msg2 = Translator.Transl("user_signin_email_error_title", "Invalid credencials", Request);
                if (oUser is null) throw new ExceptionControlled(msg1, msg2);

                //Registrar Push Notification Token se enviado
                if (!String.IsNullOrWhiteSpace(request.PushNotificationToken))
                {
                    bool tokenExists = oUser.PushNotificationKeys.Any(o => o.PushKey == request.PushNotificationToken);

                    if (!tokenExists)
                    {
                        oUser.PushNotificationKeys.Add(new PushNotificationKey()
                        {
                            CreatedOn = DateTime.Now,
                            Deleted = false,
                            PublicIP = request.PublicIp,
                            PushKey = request.PushNotificationToken
                        });
                    }
                }
                _context.SaveChanges();

                HttpContext.Session.SetString("uID", Convert.ToString(oUser.Id));

                SendLoginEmail(oUser, request);


                var resultMapped = new ContainedResponseUserDto()
                {
                    User = _mapper.Map<User, UserDefaultResponseDto>(oUser),
                    UserTypeId = oUser.UserType.Abbreviation,
                    Token = Tools.TokenGenerate(oUser, oUser.Id, signingConfigurations, tokenConfigurations)
                };

                return Ok(resultMapped);
            }
            catch (ExceptionControlled e)
            {
                return BadRequest(e.ResponseToJson());
            }
            catch (Exception e)
            {
                return BadRequest(ExceptionControlled.ResponseToJson(e));
            }
        }

        // <summary>
        // Muda a senha do usuário informando a atual e a antiga
        //</summary>
        //<param name = "request" > Id: Id do usuário(Não é id da startup, investidor). | As senhas são enviadas sem criptografia</param>
        // <returns></returns>

        [HttpPost("changePassword")]
        public async Task<IActionResult> ChangePassword(UserChangePasswordRequestDto request)
        {
            try
            {
                var userId = Tools.TokenGetId(Request);

                var authorizedException = Tools.TokenSessionCheck(Request, HttpContext, userId);
                if (authorizedException != null) return Unauthorized(authorizedException.ResponseToJson());

                string senhaAtualCriptografada = Tools.MD5Hash(request.CurrentPassword);

                User oUsuario = _context.Users.Where(o => !o.Deleted && o.Id == userId).FirstOrDefault();

                if (oUsuario.Password != senhaAtualCriptografada)
                {
                    string msg1 = Translator.Transl("changepassword_wrong_msg", "The current password you entered is incorrect.", Request);
                    string msg2 = Translator.Transl("changepassword_wrong_title", "Invalid current password", Request);
                    throw new ExceptionControlled(msg1, msg2);
                }

                oUsuario.Password = Tools.MD5Hash(request.NewPassword);
                oUsuario.UpdatedOn = DateTime.Now;

                _context.Entry(oUsuario).State = EntityState.Modified;

                await _context.SaveChangesAsync();

                return Ok("Password Change");
            }
            catch (ExceptionControlled e)
            {
                return BadRequest(e.ResponseToJson());
            }
            catch (Exception e)
            {
                return BadRequest(ExceptionControlled.ResponseToJson(e));
            }
        }

        /// <summary>
        /// Envia um e-mail de verificação
        /// Obtém o id do usuário através do token de autenticação
        /// </summary>
        /// <returns></returns>
        [HttpPost("sendVerifyMailCodeAgain")]
        public async Task<ActionResult<bool>> SendVerifyMailCodeAgain()
        {
            try
            {
                var userId = Tools.TokenGetId(Request);

                User oUsuario = _context.Users.Where(o => !o.Deleted && o.Id == userId).FirstOrDefault();

                if (oUsuario == null)
                {
                    throw new ExceptionControlled("User Not Found", false, false);
                }

                if (oUsuario.EmailValidated == true)
                {
                    throw new ExceptionControlled("The email has already been verified ", false, true);
                }
                else
                {

                    string code = new Random().Next(10000, 99999).ToString();

                    oUsuario.CodeValidations.Add(new CodeValidation()
                    {
                        ValidationCode = code,
                        ExpirationDate = DateTime.Now.AddDays(1),
                        CodeType = "VerificadeAgain"

                    });
                    oUsuario.UpdatedOn = DateTime.Now;
                    _context.SaveChanges();

                    SendVerifyEmail(oUsuario, code);
                }

                return Ok(true);
            }
            catch (ExceptionControlled e)
            {
                return BadRequest(e.ResponseToJson());
            }
            catch (Exception e)
            {
                return BadRequest(ExceptionControlled.ResponseToJson(e));
            }
        }



        /// <summary>
        /// Verifica se o e-mail do usuário com om código de verificação
        /// </summary>
        /// <param name="email">Email do usuário</param>
        /// <param name="code">Codigo para validação</param>
        /// <returns>True or Exception</returns>
        [HttpGet("verifyMailCode/{email}/{code}")]
        public async Task<ActionResult<bool>> VerifyMailCode(string email, string code)
        {
            try
            {
                var userId = Tools.TokenGetId(Request);

                User oUsuario = _context.Users.Include(o => o.CodeValidations).Where(o => !o.Deleted && o.Id == userId).FirstOrDefault();

                int validationCode = DateTime.Compare(oUsuario.CodeValidations.LastOrDefault().ExpirationDate, DateTime.Now);

                if (oUsuario.CodeValidations.LastOrDefault().ValidationCode != code)
                { //TODO: Verificar Email Code
                    string msg1 = Translator.Transl("emailverify_wrongcode_msg", "For some reason the code could not be confirmed. Please make sure you typed it correctly and try again.", Request);
                    string msg2 = Translator.Transl("emailverify_wrongcpde_title", "Code does not match validation", Request);

                    throw new ExceptionControlled(msg1, msg2);
                }
                else if (validationCode <= 0)
                {
                    string msg1 = Translator.Transl("emailverify_wrongcode_msg", "For some reason the code could not be confirmed. Please make sure you typed it correctly and try again.", Request);
                    string msg2 = Translator.Transl("emailverify_wrongcpde_title", "Code does not match validation", Request);

                    throw new ExceptionControlled(msg1, msg2);

                }
                else if (oUsuario.Email != email)
                {
                    string msg1 = Translator.Transl("emailverify_wrongmail_msg", "The email is not the same as the email you entered, or an error occurred. Please check your email and try again.", Request);
                    string msg2 = Translator.Transl("emailverify_wrongmail_title", "Email does not match validation", Request);

                    throw new ExceptionControlled(msg1, msg2);
                }

                oUsuario.EmailValidated = true;

                oUsuario.UpdatedOn = DateTime.Now;

                _context.Entry(oUsuario).State = EntityState.Modified;
                _context.Remove(oUsuario.CodeValidations.LastOrDefault());

                SendVerifiedCodeEmail(oUsuario);

                await _context.SaveChangesAsync();

                return Ok(true);
            }
            catch (ExceptionControlled e)
            {
                return BadRequest(e.ResponseToJson());
            }
            catch (Exception e)
            {
                return BadRequest(ExceptionControlled.ResponseToJson(e));
            }
        }

        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Envia um e-mail para o usuário com uma senha temporária
        /// </summary>
        /// <param name="email">email do usuário</param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet("recoverPassword/{email}")]
        public async Task<IActionResult> RecoverPassword(string email, long clubId)
        {
            try
            {
                User oUser = _context.Users.Where(o => o.Email.Trim() == email.Trim()).FirstOrDefault();

                if (oUser == null)
                {
                    string msg1 = Translator.Transl("recoverpassword_notfound_msg", "This email is probably not registered yet.", Request);
                    string msg2 = Translator.Transl("recoverpassword_notfound_title", "User not found", Request);

                    throw new ExceptionControlled(msg2, msg1);
                }

                string code = new Random().Next(10000000, 90999999).ToString();

                oUser.Password = Tools.MD5Hash(code);
                _context.Update(oUser);

                oUser.CodeValidations.Add(new CodeValidation()
                {
                    CreatedOn = DateTime.Now,
                    ExpirationDate = DateTime.Now.AddDays(1),
                    ValidationCode = code,
                    CodeType = "Recovery"
                });

                SendRecoverPassEmail(oUser, code);
                await _context.SaveChangesAsync();

                return Ok(true);
            }
            catch (ExceptionControlled e)
            {
                return BadRequest(e.ResponseToJson());
            }
            catch (Exception e)
            {
                return BadRequest(ExceptionControlled.ResponseToJson(e));
            }
        }

        [AllowAnonymous]
        [HttpPost("recoverPassword/ChangePassword")]
        public async Task<IActionResult> ChangePasswordRecovery(UserRecoveryChangePasswordRequestDto request)
        {
            try
            {
                User oUser = _context.Users.Include(o => o.CodeValidations).Where(o => !o.Deleted && o.CodeValidations.Any(x => x.ValidationCode == request.Code)).FirstOrDefault();

                if (oUser == null)
                {
                    string msg1 = Translator.Transl("recoverpassword_notfound_msg", "This code not valid.", Request);
                    string msg2 = Translator.Transl("recoverpassword_notfound_title", "User not found", Request);
                    throw new ExceptionControlled(msg1, msg2);
                }

                int validationCode = DateTime.Compare(oUser.CodeValidations.LastOrDefault().ExpirationDate, DateTime.Now);
                if (validationCode <= 0)
                {
                    string msg1 = Translator.Transl("emailverify_wrongcode_msg", "For some reason the code could not be confirmed. Please make sure you typed it correctly and try again.", Request);
                    string msg2 = Translator.Transl("emailverify_wrongcpde_title", "Code does not match validation", Request);

                    throw new ExceptionControlled(msg1, msg2);

                }

                oUser.Password = Tools.MD5Hash(request.NewPassword);

                oUser.UpdatedOn = DateTime.Now;

                _context.Entry(oUser).State = EntityState.Modified;



                _context.Remove(oUser.CodeValidations.FirstOrDefault());

                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (ExceptionControlled e)
            {
                return BadRequest(e.ResponseToJson());
            }
            catch (Exception e)
            {
                return BadRequest(ExceptionControlled.ResponseToJson(e));
            }
        }


        [HttpDelete("{userId}")]
        public async Task<ActionResult> Delete(long userId)
        {
            try
            {
                var user = _context.Users.Where(o => o.Id == userId).FirstOrDefault();

                if (user == null)
                    throw new ExceptionControlled("User not found", false, false);

                user.Deleted = true;

                _context.Update(user);
                _context.SaveChanges();

                return Ok();

            }
            catch (ExceptionControlled ex)
            {
                return BadRequest(ex.ResponseToJson());
            }
            catch (Exception ex)
            {

                return BadRequest(ExceptionControlled.ResponseToJson(ex));
            }

        }

        [HttpPost("EnableGoogleAuthenticator/")]
        public async Task<ActionResult> GoogleAuthenticator()
        {
            try
            {

                var userId = Tools.TokenGetId(Request);

                var oUser = _context.Users.Where(o => !o.Deleted && o.Id == userId).FirstOrDefault();

                var HashKey = Guid.NewGuid().ToString();

                GAuthenticator gauth = new GAuthenticator();

                gauth.QRCodeSize = 200;

                gauth.Identity = oUser.Name + " " + oUser.SurName;

                gauth.Issuer = "SolarVide Authenticator";

                gauth.setSecretKey(HashKey);

                var ImageUrl = "data:image/png;base64,"+gauth.QRCodeUrl;

                oUser.TwoFactory = true;

                oUser.TwoFactorySecret = HashKey;

                _context.Update(oUser);
                _context.SaveChanges();
                return Ok(ImageUrl);


            }
            catch (ExceptionControlled ex)
            {
                return BadRequest(ex.ResponseToJson());
            }
            catch (Exception ex)
            {

                return BadRequest(ExceptionControlled.ResponseToJson(ex));
            }
        }


        [HttpPost("ValidateTwoFac")]

        public async Task<ActionResult> ValidataTwoFact(AuthenticatorCodeGoogle request)
        {
            try
            {
                var userId = Tools.TokenGetId(Request);

                var oUser = _context.Users.Where(o => !o.Deleted && o.Id == userId).FirstOrDefault();

                string identity = oUser.Name + " " + oUser.SurName;

                byte[] secretByte = new System.Text.ASCIIEncoding().GetBytes(oUser.TwoFactorySecret);

                GAuthenticator gauth = new GAuthenticator();
                gauth.Secret = secretByte;
                gauth.Identity = identity;

                int code;
                int.TryParse(request.Code, out code);

                if (gauth.OneTimePassword == code)
                {
                    return Ok(true);
                }
                else
                {
                    return Ok(false);
                }
            }
            catch (ExceptionControlled ex)
            {
                return BadRequest(ex.ResponseToJson());
            }
            catch (Exception ex)
            {

                return BadRequest(ExceptionControlled.ResponseToJson(ex));
            }
        }
    }
}

