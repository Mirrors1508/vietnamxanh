using System;
using System.Collections.Generic;

namespace Lib.Entities.Models
{
    public partial class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Title { get; set; }
        public string? Body { get; set; }
        public int? Clientid { get; set; }
        public string? Attachments { get; set; }
    }
}
