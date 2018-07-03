using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace KFU.Mobile.Validators
{
    public class Validator
    {
        private View _container;
        private List<ValidationRule> _rules;
        private List<string> _inValidProps;

        public Validator(View container)
        {
            //if (container == null)
            //    throw new Exception("Validator container is null");
            _container = container;
            _inValidProps = new List<string>();
            _rules = new List<ValidationRule>();
        }

        public void AddRule(string propName, string pattern)
        {
            _rules.Add(new ValidationRule() {
                PropertyName = propName,
                RegexPattern = pattern
            });
        }

        public bool Validate<T>(T obj)
        {
            _inValidProps = new List<string>();
            bool result = true;
            var props = obj.GetType().GetRuntimeProperties().ToList();
            for(int i=0; i<props.Count; i++)
            {
                var property = props[i];
                var rule = _rules.FirstOrDefault(r => r.PropertyName == property.Name);
                if(rule != null)
                {
                    var value = property.GetValue(obj, null);
                    if (value == null || !Regex.IsMatch(value.ToString(), rule.RegexPattern))
                    {
                        ChangeMsgLabelVisibility(property.Name, true);
                        _inValidProps.Add(property.Name);
                        result = false;
                    }
                    else {
                        ChangeMsgLabelVisibility(property.Name, false);
                    }
                }
            }
            return result;
        }
        public List<string> GetInvalidProperties()
        {
            return _inValidProps;
        }
        private void ChangeMsgLabelVisibility(string labelName, bool isVisible)
        {
            if (_container != null)
            {
                var msgLabel = _container.FindByName<Label>(labelName);
                if (msgLabel != null)
                    msgLabel.IsVisible = isVisible;
            }
        }

        
    }
}
