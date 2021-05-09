using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Tragate.UI.Models.Category {
    public class GeneralCategoryViewModel {
        [Key]
        [DisplayName ("Id")]
        public int Id { get; set; }

        [DisplayName ("Ana Kategori No")]
        public int? ParentId { get; set; }

        [DisplayName ("Kategori Adı")]
        [Required (ErrorMessage = "Lütfen kategori adı alanını doldurunuz")]
        public string Title { get; set; }

        [DisplayName ("Meta Anahtar Kelimesi")]
        public string MetaKeyword { get; set; }

        [DisplayName ("Meta Açıklaması")]
        public string MetaDescription { get; set; }

        [DisplayName ("Alt Kategorisi var mı ?")]
        public bool HasChild { get; set; }

        [DisplayName ("Durumu")]
        public int StatusId { get; set; }

        public int CreatedUserId { get; set; }

        public string ImagePath { get; set; }

        [DisplayName ("Öncelik")]
        public int Priority { get; set; }
    }
}