using CustomerWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.Json;
using Microsoft.Identity.Client;
using Newtonsoft.Json;
using static System.Net.WebRequestMethods;

namespace CustomerWebApp.Pages.Customers
{
    public class IndexModel : PageModel
    {
        public static string WebAPI_url()
        {
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            return config["WebAPI"];
        }
        public List<Customer> Customers { get; set; }
        public void OnGet()
        {
            string requestStr = IndexModel.WebAPI_url();
            var Client = new HttpClient();
            var task = Client.GetFromJsonAsync<List<Customer>>(requestStr);
            Customers = task.Result;
        }
    }
}
