using EShop.Services.Order.Application.Abstraction.DataAccess;
using EShop.Services.Order.Application.Query.UseCases.GetOrders.Dtos;
using MediatR;

namespace EShop.Services.Order.Application.Query.UseCases.GetOrders
{
    public class GetOrdersQueryHandler : IRequestHandler<GetOrdersRequest, GetOrdersResponse>
    {
        private readonly IOrderSnapshotRepository _orderSnapshotRepository;

        public GetOrdersQueryHandler(IOrderSnapshotRepository orderSnapshotRepository)
        {
            _orderSnapshotRepository = orderSnapshotRepository;
        }

        public async Task<GetOrdersResponse> Handle(GetOrdersRequest request, CancellationToken cancellationToken)
        {
            var response = new GetOrdersResponse
            {
                Orders = _orderSnapshotRepository.GetOrders(request.StartDate, request.EndDate)
            };

            return response;
        }
    }
}
