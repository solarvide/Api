using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Mail;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Util.Security;
using EncryptStringSample;
using Microsoft.Extensions.Primitives;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using Util.Email;
using Microsoft.AspNetCore.Http;
using RestSharp;
using Amazon.S3;
using Amazon.S3.Transfer;
using Amazon;
using Amazon.S3.Model;
using Newtonsoft.Json.Linq;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using Xabe.FFmpeg;
using System.Security.Cryptography.X509Certificates;

namespace Util
{

    public class Tools
    {
        public class UserData
        {
            public int uID { get; set; }
            public string Username { get; set; }
            public string Name { get; set; }
            public int Type { get; set; }
            public int Company { get; set; }
        }
        static Configuration _configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        public static string GetAppSetting(string key)
        {
            KeyValueConfigurationElement element = _configuration.AppSettings.Settings[key];
            if (element != null)
            {
                string value = element.Value;
                if (!string.IsNullOrEmpty(value))
                    return value;
            }
            return string.Empty;
        }

        public static Task SendEmailAsync(string emailTo, string subject, string message, string title, string hello, string userFirstName, string team, string rodapePreMail, string socialMedia, string accessWebSite)
        {
            try
            {
                //EmailTools.SendEmailExecute(emailTo, subject, message, title, hello, userFirstName, team, rodapePreMail, socialMedia, accessWebSite).Wait();
                EmailTools.SendEmailExecute(emailTo, subject, message, title, hello, userFirstName, team, rodapePreMail, socialMedia, accessWebSite);
                return Task.FromResult(0);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static async Task<string> Notification(string title, string mensage, string pushKey)
        {
            try
            {
                RestClient restClient = new RestClient("https://exp.host");
                JObject jobject = new JObject();

                jobject.Add("to", pushKey);
                jobject.Add("sound", "default");
                jobject.Add("title", title);
                jobject.Add("body", mensage);

                RestRequest restRequest = new RestRequest("/--/api/v2/push/send", Method.POST);
                restRequest.AddParameter("Accept", ParameterType.RequestBody);
                restRequest.AddParameter("Accept-encoding", ParameterType.RequestBody);
                restRequest.AddParameter("Content-Type", ParameterType.RequestBody);
                restRequest.AddParameter("application/json", jobject, ParameterType.RequestBody);

                IRestResponse restResponse = restClient.Execute(restRequest);

            }
            catch (Exception ex)
            {
                return "erro";
            }

            return "";
        }

        public static string GerarSenhaAleatoria(int size = 7)
        {
            string chars = "ABCDEFGHJKLMNPRSTUVWXYZ23456789";
            string pass = "";
            Random random = new Random();
            for (int f = 0; f < size; f++)
            {
                pass = pass + chars.Substring(random.Next(0, chars.Length - 1), 1);
            }

            return pass;
        }

        public static string MD5Hash(string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            //compute hash from the bytes of text  
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));

            //get hash result after compute it  
            byte[] result = md5.Hash;

            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                //change it into 2 hexadecimal digits  
                //for each byte  
                strBuilder.Append(result[i].ToString("x2"));
            }

            return strBuilder.ToString();
        }

        public static decimal CalcularVariacaoPercentual(decimal ultimoValor, decimal primeiroValor)
        {
            if (ultimoValor >= primeiroValor)
            {
                return (ultimoValor - primeiroValor) / primeiroValor * 100;
            }
            else
            {
                return -((primeiroValor - ultimoValor) / primeiroValor * 100);
            }
        }

