using Virtual_Housing.Models.Dto;
using Virtual_Housing.Models.Model;
using Virtual_Housing.Services.Interfaces;

namespace Virtual_Housing.Services.Implementation
{
    public class PaymentService : IPaymentService
    {
        public Task<Payments> CheckPayment(string PaymentId)
        {
            throw new NotImplementedException();
        }

        public Task<SuccessDto> CreatePayment(Payments model)
        {
            throw new NotImplementedException();
        }
    }
}
