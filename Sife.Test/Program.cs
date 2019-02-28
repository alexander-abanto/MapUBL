using Sife.MapXmlUBL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace Sife.Test
{
    class Program
    {
        static void Main(string[] args)
        {


            XmlSerializer serial = new XmlSerializer(typeof(InvoiceType));
            string path = UniversalFilePathResolver.ResolvePath(@"~\xml\20553510661-01-F001-1.xml");
            FileStream fs = new FileStream($"{path}", FileMode.Open);
            var _comprobante = (InvoiceType)serial.Deserialize(fs);
            var invoices = _comprobante.InvoiceLine.Select(c => new Invoice
            {
                Id = c.ID.Value,
                Quantity = c.InvoicedQuantity.Value.ToString(),
                Ammount = c.LineExtensionAmount.Value.ToString(),
                Description = string.Join("; ", c.Item.Description.Select(x => x.Value))
            }).ToList();

            string cadena = Space($"{invoices[0].Id}|{invoices[0].Description}|{invoices[0].Quantity}|{invoices[0].Ammount}|");
            var ar = cadena.Split('|');
            var cab = Space("IDDescriptionQuantityAmmount");

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine($"ID{ar[0]}|Description{ar[1]}|Quantity{ar[2]}|Ammount{ar[3]}|");
            Console.ResetColor();
            Console.WriteLine($"{cadena.Replace(" ", "-").Replace("|", "-")}{cab.Replace(" ", "-")}");
            foreach (var item in invoices)
            {
                Console.WriteLine($"{item.Id}{Space("ID")}|{item.Description}{Space("Description")}|{Space("Quantity")}{item.Quantity}|{Space("Ammount")}{item.Ammount}|");
                Console.WriteLine($"{cadena.Replace(" ", "-").Replace("|", "-")}{cab.Replace(" ", "-")}");
            }


            //var cdrResponse = new CdrResponse();

            //string base64 = Convert.ToBase64String(File.ReadAllBytes(UniversalFilePathResolver.ResolvePath(@"~\zip\R20602690866-01-FF60-00000004.zip")));

            //XmlSerializer serial = new XmlSerializer(typeof(ApplicationResponseType));

            //var returnByte = Convert.FromBase64String(base64);
            //using (var memRespuesta = new MemoryStream(returnByte))
            //{
            //    using (var zipFile = Ionic.Zip.ZipFile.Read(memRespuesta))
            //    {
            //        foreach (var entry in zipFile.Entries)
            //        {
            //            if (!entry.FileName.EndsWith(".xml")) continue;

            //            using (var ms = new MemoryStream())
            //            {


            //                entry.Extract(ms);
            //                ms.Position = 0;
            //                var responseReader = new StreamReader(ms);
            //                var applicationResponseType = (ApplicationResponseType)serial.Deserialize(responseReader);

            //                cdrResponse.ID = applicationResponseType.ID.Value;
            //                cdrResponse.ProcessReceptionId = applicationResponseType.ID.Value;
            //                cdrResponse.ResponseDescription = applicationResponseType.DocumentResponse[0].Response.Description != null ? string.Join("; ", applicationResponseType.DocumentResponse[0].Response.Description.Select(x => x.Value)) : string.Empty;
            //                cdrResponse.ResponseCode = applicationResponseType.DocumentResponse[0].Response.ResponseCode.Value;
            //                cdrResponse.ResponseNote = applicationResponseType.Note != null ? string.Join("; ", applicationResponseType.Note.Select(x => x.Value)) : string.Empty;
            //            }
            //        }
            //    }
            //}
            //Console.WriteLine($"COD: {cdrResponse.ResponseCode}, DESCRIPCION: {cdrResponse.ResponseDescription}");

            Console.ReadKey();
        }

        static string Space(string contens)
        {
            string cadena = string.Empty;
            for (int i = 0; i < contens.Length; i++)
            {
                var item = contens[i].ToString();
                cadena += item == "|" ? "|" : $" ";
            }
            return cadena;
        }



    }//enc class


}
