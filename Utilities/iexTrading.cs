using System;
using FantasyWealth.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

namespace FantasyWealth.Utilities
{
    public class iexTrading
    {
        public static string getSymbolPrice(string symbol)
        {
            var apiUrl = "https://api.iextrading.com/1.0/stock/{0}/price ";
            apiUrl = string.Format(apiUrl, symbol);
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.BaseAddress = new Uri(apiUrl);
                HttpResponseMessage result = client.GetAsync(apiUrl).GetAwaiter().GetResult();
                if (result.IsSuccessStatusCode)
                {
                    var strPrice = result.Content.ReadAsAsync<string>().GetAwaiter().GetResult();
                    return strPrice;
                }
                else
                {
                    return "";
                }
            }
        }

        public static List<ChartVM> getSymbolChart(string symbol)
        {
            var apiUrl = "https://api.iextrading.com/1.0/stock/{0}/chart/3m";
            apiUrl = string.Format(apiUrl, symbol);
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.BaseAddress = new Uri(apiUrl);
                HttpResponseMessage result = client.GetAsync(apiUrl).GetAwaiter().GetResult();
                if (result.IsSuccessStatusCode)
                {
                    var lChart = result.Content.ReadAsAsync<List<ChartVM>>().GetAwaiter().GetResult();
                    return lChart;
                }
                else
                {
                    return null;
                }

            }
        }
        public static CompanyVM getSymbolCompany(string symbol)
        {
            CompanyVM company = new CompanyVM();
            var apiUrl = "https://api.iextrading.com/1.0/stock/{0}/company";
            apiUrl = string.Format(apiUrl, symbol);
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.BaseAddress = new Uri(apiUrl);
                HttpResponseMessage result = client.GetAsync(apiUrl).GetAwaiter().GetResult();
                if (result.IsSuccessStatusCode)
                {
                    var data = result.Content.ReadAsAsync<CompanyVM>().GetAwaiter().GetResult();
                    company = data;
                }
            }
            return company;
        }
    }
}