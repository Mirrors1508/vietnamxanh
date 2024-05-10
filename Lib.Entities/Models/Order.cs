using System;
using System.Collections.Generic;

namespace Lib.Entities.Models
{
    public partial class Order
    {
        public int Id { get; set; }
        public string? Code { get; set; }
        public int? Productid { get; set; }
        public int? Clientid { get; set; }
    }
}
