
using System;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace KFU.Mobile.Helpers
{
    public static class CustomExtensions
    {
        public static string Compress(this string text)
        {
            using (MemoryStream output = new MemoryStream())
            {
                using (DeflateStream gzip =
                  new DeflateStream(output, CompressionMode.Compress))
                {
                    using (StreamWriter writer =
                      new StreamWriter(gzip, System.Text.Encoding.UTF8))
                    {
                        writer.Write(text);
                    }
                }
                return Convert.ToBase64String(output.ToArray());
            }
        }
        public static string Decompress(this string compressedText)
        {
            byte[] gzBuffer = Convert.FromBase64String(compressedText);
            using (MemoryStream inputStream = new MemoryStream(gzBuffer))
            {
                using (DeflateStream gzip =
                  new DeflateStream(inputStream, CompressionMode.Decompress))
                {
                    using (StreamReader reader =
                      new StreamReader(gzip, System.Text.Encoding.UTF8))
                    {
                        return reader.ReadToEnd();
                    }
                }
            }
        }

        //public static LoginResultViewModel GetUserData()
        //{
        //    UserDAL dal = new UserDAL();
        //    return dal.GetUser();
        //}


      //public static TimeSpan String2TimeSpan(string MyStringTime)
      //  {
      //      int hours = MyStringTime.EndsWith("am".ToUpper()) ? int.Parse(MyStringTime.Substring(0, 2)) : int.Parse(MyStringTime.Substring(0, 2)) + 12;
      //      int min = int.Parse(MyStringTime.Substring(3, 2));
      //      if (hours == 24)
      //          hours = 0;

      //      TimeSpan MyTime = new TimeSpan(hours, min, 0);
      //      return MyTime;
      //  }
    }
}
