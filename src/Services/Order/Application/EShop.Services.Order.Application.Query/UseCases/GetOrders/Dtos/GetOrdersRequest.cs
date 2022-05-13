using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Services.Order.Application.Query.UseCases.GetOrders.Dtos
{
    public class GetOrdersRequest : IRequest<GetOrdersResponse>
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
