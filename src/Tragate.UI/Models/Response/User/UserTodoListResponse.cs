using System.Collections.Generic;
using Newtonsoft.Json;
using Tragate.UI.Models.Dto;

namespace Tragate.UI.Models.Response
{
    public class UserTodoListResponse : BaseResponse
    {
        [JsonProperty("data")]
        public List<UserTodoListDto> UserTodos { get; set; }
    }
}