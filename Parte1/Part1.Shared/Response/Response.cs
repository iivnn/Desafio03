using System;
using System.Collections.Generic;
using System.Text;

namespace Part1.Shared.Response
{
    public class Response
    {
        public bool Sucess { get; set; }
        public string Message { get; set; } = string.Empty;
    }

    public class Response<T> : Response
    {
        public T? Data { get; set; }
    }
}
