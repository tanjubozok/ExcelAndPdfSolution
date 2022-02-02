using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;

namespace ExcelAndPdfOperations.Controllers
{
    public class ExcelController : BaseController
    {
        public async Task<IActionResult> List()
        {
            return View(await ListProduct());
        }

        public async Task<FileResult> NorthwindProductData()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            ExcelPackage excelPackage = new();

            var blank = excelPackage.Workbook.Worksheets.Add("Alan1");
            blank.Cells["A1"].LoadFromCollection(await ListProduct(), true, OfficeOpenXml.Table.TableStyles.Light15);

            var bytes = await excelPackage.GetAsByteArrayAsync();
            const string excelContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

            return File(bytes, excelContentType, Guid.NewGuid() + ".xlsx");
        }

        public IActionResult ExcelStaticData()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            ExcelPackage excelPackage = new();

            var blank = excelPackage.Workbook.Worksheets.Add("Alan1");

            blank.Cells[1, 1].Value = "Sıra";
            blank.Cells[1, 2].Value = "Ad";
            blank.Cells[1, 3].Value = "Soyad";
            blank.Cells[1, 4].Value = "Şehir";

            blank.Cells[2, 1].Value = "1";
            blank.Cells[2, 2].Value = "Merve";
            blank.Cells[2, 3].Value = "Taş";
            blank.Cells[2, 4].Value = "Istanbul";

            blank.Cells[3, 1].Value = "2";
            blank.Cells[3, 2].Value = "Hande";
            blank.Cells[3, 3].Value = "Demir";
            blank.Cells[3, 4].Value = "Izmir";

            blank.Cells[4, 1].Value = "3";
            blank.Cells[4, 2].Value = "Cafer";
            blank.Cells[4, 3].Value = "Gelibolu";
            blank.Cells[4, 4].Value = "Bursa";

            var bytes = excelPackage.GetAsByteArray();
            const string excelContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

            return File(bytes, excelContentType, Guid.NewGuid() + ".xlsx");
        }
    }
}