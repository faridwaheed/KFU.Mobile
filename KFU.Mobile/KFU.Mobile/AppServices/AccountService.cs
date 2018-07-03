
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using KFU.Mobile.Helpers;
using KFU.Mobile.ViewModels;
using Newtonsoft.Json;

namespace KFU.Mobile.AppServices
{
    public static class AccountService
    {
        //private static string _url = "UserAccount/";

        public static async Task<string> Login(LoginPageViewModel data)
        {
            try
            {
                var httpClient = new HttpClient();
                var dataToSend = JsonConvert.SerializeObject(new
                {
                    Email = data.Email,
                    Password = data.Password,
                    IsMobile = true

                });

                var url = string.Format("{0}{1}{2}?data={3}", Constants.WebApiURL, WebApisUrl.UserAccount, "Login", dataToSend);
                var responseMessage = await httpClient.GetStringAsync(url);

                return responseMessage.Substring(1, responseMessage.Length - 2).Replace("\\", "");
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

       
        //public static async Task<User> GetUserData()
        //{
        //    try
        //    {
        //        UserDAL dal = new UserDAL();
        //        var httpClient = new HttpClient();
        //        var UserID = dal.GetUser().UserId.ToString();

        //        var url = string.Format("{0}{1}{2}?Id={3}", Constants.WebApiURL, WebApisUrl.UserAccount, "Get", UserID);
        //        var responseMessage = await httpClient.GetStringAsync(url);
        //        responseMessage = responseMessage.Substring(1, responseMessage.Length - 2).Replace("\\", "");
        //        return JsonConvert.DeserializeObject<User>(responseMessage);
        //    }
        //    catch (Exception e)
        //    {
        //        return new User();
        //    }
        //}

        //public static async Task<ResponseResults.AccountResult> UpdateAccount(UserViewModel data)
        //{
        //    try
        //    {
        //        //string NewURL = "UserPortal/";
        //        var httpClient = new HttpClient();
        //        data.AccessCode = Constants.AccessCode;
        //        var dataToSend = JsonConvert.SerializeObject(new
        //        {
        //            ID = data.Id,
        //            Name = data.Name,
        //            CityID = data.CityId,
        //            Address = data.Address,
        //            Mobile = data.Mobile,
        //            Email = data.Email,
        //            Password = data.Password,
        //            IsMobile = true
        //        });
        //        var url = string.Format("{0}{1}{2}?data={3}", Constants.WebApiURL, WebApisUrl.UserPortal, "UpdateUser", dataToSend);
        //        var responseMessage = await httpClient.GetStringAsync(url);

        //        ResponseResults.AccountResult result;
        //        Enum.TryParse(responseMessage.Replace("\"", ""), out result);
        //        return result;
        //    }
        //    catch
        //    {
        //        return ResponseResults.AccountResult.NotSaved;
        //    }
        //}


        //public static async Task<string> ChangePassword(UserViewModel data)
        //{
        //    try
        //    {
        //        //string NewURL = "UserPortal/";
        //        var httpClient = new HttpClient();
        //        var url = string.Format("{0}{1}{2}?ID={3}&CurrentPass={4}&NewPass={5}", Constants.WebApiURL, WebApisUrl.UserAccount, "ChangePassword", data.Id, data.Password, data.NewPassword);
        //        var responseMessage = await httpClient.GetStringAsync(url);
        //        return responseMessage.ToString().Replace("\"", "");
        //    }
        //    catch (Exception e)
        //    {
        //        return string.Empty;
        //    }
        //}
        
        //Account/Forget
        public static async Task<string> ForgetPassword(LoginPageViewModel data)
        {
            try
            {
                var httpClient = new HttpClient();
              //  data.AccessCode = Constants.AccessCode;
               // var dataToSend = JsonConvert.SerializeObject(new { Email = data.Email });
                var url = string.Format("{0}{1}{2}?Email={3}", Constants.WebApiURL, WebApisUrl.UserAccount, "ForgetPassword",data.Email);
                var responseMessage = await httpClient.GetStringAsync(url);
                return responseMessage.ToString().Replace("\"", "");
            }
            catch(Exception e)
            {
                return string.Empty;
            }
            }

      
    }
}
