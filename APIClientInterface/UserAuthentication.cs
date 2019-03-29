using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Formatting;
using Models;
using System.Net;

namespace APIClientInterface
{
    public enum AUTHSTATUS { NONE, OK, INVALID, FAILED }
    public static class UserAuthentication
    {
        static public string baseWebAddress;
        static public string UserToken = "";
        static public AUTHSTATUS UserStatus = AUTHSTATUS.NONE;

        static public bool login(string username, string password)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var content = new FormUrlEncodedContent(new[]
                    {
                        new KeyValuePair<string, string>("grant_type", "password"),
                        new KeyValuePair<string, string>("username", username),
                        new KeyValuePair<string, string>("password", password),
                    });
                var result = client.PostAsync(baseWebAddress + "Token", content).Result;
                try
                {
                    var resultContent = result.Content.ReadAsAsync<Token>(
                        new[] { new JsonMediaTypeFormatter() }
                        ).Result;
                    string ServerError = string.Empty;
                    if (!(String.IsNullOrEmpty(resultContent.AccessToken)))
                    {
                        Console.WriteLine("token: " + resultContent.AccessToken);
                        UserToken = resultContent.AccessToken;
                        UserStatus = AUTHSTATUS.OK;
                        return true;
                    }
                    else
                    {
                        UserToken = "Invalid Login";
                        UserStatus = AUTHSTATUS.INVALID;
                        Console.WriteLine("Invalid credentials");
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    UserStatus = AUTHSTATUS.FAILED;
                    UserToken = "Server Error -> " + ex.Message;
                    Console.WriteLine(ex.Message);
                    return false;
                }

            }
        }
        public static List<Student> GetStudents()
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", UserToken);
                var response = client.GetAsync(baseWebAddress + "api/Students").Result;
                try
                {
                    var resultContent = response.Content.ReadAsAsync<List<Student>>(
                        new[] {new JsonMediaTypeFormatter()}).Result;
                    return resultContent;
                }
                catch (Exception e)
                {
                    return new List<Student>();
                }
                
            }
        }
    }
}
