using System;
using System.Collections.Generic;
using System.Text;

namespace SK_GamingSolution.Models
{
    public class ResponseWrapper<T>
    {
        public T Score { get; set; }
        public bool IsError { get; set; }
        public string ErrorMessage { get; set; }
    }
}
