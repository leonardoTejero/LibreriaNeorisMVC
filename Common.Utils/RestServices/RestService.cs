using Common.Utils.RestServices.Interface;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Common.Utils.RestServices
{
    public class RestService : IRestService
    {
        public async Task<T> PostRestServiceAsync<T>(string url, string controller,
          string method, object parameters, IDictionary<string, string> headers)
        {
            var baseUrl = string.Format("{0}/{1}/{2}", url, controller, method);

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                if (headers.Count > 0)
                {
                    foreach (var header in headers)
                    {
                        if (header.Key == "Token")
                            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", header.Value);
                        else
                            client.DefaultRequestHeaders.Add(header.Key, header.Value);
                    }
                }

                HttpContent jsonObject = new StringContent(JsonConvert.SerializeObject(parameters), Encoding.UTF8, "application/json");
                HttpResponseMessage res = await client.PostAsync(baseUrl, jsonObject);

                if (res.StatusCode == HttpStatusCode.Unauthorized)
                {
                    throw new Exception(string.Format("{0},{1},{2},{3}", url, res.StatusCode, res.Content, baseUrl));
                }
                else
                {
                    var data = await res.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<T>(data);
                }

                //if (res.StatusCode == HttpStatusCode.OK)
                //{
                //    var data = await res.Content.ReadAsStringAsync();
                //    return JsonConvert.DeserializeObject<T>(data);
                //}

                //throw new Exception(string.Format("{0},{1},{2},{3}", url, res.StatusCode, res.Content, baseUrl));
            }
        }

        // Get
        public async Task<T> GetRestServiceAsync<T>(string url, string controller, string method,
            IDictionary<string, string> parameters, IDictionary<string, string> headers)
        {
            string baseUrl = string.Format("{0}/{1}/{2}", url, controller, method);

            if (parameters.Count > 0)
                baseUrl = baseUrl + "?" + string.Join("&", parameters.Select(p => p.Key + "=" + p.Value).ToArray());

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                if (headers.Count > 0)
                {
                    foreach (var header in headers)
                    {
                        if (header.Key == "Token")
                            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", header.Value);
                        else
                            client.DefaultRequestHeaders.Add(header.Key, header.Value);
                    }
                }

                HttpResponseMessage res = await client.GetAsync(baseUrl);

                if (res.StatusCode == HttpStatusCode.Unauthorized)
                {
                    throw new Exception(string.Format("{0},{1},{2},{3}", url, res.StatusCode, res.Content, baseUrl));
                }
                else
                {
                    var data = await res.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<T>(data);
                }


                //if (res.IsSuccessStatusCode)
                //{
                //    var data = await res.Content.ReadAsStringAsync();
                //    return JsonConvert.DeserializeObject<T>(data);
                //}

                
            }
        }


        public async Task<T> PutRestServiceAsync<T>(string url, string controller,
         string method, object parameters, IDictionary<string, string> headers)
        {
            var baseUrl = string.Format("{0}/{1}/{2}", url, controller, method);

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                if (headers.Count > 0)
                {
                    foreach (var header in headers)
                    {
                        if (header.Key == "Token")
                            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", header.Value);
                        else
                            client.DefaultRequestHeaders.Add(header.Key, header.Value);
                    }
                }

                HttpContent jsonObject = new StringContent(JsonConvert.SerializeObject(parameters), Encoding.UTF8, "application/json");
                HttpResponseMessage res = await client.PutAsync(baseUrl, jsonObject);

                //if (res.IsSuccessStatusCode)
                //{
                //    var data = await res.Content.ReadAsStringAsync();
                //    return JsonConvert.DeserializeObject<T>(data);
                //}

                //throw new Exception(string.Format("{0},{1},{2},{3}", url, res.StatusCode, res.Content, baseUrl));

                var data = await res.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(data);
            }
        }

        // Delete
        public async Task<T> DeleteRestServiceAsync<T>(string url, string controller, string method,
            IDictionary<string, int> parameters, IDictionary<string, string> headers)
        {
            //HttpResponseMessage res;
            string baseUrl = string.Format("{0}/{1}/{2}", url, controller, method);

            if (parameters.Count > 0)
                baseUrl = baseUrl + "?" + string.Join("&", parameters.Select(p => p.Key + "=" + p.Value).ToArray());

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                if (headers.Count > 0)
                {
                    foreach (var header in headers)
                    {
                        if (header.Key == "Token")
                            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", header.Value);
                        else
                            client.DefaultRequestHeaders.Add(header.Key, header.Value);
                    }
                }

                HttpResponseMessage res = await client.DeleteAsync(baseUrl);

                //if (res.IsSuccessStatusCode)
                //{
                //    var data = await res.Content.ReadAsStringAsync();
                //    return JsonConvert.DeserializeObject<T>(data);
                //}

                //throw new Exception(string.Format("{0},{1},{2},{3}", url, res.StatusCode, res.Content, baseUrl));

                if (res.StatusCode == HttpStatusCode.Unauthorized)
                {
                    throw new Exception(string.Format("{0},{1},{2},{3}", url, res.StatusCode, res.Content, baseUrl));
                }
                else
                {
                    var data = await res.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<T>(data);
                }
            }
        }
    }
}
