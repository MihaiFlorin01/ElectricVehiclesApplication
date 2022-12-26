using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.CustomerDtos
{
    public class ViewCustomerDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? BillingAddress { get; set; }
    }
}
