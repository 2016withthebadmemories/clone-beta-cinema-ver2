using Microsoft.AspNetCore.Http;
using MyWebApiApp.Models;
using System.Threading.Tasks;

namespace MyWebApiApp.Services
{
    public interface IPayPalService
    {
        Task<string> CreatePaymentUrl(PaymentInformationModel model, HttpContext context);
        PaymentResponseModel PaymentExecute(IQueryCollection collections);
    }
}