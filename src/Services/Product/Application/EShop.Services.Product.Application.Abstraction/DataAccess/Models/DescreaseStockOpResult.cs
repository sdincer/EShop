using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Services.Product.Application.Abstraction.DataAccess.Models
{
    public enum DescreaseStockOpResult
    {
        Success = 0,
        ListingNotFound = 1,
        InsufficientStock = 2,
    }
}
