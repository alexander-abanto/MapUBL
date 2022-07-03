# MapXmlUBL
Library that allows you to read electronic documents such as invoices, tickets and the answers given by SUNAT (CDR). Se requiere mínimo .NET 4

# Installation

    Install-Package Sife.MapXmlUBL -Version 1.1.0

# Example of use

**Invoice**

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

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine($"ID  |Description    |Quantity  |Ammount |");
            Console.ResetColor();
            foreach (var item in invoices)
            {
                Console.WriteLine($"{item.Id}|{item.Description}|{item.Quantity}|{item.Ammount}|");
            }
            Console.ReadKey();
    }
**CDR**

    static void Main(string[] args)
    {

            var cdrResponse = new CdrResponse();

            string base64 = Convert.ToBase64String(File.ReadAllBytes(UniversalFilePathResolver.ResolvePath(@"~\zip\R20602690866-01-FF60-00000004.zip")));

            XmlSerializer serial = new XmlSerializer(typeof(ApplicationResponseType));

            var returnByte = Convert.FromBase64String(base64);
            using (var memRespuesta = new MemoryStream(returnByte))
            {
                using (var zipFile = Ionic.Zip.ZipFile.Read(memRespuesta))
                {
                    foreach (var entry in zipFile.Entries)
                    {
                        if (!entry.FileName.EndsWith(".xml")) continue;

                        using (var ms = new MemoryStream())
                        {


                            entry.Extract(ms);
                            ms.Position = 0;
                            var responseReader = new StreamReader(ms);
                            var applicationResponseType = (ApplicationResponseType)serial.Deserialize(responseReader);

                            cdrResponse.ID = applicationResponseType.ID.Value;
                            cdrResponse.ProcessReceptionId = applicationResponseType.ID.Value;
                            cdrResponse.ResponseDescription = applicationResponseType.DocumentResponse[0].Response.Description != null ? string.Join("; ", applicationResponseType.DocumentResponse[0].Response.Description.Select(x => x.Value)) : string.Empty;
                            cdrResponse.ResponseCode = applicationResponseType.DocumentResponse[0].Response.ResponseCode.Value;
                            cdrResponse.ResponseNote = applicationResponseType.Note != null ? string.Join("; ", applicationResponseType.Note.Select(x => x.Value)) : string.Empty;
                        }
                    }
                }
            }
            Console.WriteLine($"COD: {cdrResponse.ResponseCode}, DESCRIPCION: {cdrResponse.ResponseDescription}");
            Console.ReadKey();
        }
