using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tragate.UI.Models.User
{
    public class SendEmailVerifyViewModel
    {
        public string Email { get; set; }
        public string[] Errors { get; set; }
        public bool Success { get; set; }
    }
}
