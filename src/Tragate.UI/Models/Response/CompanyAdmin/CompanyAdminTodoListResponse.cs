using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tragate.UI.Models.Dto;

namespace Tragate.UI.Models.Response.CompanyAdmin
{
    public class CompanyAdminTodoListResponse:BaseResponse
    {
        [JsonProperty("data")]
        public List<CompanyAdminTodoListDto> CompanyAdminTodos { get; set; }
    }
}
