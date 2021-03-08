using System;
using System.Collections.Generic;
using System.Text;
using XamarinAndroidApp.Model;

namespace XamarinAndroidApp
{
   public class Response
    {

        public string Message { get; set; }
        public bool Status { get; set; }
        public string KeyMessage { get; set; }
        public int StatusCode { get; set; }
       
       public Results Results { get; set; }
        public List<string> Errors { get; set; }

      

    }
}
