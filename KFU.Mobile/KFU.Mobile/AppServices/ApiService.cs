
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using KFU.Mobile.Helpers;
using KFU.Mobile.ViewModels;
using Newtonsoft.Json;

namespace KFU.Mobile.AppServices
{
    public static class ApiService
    {
        public static async Task<StudentViewModel> Login(string userId, string password)
        {
            try
            {
                var httpClient = new HttpClient();
                //var model = new LoginPageViewModel
                //{
                //    UserId = userId,
                //    Password = password
                //};
                //var dataToSend = JsonConvert.SerializeObject(new
                //{
                //    Email = data.UserId,
                //    Password = data.Password,
                //    IsMobile = true
                //});

                var urll =
                    "http://pybanner.kfu.edu.sa/pybanner2014/KfuApi/api/Student/login";

                var uri = new Uri(string.Format(urll, string.Empty));


                var json = JsonConvert.SerializeObject(new
                {
                    userId = userId,
                    password = password
                });
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;

                response = await httpClient.PostAsync(uri, content);

                //var json = JsonConvert.SerializeObject(model);
                //HttpContent content = new StringContent(json);
                //content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                //var url =
                //    "https://pybanner.kfu.edu.sa/pybanner2014/KfuApi/api/Student/login?userId=" + model.UserId + "&password=" + model.Password;

                //var url =
                //    "http://pybanner.kfu.edu.sa/pybanner2014/KfuApi/api/Student/login?userId=&password=";

                //var respo = await httpClient.PostAsync(url, content);

                //var dataToSend = JsonConvert.SerializeObject(url);

                //var responseMessage = await httpClient.GetStringAsync(url);

                //var student=new StudentViewModel
                //{
                //    Mobile = responseMessage.
                //}

                //var recipeJson = JsonConvert.SerializeObject(responseMessage);

                // App.Current.Properties.Add(, recipeJson);
                await App.Current.SavePropertiesAsync();

                return null;
            }
            catch (Exception e)
            {
                return null;
            }
        }


        public static async Task<StudentViewModel> SelectStudentTimeTable(string studentId, int? quarterId)
        {
            try
            {
                //if (Xamarin.Forms.Application.Current.Properties.ContainsKey("ScrambledEggsRecipe"))
                //{
                //    studentId = App.Current.Properties["ScrambledEggsRecipe"] as string;
                //}
                var httpClient = new HttpClient();

                var url =
                    "https://pybanner.kfu.edu.sa/pybanner2014/KfuApi/api/Student/get_student_time_table?studentId=" + studentId + "&quarterId=" + quarterId;

                var respo = await httpClient.GetStringAsync(url);

                var dataToSend = JsonConvert.SerializeObject(url);

                var responseMessage = await httpClient.GetStringAsync(url);

                return null;
            }
            catch (Exception e)
            {
                return null;
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
                var url = string.Format("{0}{1}{2}?Email={3}", Constants.WebApiURL, WebApisUrl.UserAccount, "ForgetPassword", data.UserId);
                var responseMessage = await httpClient.GetStringAsync(url);
                return responseMessage.ToString().Replace("\"", "");
            }
            catch (Exception e)
            {
                return string.Empty;
            }
        }


    }
}
