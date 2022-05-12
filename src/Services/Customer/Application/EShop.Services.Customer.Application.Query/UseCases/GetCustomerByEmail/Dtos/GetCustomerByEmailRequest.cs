using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Services.Customer.Application.Query.UseCases.GetCustomerByEmail.Dtos
{
    public class GetCustomerByEmailRequest : IRequest<GetCustomerByEmailResponse>
    {
        public string Email { get; set; }
    }
}
