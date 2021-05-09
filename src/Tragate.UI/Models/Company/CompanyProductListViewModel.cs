using System;
using System.Collections.Generic;
using System.ComponentModel;
using Newtonsoft.Json;

namespace Tragate.UI.Models.Company
{
    public class CompanyProductListViewModel :CompanyProfileViewModelBase 
    {
        public List<CompanyProductViewModel> CompanyProductList  { get; set; }

        public int PageSize   { get; set; }

        public int TotalCount   { get; set; }

        public int PageNumber   { get; set; }
    }
}