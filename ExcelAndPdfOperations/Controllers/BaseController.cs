using ExcelAndPdfOperations.DataAccess.Context;
using ExcelAndPdfOperations.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExcelAndPdfOperations.Controllers
{
    public class BaseController : Controller
    {
        protected readonly NorthwindContext _dbContext = new();

        protected async Task<List<ProductViewModel>> ListProduct()
        {
            var productList = await _dbContext.Products.ToListAsync();
            List<ProductViewModel> listModel = new();

            foreach (var item in productList)
            {
                ProductViewModel model = new()
                {
                    Discontinued = item.Discontinued,
                    ProductID = item.ProductID,
                    ProductName = item.ProductName,
                    QuantityPerUnit = item.QuantityPerUnit,
                    ReorderLevel = item.ReorderLevel,
                    UnitPrice = item.UnitPrice,
                    UnitsInStock = item.UnitsInStock,
                    UnitsOnOrder = item.UnitsOnOrder
                };
                listModel.Add(model);
            }
            return listModel;
        }
    }
}
