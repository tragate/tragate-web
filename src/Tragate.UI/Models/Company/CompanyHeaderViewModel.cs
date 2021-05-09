using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Tragate.UI.Models.Company {
    public class CompanyHeaderViewModel {

        public int? CompanyId { get; set; }

        public string Name { get; set; }

        public string Slug { get; set; }

        public bool IsAdmin { get; set; }

        public string ProfileImagePath { get; set; }
        public string MembershipType { get; internal set; }
        public int? MembershipTypeId { get; internal set; }
        public string VerificationType { get; internal set; }
        public int? VerificationTypeId { get; internal set; }
    }
}