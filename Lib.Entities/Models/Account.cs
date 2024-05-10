using System;
using System.Collections.Generic;

namespace Lib.Entities.Models
{
    public partial class Account
    {
        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? Resetpasswordtoken { get; set; }
        public DateOnly? Resetexpiretime { get; set; }
        public int? Status { get; set; }
        public short? Type { get; set; }
        public int? Dataid { get; set; }
    }
}
