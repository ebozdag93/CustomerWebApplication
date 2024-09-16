using CustomerWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Json;

namespace CustomerWebApp.Pages.Customers
{
    public class DetailsModel : PageModel
    {
        
        public Customer Customers { get; set; }
        public IActionResult OnGetAsync(int? itemid)
        {
            if(itemid == null)
                return NotFound();
           
            string requestStr = IndexModel.WebAPI_url() + "/" + itemid;
            var Client = new HttpClient();
            var task = Client.GetFromJsonAsync<Customer>(requestStr);
            Customers = task.Result;

            return Page();


        }
    }
}
