using MediatR;

namespace EShop.Services.Product.Application.Query.UseCases.GetListingsByProductCode.Dtos
{
    public class GetListingsByProductCodeRequest : IRequest<GetListingsByProductCodeResponse>
    {
        public string ProductCode { get; set; }
    }
}
