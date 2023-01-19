using System;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BucketProcessor
{
    static class RestWorker {
        static readonly HttpClient client = new HttpClient();

        private static HttpClient GetHttpClient()
        {
            var client = new HttpClient { BaseAddress = new Uri("https://mocktarget.apigee.net") };
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }

        public static async void Curl(string str)
        {
          Console.WriteLine("Hello World!! from RestWorker class for: " + str);
          //using(var client = new HttpClient())
          //await GetCurl();
          await PostCurl();
          
        }

        private static async Task GetCurl()
        {
          try 
          {
            using (var client = GetHttpClient())
            {
            string responseBody = await client.GetStringAsync("/echo");
            Console.WriteLine(responseBody);
            }

          }
          catch (HttpRequestException e)
          {
            Console.WriteLine("\nException Caught!");
            Console.WriteLine("Message :{0} ", e.Message);
          }

        }

        private static async Task PostCurl()
        {
          try 
          {
            using (var client = GetHttpClient())
            {
            PostData pd = new PostData(){
              name = "John Doe",
              occup = "gardener"
            };

            var json = JsonConvert.SerializeObject(pd);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var url = "https://mocktarget.apigee.net/echo";
            //string responseBody = await client.GetStringAsync("/echo");
            var response = await client.PostAsync(url, data);
            var result = await response.Content.ReadAsStringAsync();

            Console.WriteLine(result);
            }

          }
          catch (HttpRequestException e)
          {
            Console.WriteLine("\nException Caught!");
            Console.WriteLine("Message :{0} ", e.Message);
          }

        }
    }

    public class PostData {
      public string name;
      public string occup;
    }
}