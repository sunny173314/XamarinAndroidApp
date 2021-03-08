using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinAndroidApp.Model
{
   public class LabTestData
    {
        [PrimaryKey]
        public int TestId { get; set; }
        public string TestName { get; set; }
        public string TestType { get; set; }
        public string ServiceSubGroupName { get; set; }
        public int Amount { get; set; }
        public bool IsPopular { get; set; }
    }
}
