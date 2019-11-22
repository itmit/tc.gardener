using System;
using System.Collections.Generic;
using System.Text;

namespace gardener.Services
{
    class JsonAuthDataResponse<T>
    {
        public T Data 
        { 
            get; 
            set; 
        }

        public string Message
        {
            get;
            set;
        } = "";

        public bool Success
        {
            get;
            set;
        } = false;
    }
}
