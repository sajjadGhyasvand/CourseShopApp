using GhiasAmooz.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GhiasAmooz.Web.Pages.Admin.Discount
{
    public class IndexModel : PageModel
    {
        private IOrderService _orderService;

        public IndexModel(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public List<DataLayer.Entities.Order.Discount> Discounts { get; set; }
        public void OnGet()
        {
            Discounts = _orderService.GetAllDiscounts();
        }
    }
}
