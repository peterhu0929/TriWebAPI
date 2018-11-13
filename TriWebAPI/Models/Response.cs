using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TriWebAPI.Models
{
    public class Response<T>
    {
        public bool IsSuccess { get; set; }
        public T Data { get; set; }
        public string ErrorMessage { get; set; }
    }
}
