using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Tragate.UI.Models.Location {
    public class LocationViewModel {
        [DisplayName ("Country")]
        public int CountryId { get; set; }

        [DisplayName ("State")]
        public int StateId { get; set; }

        public string DivideClass{get;set;}
        public string CountryName{get;set;}
        public string StateName{get;set;}
        
    }
}