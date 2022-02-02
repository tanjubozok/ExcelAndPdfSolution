using FastMember;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace ExcelAndPdfOperations.Controllers
{
    public class PdfController : BaseController
    {
        public async Task<IActionResult> GetPdf()
        {
            DataTable dataTable = new();
            dataTable.Load(ObjectReader.Create(await ListProduct()));

            string fileName = Guid.NewGuid() + ".pdf";
            string filePath = "wwwroot/documents/" + fileName;
            string pathCombine = Path.Combine(Directory.GetCurrentDirectory(), filePath);

            var stream = new FileStream(pathCombine, FileMode.Create);

            Document document = new(PageSize.A4, 15f, 15f, 25f, 25f);
            PdfWriter.GetInstance(document, stream);

            document.Open();

            PdfPTable pdfPTable = new(dataTable.Columns.Count);
            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                pdfPTable.AddCell(dataTable.Columns[i].ColumnName);
            }

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                for (int j = 0; j < dataTable.Columns.Count; j++)
                {
                    pdfPTable.AddCell(dataTable.Rows[i][j].ToString());
                }
            }
            document.Add(pdfPTable);

            document.Close();

            return File("/documents/" + fileName, "application/pdf", fileName);
        }
    }
}
