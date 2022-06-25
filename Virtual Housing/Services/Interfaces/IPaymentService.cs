using Virtual_Housing.Models.Dto;
using Virtual_Housing.Models.Model;

namespace Virtual_Housing.Services.Interfaces
{
    public interface IPaymentService
    {
        Task<SuccessDto> CreatePayment(Payments model);
        Task<Payments> CheckPayment(string PaymentId);
    }
}
