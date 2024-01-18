using Microsoft.AspNetCore.Http;
using MyWebApiApp.Models;
using System.Threading.Tasks;

namespace MyWebApiApp.Services
{
    public interface IMomoService
    {
        Task<MomoCreatePaymentResponseModel> CreatePaymentAsync(OrderInfoModel model);
        MomoExecuteResponseModel PaymentExecuteAsync(IQueryCollection collection);
    }
}