        public static string NumeroParaSiglaMes(int Numero, bool nomeCompleto = false)
        {
            switch (Numero)
            {
                case 1:
                    return nomeCompleto ? "Janeiro" : "JAN";
                case 2:
                    return nomeCompleto ? "Fevereiro" : "FEV";
                case 3:
                    return nomeCompleto ? "Março" : "MAR";
                case 4:
                    return nomeCompleto ? "Abril" : "ABR";
                case 5:
                    return nomeCompleto ? "Maio" : "MAI";
                case 6:
                    return nomeCompleto ? "Junho" : "JUN";
                case 7:
                    return nomeCompleto ? "Julho" : "JUL";
                case 8:
                    return nomeCompleto ? "Agosto" : "AGO";
                case 9:
                    return nomeCompleto ? "Setembro" : "SET";
                case 10:
                    return nomeCompleto ? "Outubro" : "OUT";
                case 11:
                    return nomeCompleto ? "Novembro" : "NOV";
                case 12:
                    return nomeCompleto ? "Sezembro" : "DEZ";
                default:
                    return "";
            }
        }

        public static object Encrypt(string param)
        {
            throw new NotImplementedException();
        }

        public static TokenBuilded TokenGenerate(object objectUser, long id, long company, SigningConfigurations signingConfigurations, TokenConfigurations tokenConfigurations)
        {

            var tokenUserDto = new TokenObjDto
            {
                Username = GetPropertyValue(objectUser, "Email").ToString(),
                Name = GetPropertyValue(objectUser, "Name").ToString(),
                Type = Convert.ToInt64(GetPropertyValue(objectUser, "UserTypeId")),
                uID = id,
                Company = company
            };

            ClaimsIdentity identity = new ClaimsIdentity(
                        new GenericIdentity(id.ToString(), "Id"),
                        new[] {
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                            new Claim("User", JsonConvert.SerializeObject(tokenUserDto))
                            //new Claim(ClaimTypes.Name, GetPropertyValue(objectUser, "Name").ToString()),
                            //new Claim(ClaimTypes.Email, GetPropertyValue(objectUser, "Email").ToString()),

                        }
                    );

            DateTime dataCriacao = DateTime.Now;
            DateTime dataExpiracao = dataCriacao + TimeSpan.FromSeconds(tokenConfigurations.Seconds);

            var handler = new JwtSecurityTokenHandler();
            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = tokenConfigurations.Issuer,
                Audience = tokenConfigurations.Audience,
                SigningCredentials = signingConfigurations.SigningCredentials,
                Subject = identity,
                NotBefore = dataCriacao,
                Expires = dataExpiracao
            });
            var token = handler.WriteToken(securityToken);

            return new TokenBuilded
            {
                authenticated = true,
                created = dataCriacao.ToString("yyyy-MM-dd HH:mm:ss"),
                expiration = dataExpiracao.ToString("yyyy-MM-dd HH:mm:ss"),
                accessToken = token
            };
        }

        public static ExceptionControlled TokenSessionCheck(HttpRequest request, HttpContext httpContext, long? userId = null)
        {
            var stream = request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(stream);
            var tokenS = jsonToken as JwtSecurityToken;

            string sessionUserId = httpContext.Session.GetString("uID");

            //if (tokenS.Payload["unique_name"].ToString() != sessionUserId)
            //{
            //    return new ExceptionControlled("SERVER_SESSION_EXPIRATED", false, false);
            //}

            if (userId.HasValue ? tokenS.Payload["unique_name"].ToString() != userId.ToString() : false)
            {
                return new ExceptionControlled("SERVER_SESSION_EXPIRATED", false, false);
            }

            return null;

        }

        public static long TokenGetId(HttpRequest request)
        {
            var stream = request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(stream);
            var tokenS = jsonToken as JwtSecurityToken;

            return Convert.ToInt64(tokenS.Payload["unique_name"]);

        }

        public static UserData TokenGetUser(HttpRequest request)
        {
            var stream = request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(stream) as JwtSecurityToken;
            var user = jsonToken?.Payload["User"]?.ToString();
            var Data = new UserData();
            Data = JsonConvert.DeserializeObject<UserData>(user);
            return Data;
        }

        public static decimal CalcularPercentualComparativo(decimal total, decimal comparativo)
        {
            return comparativo / total * 100;
        }

        public static string CompleteLeftZeros(string number, int qtdTotalZeros)
        {
            int zerosToAdd = qtdTotalZeros - number.Length;

            for (int i = 0; i < zerosToAdd; i++)
            {
                number = "0" + number;
            }

            return number;
        }

        public static string CompleteRightZeros(int qtdTotalZeros, string number = "")
        {
            int zerosToAdd = qtdTotalZeros - number.Length;

            if (zerosToAdd <= 0) return number;

            for (int i = 0; i < zerosToAdd; i++)
            {
                number = number + "0";
            }

            return number;
        }

        public static long ConvDecimalToLong(decimal number, int decimalSize)
        {
            var n = number.ToString();//.Replace(".","").Replace(",","");
            string[] sArray;

            if (n.Contains('.'))
            {
                sArray = n.Split('.');
            }
            else if (n.Contains(','))
            {
                sArray = n.Split(',');
            }
            else
            {
                return Convert.ToInt64(n + CompleteRightZeros(decimalSize));
            }

            return Convert.ToInt64(sArray[0] + CompleteRightZeros(decimalSize, sArray[1]));
            //return Convert.ToInt64(n);
        }

        public static decimal ConvLongToDecimal(long number, int decimalSize)
        {
            var numberToDiv = Convert.ToInt64("1" + CompleteRightZeros(decimalSize));


            return ((decimal)number) / numberToDiv;
        }

        public static string StringEncrypt(string plainText, string exclusiveKey = "")
        {
            try
            {
                return StringCipher.Encrypt(plainText, string.IsNullOrWhiteSpace(exclusiveKey) ? "AadfasdASfsah!@#525as1djo9isuhj9d56das" : exclusiveKey);
            }
            catch (Exception)
            {
                throw new ExceptionControlled("Ocorreu uma falha ao tentar criptografar o texto: '" + plainText + "'", false, false);
            }
        }

        public static string StringDecrypt(string plainText, string exclusiveKey = "")
        {
            try
            {
                return StringCipher.Decrypt(plainText, string.IsNullOrWhiteSpace(exclusiveKey) ? "AadfasdASfsah!@#525as1djo9isuhj9d56das" : exclusiveKey);
            }
            catch (Exception)
            {
                throw new ExceptionControlled("Ocorreu uma falha ao tentar decriptografar o texto: '" + plainText + "'", false, false);
            }
        }

        public static object GetPropertyValue(object obj, string propName)
        {
            Type myType = obj.GetType();
            IList<PropertyInfo> props = new List<PropertyInfo>(myType.GetProperties());

            return props.Where(o => o.Name == propName).FirstOrDefault().GetValue(obj);

        }

        public static decimal CalculateCoinTransactions(decimal CurrencyFrom, decimal CurrencyTo, decimal Amount)
        {

            if (CurrencyFrom <= 0 || CurrencyTo <= 0 || Amount <= 0)
            {
                throw new ExceptionControlled("Calculate Fail", false, false);
            }
            var result = ((CurrencyTo * Amount) / CurrencyFrom);
            return result;

        }


        const string Key = "31031986310319863103198631031986"; // must be 32 character
        const string IV = "3103198631031986"; // must be 16 character

        public static string DecryptPayment(string encryptedText)
        {
            encryptedText = encryptedText.Replace(" ", "+");

            string plaintext = null;
            using (AesManaged aes = new AesManaged())
            {
                byte[] cipherText = Convert.FromBase64String(encryptedText);
                byte[] aesIV = UTF8Encoding.UTF8.GetBytes(IV);
                byte[] aesKey = UTF8Encoding.UTF8.GetBytes(Key);
                ICryptoTransform decryptor = aes.CreateDecryptor(aesKey, aesIV);
                using (MemoryStream ms = new MemoryStream(cipherText))
                {
                    using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader reader = new StreamReader(cs))
                            plaintext = reader.ReadToEnd();
                    }
                }
            }
            return plaintext;
        }
        public static string EncryptPayment(string message)
        {
            AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
            aes.BlockSize = 128;
            aes.KeySize = 256;
            aes.IV = UTF8Encoding.UTF8.GetBytes(IV);
            aes.Key = UTF8Encoding.UTF8.GetBytes(Key);
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;
            byte[] data = Encoding.UTF8.GetBytes(message);
            using (ICryptoTransform encrypt = aes.CreateEncryptor())
            {
                byte[] dest = encrypt.TransformFinalBlock(data, 0, data.Length);
                return Convert.ToBase64String(dest);
            }
        }
        public static async Task<string> UploadFileToS3(string keyS3, string secretKeyS3, string bucketName, string base64String, bool compress = false, int defaultCompress = 100, int maxWidth = 500)
        {

            try
            {

                var basecheck = base64String.Split(",");
                byte[] bytescheck = Convert.FromBase64String(basecheck[1]);

                var typeImage = basecheck[0].Split("/");
                typeImage = typeImage[1].Split(";");

                if (typeImage[0] == "webp") throw new ExceptionControlled("Type of Image not válid", false, false);


                string[] base64;

                if (compress)
                {

                    base64 = CompressImageBase64(base64String, defaultCompress, maxWidth).Split(",");
                }
                else
                {
                    base64 = base64String.Split(",");
                }



                byte[] bytes = Convert.FromBase64String(base64[1]);

                typeImage = base64[0].Split("/");
                typeImage = typeImage[1].Split(";");



                var randomName = Guid.NewGuid().ToString() + "." + typeImage[0];

                // access key id and secret key id, can be generated by navigating to IAM roles in AWS and then add new user, select permissions
                //for this example, try giving S3 full permissions
                using (var client = new AmazonS3Client(keyS3, secretKeyS3, RegionEndpoint.USEast1))
                {
                    using (var newMemoryStream = new MemoryStream(bytes))
                    {


                        var uploadRequest = new TransferUtilityUploadRequest
                        {
                            InputStream = newMemoryStream,
                            Key = randomName, // filename
                            BucketName = bucketName // bucket name of S3
                        };

                        var fileTransferUtility = new TransferUtility(client);
                        await fileTransferUtility.UploadAsync(uploadRequest);
                    }
                }
                return randomName;

            }
            catch (Exception e)
            {
                throw new ExceptionControlled($"Uploaded Fail{e}", false, false);
            }

        }
        public static void S3DeleteItem(string keyS3, string secretKeyS3, string bucketName, string image)
        {

            try
            {

                using (var client = new AmazonS3Client(keyS3, secretKeyS3, RegionEndpoint.USEast1))
                {
                    DeleteObjectRequest deleteObjectRequest = new DeleteObjectRequest
                    {
                        BucketName = bucketName,
                        Key = image
                    };

                    client.DeleteObjectAsync(deleteObjectRequest);

                }

            }
            catch (Exception e)
            {
                throw new ExceptionControlled($"Uploaded Fail{e}", false, false);
            }

        }
        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public enum ImageQuality : long
        {
            low = 40L,
            medium = 60L,
            high = 80L,
            none = 100L
        }
        public static string CompressImageBase64(string base64String, int quality = 100, int maxWidth = 500)
        {

            byte[] currentByteImageArray = Convert.FromBase64String(base64String.Split(",")[1]);

            var param = new EncoderParameters(1);
            param.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, (long)quality);

            MemoryStream inputMemoryStream = new MemoryStream(currentByteImageArray);
            Image fullsizeImage = Image.FromStream(inputMemoryStream);

            Bitmap fullSizeBitmap = null;

            if (fullsizeImage.Width > maxWidth)
            {

                int newHeight = (maxWidth * fullsizeImage.Height) / fullsizeImage.Width;
                fullSizeBitmap = new Bitmap(fullsizeImage, new Size((int)(maxWidth), (int)(newHeight)));

            }
            else
            {
                fullSizeBitmap = new Bitmap(fullsizeImage);
            }


            MemoryStream resultStream = new MemoryStream();

            var codec = GetImageCodec(fullsizeImage.RawFormat);


            fullSizeBitmap.Save(resultStream, codec, param);

            currentByteImageArray = resultStream.ToArray();
            resultStream.Dispose();
            resultStream.Close();


            return base64String.Split(",")[0] + "," + Convert.ToBase64String(currentByteImageArray);
        }
        public static string RemoveAccents(string text)
        {
            StringBuilder sbReturn = new StringBuilder();
            var arrayText = text.Normalize(NormalizationForm.FormD).ToCharArray();
            foreach (char letter in arrayText)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(letter) != UnicodeCategory.NonSpacingMark)
                    sbReturn.Append(letter);
            }
            return sbReturn.ToString();
        }

        public static async Task<string> CompressVideo([FromForm] IFormFile archive)
        {
            // DOCUMENTACAO
            var newName = Guid.NewGuid().ToString();

            var localTemp = Path.GetTempPath();

            var tempPath = localTemp + archive.FileName;

            using (var stream = new FileStream(tempPath, FileMode.Create))
            {
                await archive.CopyToAsync(stream);
            }

            var FFmpegpath = "C:\\ffmpeg\\bin";
            FFmpeg.SetExecutablesPath(FFmpegpath, ffmpegExeutableName: "FFmpeg");

            //Entrada
            string InputFilePath = Path.Combine(localTemp, archive.FileName);

            //Saida
            string OutputFilePath = Path.Combine(localTemp, newName + ".mp4");

            // screenshot
            //IConversion conversion = await FFmpeg.Conversions.FromSnippet.Snapshot(InputFilePath, OutputFilePath, TimeSpan.FromSeconds(10));
            //IConversionResult result = await conversion.Start();

            // compression
            IMediaInfo mediaInfo = await FFmpeg.GetMediaInfo(InputFilePath);
            var conversionResult = await FFmpeg.Conversions.New()
                .AddStream(mediaInfo.Streams)
                .AddParameter($"-ss {TimeSpan.FromSeconds(0)}")
                .SetOutput(OutputFilePath)
                .Start();

            return newName;
        }

        private static ImageCodecInfo GetImageCodec(ImageFormat formato)
        {
            var codec = ImageCodecInfo.GetImageDecoders().FirstOrDefault(c => c.FormatID == formato.Guid);
            if (codec == null) throw new NotSupportedException();
            return codec;
        }

        public static string EncodeToBase64(string texto)
        {
            try
            {
                byte[] textoAsBytes = Encoding.ASCII.GetBytes(texto);
                string resultado = System.Convert.ToBase64String(textoAsBytes);
                return resultado;
            }
            catch (Exception)
            {
                throw;
            }
        }


        private static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        public static string GerenciaNetAuth(string ClientId, string ClientSecret)
        {
            try
            {
                var credencials = new Dictionary<string, string>{
                    {"client_id", "Client_Id_67be0468eafdaa2310d7d9b396b7c114ed83e8c2"},
                    {"client_secret", "Client_Secret_076b500a40619aec79172a7e3569a5c0e483466d"}
                };
                var authorization = Base64Encode(credencials["client_id"] + ":" + credencials["client_secret"]);
                var client = new RestSharp.RestClient("https://api-pix-h.gerencianet.com.br/oauth/token");
                var request = new RestRequest(Method.POST);

                X509Certificate2 uidCert = new X509Certificate2("../homologacao-378652-certificadodobu.p12", "");
                client.ClientCertificates = new X509CertificateCollection() { uidCert };

                request.AddHeader("Authorization", "Basic " + authorization);
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("application/json", "{\r\n    \"grant_type\": \"client_credentials\"\r\n}", ParameterType.RequestBody);

                IRestResponse restResponse = client.Execute(request);
                string response = restResponse.Content;

                return response;

            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}

