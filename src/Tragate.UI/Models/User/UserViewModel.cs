using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Tragate.UI.Common.Enums;
using Tragate.UI.Models.Dto;
using Tragate.UI.Models.Response;

namespace Tragate.UI.Models.User
{
    public class UserViewModel
    {
        [Key]
        [DisplayName("Kullanıcı No")]
        public int UserId { get; set; }

        [DisplayName("İsim")]
        public string UserName { get; set; }

        [DisplayName("Email")]
        public string Email { get; set; }

        [DisplayName("Durumu")]
        public int StatusType { get; set; }

        [DisplayName("Oluşturulma Tarihi")]
        public DateTime CreatedDate { get; set; }

        [DisplayName("Kullanıcı Tipi")]
        public UserType UserType { get; set; }
        
        [DisplayName("Kayıt Tipi")]
        public RegisterType RegisterType { get; set; }
        public bool EmailVerified { get; set; }
        
        [DisplayName("Profil Fotoğrafı Linki")]
        public string ProfileImagePath { get; set; }

        [DisplayName("Bölge")]
        public int? LocationId { get; set; }

        [DisplayName("Ülke")]
        public int? CountryId { get; set; }

        [DisplayName("İlçe")]
        public int? StateId { get; set; }


    }
}