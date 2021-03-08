using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinAndroidApp.Model
{
  public  class UserData
    {

        public string Message { get; set; }
        public bool Status { get; set; }
        public string KeyMessage { get; set; }
        public int StatusCode { get; set; }

        public LabtestResponseData Results { get; set; }
        public List<string> Errors { get; set; }


    }
}
