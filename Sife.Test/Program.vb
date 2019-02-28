Imports Sife.MapXmlUBL
Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.IO
Imports System.Linq
Imports System.Xml.Serialization

Namespace Sife.Test
    Friend Class Program
        Private Shared Sub Main(ByVal args As String())
            Dim serial As XmlSerializer = New XmlSerializer(GetType(InvoiceType))
            Dim path As String = UniversalFilePathResolver.ResolvePath("~\xml\20553510661-01-F001-1.xml")
            Dim fs As FileStream = New FileStream($"{path}", FileMode.Open)
            Dim _comprobante = CType(serial.Deserialize(fs), InvoiceType)
            Dim invoices = _comprobante.InvoiceLine.[Select](Function(c) New Invoice With {
                .Id = c.ID.Value,
                .Quantity = c.InvoicedQuantity.Value.ToString(),
                .Ammount = c.LineExtensionAmount.Value.ToString(),
                .Description = String.Join("; ", c.Item.Description.[Select](Function(x) x.Value))
            }).ToList()
            Dim cadena As String = Space($"{invoices(0).Id}|{invoices(0).Description}|{invoices(0).Quantity}|{invoices(0).Ammount}|")
            Dim ar = cadena.Split("|"c)
            Dim cab = Space("IDDescriptionQuantityAmmount")
            Console.ForegroundColor = ConsoleColor.DarkGreen
            Console.BackgroundColor = ConsoleColor.Green
            Console.WriteLine($"ID{ar(0)}|Description{ar(1)}|Quantity{ar(2)}|Ammount{ar(3)}|")
            Console.ResetColor()
            Console.WriteLine($"{cadena.Replace(" ", "-").Replace("|", "-")}{cab.Replace(" ", "-")}")

            For Each item In invoices
                Console.WriteLine($"{item.Id}{Space("ID")}|{item.Description}{Space("Description")}|{Space("Quantity")}{item.Quantity}|{Space("Ammount")}{item.Ammount}|")
                Console.WriteLine($"{cadena.Replace(" ", "-").Replace("|", "-")}{cab.Replace(" ", "-")}")
            Next

            Console.ReadKey()
        End Sub

        Private Shared Function Space(ByVal contens As String) As String
            Dim cadena As String = String.Empty

            For i As Integer = 0 To contens.Length - 1
                Dim item = contens(i).ToString()
                cadena += If(item Is "|", "|", $" ")
            Next

            Return cadena
        End Function
    End Class
End Namespace
