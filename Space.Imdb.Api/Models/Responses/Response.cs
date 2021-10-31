using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Space.Imdb.Api.Models.Responses
{
    public class Response
    {
        protected Response()
        {

        }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("isSuccess")]
        public bool IsSuccess { get; set; }

        public static Response Fail(string message)
        {
            return new Response { IsSuccess = false, Message = message };
        }

        public static Response Fail()
        {
            return new Response { IsSuccess = false, Message = "Fail" };
        }

        public static Response Ok(string message)
        {
            return new Response { IsSuccess = true, Message = message };
        }

        public static Response Ok()
        {
            return new Response { IsSuccess = true, Message = "success" };
        }

        public static Response Generate(bool isSuccess, string message)
        {
            return new Response { IsSuccess = isSuccess, Message = message };
        }
    }

    public class Response<T> : Response
    {
        [JsonProperty("data")]
        public T Data { get; set; }
    }
}
