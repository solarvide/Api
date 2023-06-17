using App.Dto.Proposal;
using iTextSharp.text.pdf.parser;
using iTextSharp.text.pdf;
using Newtonsoft.Json;
using Org.BouncyCastle.Asn1.Ocsp;
using System.Text.RegularExpressions;
using System.Text;
using Util;

namespace App.TrackAccount
{
    public class TrackingAccount
    {
        public static async Task<string> AccountPdf(string archiveBase64)
        {
            try
            {
                var randomName = Guid.NewGuid().ToString();
                string filePath = $"Archive/{randomName}.pdf";
                byte[] decodedBytes = Convert.FromBase64String(archiveBase64);

                await File.WriteAllBytesAsync(filePath, decodedBytes);

                using (var reader = new PdfReader(filePath))
                {
                    // Obtém o número de páginas no arquivo PDF
                    int pages = reader.NumberOfPages;

                    // Cria uma nova instância do objeto StringBuilder
                    StringBuilder text = new StringBuilder();
                    
                    // Itera sobre cada página do arquivo PDF
                    for (int i = 1; i <= pages; i++)
                    {
                        // Extrai o texto da página atual
                        string thePage = PdfTextExtractor.GetTextFromPage(reader, i, new LocationTextExtractionStrategy());

                        // Adiciona o texto à StringBuilder
                        text.Append(thePage);
                    }

                    // Cria uma lista vazia para armazenar os dados de mês e valor
                    List<Month> monthValues = new List<Month>();

                    // Divide o texto extraído em linhas
                    string[] lines = text.ToString().Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

                    // Itera sobre cada linha
                    foreach (string line in lines)
                    {
                        // Verifica se a linha contém o nome de um mês
                        if (Regex.IsMatch(line, @"\b(JAN|FEV|MAR|ABR|MAI|JUN|JUL|AGO|SET|OUT|NOV|DEZ)\b", RegexOptions.IgnoreCase))
                        {
                            // Divide a linha em palavras
                            string[] words = line.Split(' ');

                            // Itera sobre cada palavra
                            for (int i = 0; i < words.Length; i++)
                            {
                                // Verifica se a palavra é um número
                                if (Regex.IsMatch(words[i], "^[0-9]+$"))
                                {
                                    if (i > 0)
                                    {
                                        if (decimal.TryParse(words[i], out decimal value))
                                        {
                                               // Adiciona o mês e o valor à lista
                                            monthValues.Add(new Month { month = words[i - 1], Value = value });
                                        }
                                    }
                                }
                            }
                        }
                    }

                    var month = new string[] { "JAN", "FEV", "MAR", "ABR", "MAI", "JUN", "JUL", "AGO", "SET", "OUT", "NOV", "DEZ" };

                    var data = monthValues.Where(x => month.Contains(x.month)).ToList();

                    var amountValue = monthValues.Sum(o => o.Value);
                    decimal average = amountValue /12;

                    var orderdata = data.OrderBy(x => x.month).ToList();
                    var dataReturn = new
                    {
                        Media = average,
                        Historic = orderdata
                    };

                    string json = JsonConvert.SerializeObject(dataReturn);

                    return json;
                }
            }
            catch (Exception)
            {
                throw new ExceptionControlled("Ocorreu um erro ao processar a conta", false, false);
            }
        }

    }
}
