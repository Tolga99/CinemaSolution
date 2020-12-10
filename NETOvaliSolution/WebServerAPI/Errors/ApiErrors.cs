using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace WebServerAPI
{
    public class ApiErrors
    {
        private int statusCode;
        private string statusDescription;
        private string message;

        public int StatusCode { get => statusCode; set => statusCode = value; }
        public string StatusDescription { get => statusDescription; set => statusDescription = value; }
        [JsonProperty(DefaultValueHandling= DefaultValueHandling.Ignore)]
        public string Message { get => message; set => message = value; }
        public ApiErrors(int code, string des)
        {
            this.StatusCode = code;
            this.StatusDescription = des;
        }
        public ApiErrors(int code, string des,string mes) : this (code,des)
        {
            this.Message = mes;
        }
    }
}
