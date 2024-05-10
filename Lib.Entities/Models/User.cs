using System;
using System.Collections.Generic;

namespace Lib.Entities.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public int? Gender { get; set; }
        public int? Status { get; set; }
        public DateOnly? Birthday { get; set; }
        public DateOnly? Createdate { get; set; }
        public string? Avatar { get; set; }
        public string? Code { get; set; }
    }
}
