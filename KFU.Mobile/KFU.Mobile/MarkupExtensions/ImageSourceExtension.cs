using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KFU.Mobile.MarkupExtensions
{
    [ContentProperty("Source")]
    public class ImageSourceExtension : IMarkupExtension
    {
        private static Dictionary<string, string> _sources;
        
        public ImageSourceExtension()
        {
            if (_sources == null)
            {
                _sources = new Dictionary<string, string>();

                _sources.Add("EmailIcon", "KFU.iconemail.jpg");
                _sources.Add("UserIcon", "KFU.iconuser.jpg");
                _sources.Add("PasswordIcon", "KFU.iconpassword.jpg");
                //_sources.Add("LocationIcon", "Mala3bnaSA.locationicon.jpg");
                //_sources.Add("PhoneIcon", "Mala3bnaSA.iconphone.jpg");
                //_sources.Add("LogoImg", "Mala3bnaSA.newlogo.png");
                //_sources.Add("MobileIcon", "Mala3bnaSA.iconmobile.jpg");
                //_sources.Add("FaxIcon", "Mala3bnaSA.iconfax.jpg");
                //_sources.Add("FieldIcon", "Mala3bnaSA.iconfield.jpg");
                //_sources.Add("ConnectivityIcon", "Mala3bnaSA.network.png");
            }
        }

        public string Source { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Source == null)
            {
                return null;
            }
            // Do your translation lookup here, using whatever method you require
            var imageSource = ImageSource.FromResource(_sources[Source]);

            return imageSource;
        }
    }
}
