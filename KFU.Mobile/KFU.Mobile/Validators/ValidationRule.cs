using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KFU.Mobile.Validators
{
    public class ValidationRule : Attribute
    {
        public string PropertyName { get; set; }
        public string RegexPattern { get; set; }
    }
}
