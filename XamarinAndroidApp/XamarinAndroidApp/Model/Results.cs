using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinAndroidApp.Model
{
   public class Results
    {
          [PrimaryKey]
        public int Id { get; set; }
        
        public string Email { get; set; }

      
        public string UserToken { get; set; }
     
        public bool RememberMe { get; set; }
      
        public string Centers { get; set; }
      
        public string FirstName { get; set; }
     
        public string LastName { get; set; }
      
        public string RoleName { get; set; }
    
        public string FullName { get; set; }
    
        public string PhleboCenter { get; set; }
       
        public string PhleboContactNumber { get; set; }

   }




}
