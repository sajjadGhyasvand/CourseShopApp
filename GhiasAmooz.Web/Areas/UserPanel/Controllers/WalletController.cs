using GhiasAmooz.Core.DTOs;
using GhiasAmooz.Core.Services;
using GhiasAmooz.Core.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GhiasAmooz.Web.Areas.UserPanel.Controllers
{
    [Area("UserPanel")]
    [Authorize]
    public class WalletController : Controller
    {
        private IUserService _Service;
        public WalletController(IUserService service)
        {
            _Service = service;
        }

        [Route("UserPanel/Wallet")]
        public IActionResult Index()
        {
          ViewBag.ListWallet = _Service.GetWalletUser(User.Identity.Name);
            return View();
        }
        [Route("UserPanel/Wallet")]
        [HttpPost]
        public  IActionResult Index(ChargeWalletViewModel charge)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ListWallet = _Service.GetWalletUser(User.Identity.Name);
                return View(charge);
            }
            var walletId = _Service.ChargeWallet(User.Identity.Name, charge.Amout, "شارژ حساب");
            #region OnlinePayment
            var payment = new ZarinpalSandbox.Payment(charge.Amout);
            var response =  payment.PaymentRequest("شارژ کیف پول", "https://localhost:7189/OnlinePayment/"+walletId);

            if (response.Result.Status == 100)
            {
                return Redirect("https://sandbox.zarinpal.com/pg/StartPay/" + response.Result.Authority);
            }
            #endregion

            return null;
        }
    }
}
