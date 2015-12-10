using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Web.Http;

namespace YrarbilBanckendTest.Classes
{
    static class HttpReq
    {

        static public async Task<string> http_get(Uri u)
        {
            HttpClient httpClient = new HttpClient();
            var httpHeaders = httpClient.DefaultRequestHeaders;
            if (!httpHeaders.UserAgent.TryParseAdd("YrarbilBackend-testclient"))
                throw new Exception("Invalid header value: YrarbilBackend - testclient");
            HttpResponseMessage httpRes = new HttpResponseMessage();
            string rt;
            try
            {
                httpRes = await httpClient.GetAsync(u);
                httpRes.EnsureSuccessStatusCode();
                rt = await httpRes.Content.ReadAsStringAsync();
            }
            catch (Exception e)
            {
                rt = "Error: " + e.HResult.ToString("X") + " Message: " + e.Message;
            }
            return rt;
        }

        static public async Task<string> http_post(Uri u, IHttpContent c)
        {
            HttpClient httpClient = new HttpClient();
            var httpHeaders = httpClient.DefaultRequestHeaders;
            if (!httpHeaders.UserAgent.TryParseAdd("YrarbilBackend-testclient"))
                throw new Exception("Invalid header value: YrarbilBackend - testclient");
            HttpResponseMessage httpRes = new HttpResponseMessage();
            string rt;
            try
            {
                httpRes = await httpClient.PostAsync(u, c);
                httpRes.EnsureSuccessStatusCode();
                rt = await httpRes.Content.ReadAsStringAsync();
            }
            catch (Exception e)
            {
                rt = "Error: " + e.HResult.ToString("X") + " Message: " + e.Message;
            }
            return rt;
        }
    }
}
