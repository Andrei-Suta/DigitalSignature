using GemBox.Pdf;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace semnDigitala.Data
{
    [Route("api/[controller]")]
    [ApiController]
    public class Semnatura : ControllerBase
    {
        [HttpPost]
        [Route("semnare")] //apelarea api-ului se va face la <site>/api/semnatura/semnare
        public async Task<ActionResult<byte[]>> semnaturaDigitala([FromBody] PDF pdf)
        {
            ComponentInfo.SetLicense("FREE-LIMITED-KEY");

            using (var _pdf = PdfDocument.Load("C:/Users/andrei.suta/Desktop/x.pdf"))  //incarc pdf-ul ce trebuie semnat
            {
                var campSemnatura = _pdf.Form.Fields.AddSignature(); //adaug campul pentru semnatura
                campSemnatura.Sign("PrivateKeyCert.pfx", "1234");  //semnatura
                Console.WriteLine("dadaaaadaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
                //_pdf.Save("PdfSemnat.pdf");
                await Task.Run(() => _pdf.Save()); //inlocuiesc pdf-ul nesemnat cu pdf-ul semnat, salvandu-l la adresa furnizata ca parametru
                
            }
            byte[] bytesPDF = System.IO.File.ReadAllBytes("C:/Users/andrei.suta/Desktop/x.pdf"); //avand adresa pdf-ului, obtin byte array-ul pdf-ului semnat
            return bytesPDF;  //returnez byte array-ul pdf-ului semnat
        }
        //[HttpPost]
        //[Route("verificare")] //apelarea api-ului se va face la <site>/api/semnatura/verificare
        //public async Task<ActionResult<byte[]>> verificareSemnatura([FromBody] PDF pdf)
        //{

        //}

    }
}
