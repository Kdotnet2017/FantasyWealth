using System;
using FantasyWealth.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace FantasyWealth.Utilities
{
    public class iexTrading
    {
        public static async Task<string> getSymbolPriceAsync(string symbol)
        {
            string strPrice = null;
            var apiUrl = "https://api.iextrading.com/1.0/stock/{0}/price";
            apiUrl = string.Format(apiUrl, symbol);
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.BaseAddress = new Uri(apiUrl);
                HttpResponseMessage result = await client.GetAsync(apiUrl);
                if (result.IsSuccessStatusCode)
                {
                    strPrice = await result.Content.ReadAsAsync<string>();
                }
            }
            return strPrice;
        }
        public static string getSymbolPrice(string symbol)
        {
            var apiUrl = "https://api.iextrading.com/1.0/stock/{0}/price";
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
        public static async Task<LogoVM> getSymbolLogoAsync(string symbol)
        {
            LogoVM LogoUrl = null;
            var apiUrl = "https://api.iextrading.com/1.0/stock/{0}/logo";
            apiUrl = string.Format(apiUrl, symbol);
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.BaseAddress = new Uri(apiUrl);
                HttpResponseMessage result = await client.GetAsync(apiUrl);
                if (result.IsSuccessStatusCode)
                {
                    LogoUrl = await result.Content.ReadAsAsync<LogoVM>();
                }
            }
            return LogoUrl;
        }
        public static LogoVM getSymbolLogo(string symbol)
        {
            var apiUrl = "https://api.iextrading.com/1.0/stock/{0}/logo";
            apiUrl = string.Format(apiUrl, symbol);
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.BaseAddress = new Uri(apiUrl);
                HttpResponseMessage result = client.GetAsync(apiUrl).GetAwaiter().GetResult();
                if (result.IsSuccessStatusCode)
                {
                    var LogoUrl = result.Content.ReadAsAsync<LogoVM>().GetAwaiter().GetResult();
                    return LogoUrl;
                }
                else
                {
                    return null;
                }
            }
        }
        public static async Task<CompanyVM> getSymbolCompanyAsync(string symbol)
        {
            CompanyVM companyInfo = null;
            var apiUrl = "https://api.iextrading.com/1.0/stock/{0}/company";
            apiUrl = string.Format(apiUrl, symbol);
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.BaseAddress = new Uri(apiUrl);
                HttpResponseMessage result = await client.GetAsync(apiUrl);
                if (result.IsSuccessStatusCode)
                {
                    companyInfo = await result.Content.ReadAsAsync<CompanyVM>();
                }
            }
            return companyInfo;
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
        public static async Task<List<SymbolVM>> getTickerSymbolListAsync()
        {
            List<SymbolVM> lTickerSymbol = new List<SymbolVM>();
            var apiUrl = "https://api.iextrading.com/1.0/ref-data/symbols";
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.BaseAddress = new Uri(apiUrl);
                HttpResponseMessage result = await client.GetAsync(apiUrl);
                if (result.IsSuccessStatusCode)
                {
                    lTickerSymbol = await result.Content.ReadAsAsync<List<SymbolVM>>();
                    return lTickerSymbol;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}