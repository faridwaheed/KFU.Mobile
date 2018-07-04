using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KFU.Mobile.ViewModels
{
    public class StudentViewModel
    {
        public int Id { get; set; }
        public string UserID { get; set; }
        public string ArabicName { get; set; }
        public string EnglishName { get; set; }
        public string Mobile { get; set; }
        public string StudentNationalID { get; set; }
        public string Password { get; set; }
        public int StatusID { get; set; }
      
    }
}