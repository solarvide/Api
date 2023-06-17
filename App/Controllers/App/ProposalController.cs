using App.Configurations;
using App.Dto.Proposal;
using AutoMapper;
using Context.Repo;
using Microsoft.AspNetCore.Mvc;
using Util;
using App.TrackAccount;


namespace App.Controllers.App
{
    [Route("api/[controller]/app")]
    [ApiController]
    public class ProposalController : ControllerBase
    {

        private readonly ContextApp _context;
        private readonly IMapper _mapper;
        private readonly SettingsApp _settingsApp;

        public ProposalController(ContextApp context, IMapper mapper, SettingsApp settings)
        {
            _context = context;
            _mapper = mapper;
            _settingsApp = settings;
        }

        [HttpPost("Track")]
        public ActionResult Trackaccount(ProposalRequestDto request)
        {
            try
            {
                var tracking = TrackingAccount.AccountPdf(request.Archive);
                return Ok(tracking.Result);

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


        //[HttpPost("Add")]
        //public ActionResult AddProposal(ProposalRequestDto request)
        //{
        //    try
        //    {

        //        return Ok();

        //        var randomName = Guid.NewGuid().ToString();
        //        string filePath = "";

        //        if (request.Type == 1)
        //        {
        //            filePath = @"Archive/" + randomName + ".pdf";
        //        }

        //        byte[] decodedBytes = Convert.FromBase64String((request.Archive));

        //        using (var fileStream = new FileStream(filePath, FileMode.Create))
        //        {
        //            fileStream.Write(decodedBytes, 0, decodedBytes.Length);
        //            fileStream.Close();
        //        }

        //        using (PdfReader reader = new PdfReader(filePath))
        //        {
        //            // Obtém o número de páginas no arquivo PDF
        //            int pages = reader.NumberOfPages;

        //            // Cria uma nova instância do objeto StringBuilder
        //            StringBuilder text = new StringBuilder();

        //            // Itera sobre cada página do arquivo PDF
        //            for (int i = 1; i <= pages; i++)
        //            {
        //                // Extrai o texto da página atual
        //                string thePage = PdfTextExtractor.GetTextFromPage(reader, i);
        //                // Adiciona o texto à StringBuilder
        //                text.Append(thePage);
        //            }

        //            // Cria uma lista vazia para armazenar os dados de mês e valor
        //            List<Month> monthValues = new List<Month>();

        //            // Divide o texto extraído em linhas
        //            string[] lines = Regex.Split(text.ToString(), "\r\n");

        //            // Itera sobre cada linha
        //            foreach (string line in lines)
        //            {
        //                // Verifica se a linha contém o nome de um mês
        //                if (Regex.IsMatch(line, @"JAN|FEV|MAR|ABR|MAI|JUN|JUL|AGO|SET|OUT|NOV|DEZ", RegexOptions.IgnoreCase))
        //                {
        //                    // Divide a linha em palavras
        //                    string[] words = Regex.Split(line, "\\s+");
        //                    // Itera sobre cada palavra
        //                    for (int i = 0; i < words.Length; i++)
        //                    {
        //                        // Verifica se a palavra é um número
        //                        if (Regex.IsMatch(words[i], "^[0-9]+$"))
        //                        {
        //                            // Adiciona o mês e o valor à lista
        //                            monthValues.Add(new Month { month = words[i - 1], Value = decimal.Parse(words[i]) });
        //                        }
        //                    }
        //                }
        //            }

        //            var month = new string[] { "JAN", "FEV", "MAR", "ABR", "MAI", "JUN", "JUL", "AGO", "SET", "OUT", "NOV", "DEZ" };

        //            var data = monthValues.Where(x => month.Contains(x.month)).ToList();

        //            var amountValue = monthValues.Sum(o => o.Value);
        //            var Totalmonth = data.Count();
        //            decimal average = amountValue / Totalmonth;

        //            var orderdata = data.OrderBy(x => x.month).ToList();


        //            string json = JsonConvert.SerializeObject(orderdata);

        //            var responser = new ProposalResponseDto()
        //            {
        //                Name = request.Name,
        //                Email = request.Email,
        //                Phone = request.Phone,
        //                WhatsApp = request.WhatsApp,
        //                Average = average,
        //                Archive = "https://cndsolarvide.fszion.com/proposta.pdf",
        //                Months = orderdata,
        //            };

        //            var proposal = _mapper.Map<ProposalResponseDto, Proposal>(responser);
        //            _context.Add(proposal);
        //            _context.SaveChanges();

        //            foreach (var item in orderdata)
        //            {
        //                var historic = new ProposalHistoricEletric()
        //                {
        //                    Month = item.month,
        //                    Value = item.Value,
        //                    proposalId = proposal.Id,

        //                };

        //                _context.Add(historic);
        //            }
        //            _context.SaveChanges();

        //            return Ok(responser);
        //        }

        //    }
        //    catch (ExceptionControlled ex)
        //    {
        //        return BadRequest(ex.ResponseToJson());
        //    }
        //    catch (Exception ex)
        //    {

        //        return BadRequest(ExceptionControlled.ResponseToJson(ex));
        //    }
        //}


        //[HttpPost("List/")]
        //public ActionResult<List<ProposalResponseDto>> ListProposal(DefaultRequestDto request)
        //{
        //    try
        //    {
        //        request.QtyByPage = request.QtyByPage == 0 ? 99 : request.QtyByPage;
        //        request.Page = request.Page == 0 ? 1 : request.Page;
        //        request.Skip = (request.Page - 1) * request.QtyByPage;

        //        var query = _context.Proposal

        //            .Where(o =>!o.Deleted && (string.IsNullOrEmpty(request.Filter) || (o.Name.Contains(request.Filter))))
        //            .OrderBy(o => o.Name);

        //        int totalList = query.Count();


        //        var result = query.Skip(request.Skip).Take(request.QtyByPage);
        //        double totalPage = Math.Ceiling(totalList / (double)request.QtyByPage);

        //          // response
        //        var mapped = _mapper.Map<IEnumerable<Proposal>, IEnumerable<ProposalResponseDto>>(result.ToList());




        //        return Ok(mapped);

        //    }
        //    catch (ExceptionControlled ex)
        //    {
        //        return BadRequest(ex.ResponseToJson());
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ExceptionControlled.ResponseToJson(ex));
        //    }
        //}



    }
}
