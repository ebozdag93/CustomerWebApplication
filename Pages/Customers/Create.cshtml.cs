using CustomerWebApp.Models;
using Microsoft.ApplicationInsights.Extensibility.Implementation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Text.Json;

namespace CustomerWebApp.Pages.Customers
{


    public class CreateModel : PageModel
    {
      

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty] //
        public Customer Customers { get; set; }

       
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid || Customers == null)
            {
                return Page();
            }
            string requestStr = IndexModel.WebAPI_url();
            var Client = new HttpClient();
            var task = Client.PostAsJsonAsync(requestStr, Customers);
            var str =  task.Result.Content.ReadAsStringAsync();
            return RedirectToPage(nameof(Index));

        }

    }
}
