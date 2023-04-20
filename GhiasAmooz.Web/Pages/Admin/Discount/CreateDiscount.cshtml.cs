using GhiasAmooz.Core.Services.Interfaces;
using GhiasAmooz.DataLayer.Entities.Order;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Globalization;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace GhiasAmooz.Web.Pages.Admin.Discount
{
    public class CreateDiscountModel : PageModel
    {
        private IOrderService _orderService;

        public CreateDiscountModel(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [BindProperty]
        public GhiasAmooz.DataLayer.Entities.Order.Discount Discount { get; set; }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            /*if (stDate != "")
            {
                string[] std = stDate.Split('/');
                Discount.StartDate = new DateTime(int.Parse(std[0]),
                    int.Parse(std[1]),
                    int.Parse(std[2]),
                    new PersianCalendar()
                    );
            }

            if (edDate != "")
            {
                string[] edd = edDate.Split('/');
                Discount.EndDate = new DateTime(int.Parse(edd[0]),
                    int.Parse(edd[1]),
                    int.Parse(edd[2]),
                    new PersianCalendar()
                );
            }
*/

            _orderService.AddDiscount(Discount);

            return RedirectToPage("Index");
        }
    }
}
