using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebApiApp.Models;
using MyWebApiApp.Services;
using System.Threading.Tasks;

namespace MyWebApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MomoController : ControllerBase
    {
        private IMomoService _momoService;
        private readonly IPayPalService _payPalService;
        public MomoController(IMomoService momoService, IPayPalService payPalService)
        {
            _momoService = momoService;
            _payPalService = payPalService;
        }

        [HttpPost]
        public async Task<MomoCreatePaymentResponseModel> CreatePaymentUrl(OrderInfoModel model)
        {
            var response = await _momoService.CreatePaymentAsync(model);
            return response;
        }

        [HttpPost("Paypal")]
        public async Task<ResponsePaypal> CreatePaymentUrl(PaymentInformationModel model)
        {
            var url = await _payPalService.CreatePaymentUrl(model, HttpContext);

            var response = new ResponsePaypal
            {
                Url = url
            };

            return response;
        }

    }
}
