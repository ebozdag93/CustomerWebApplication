using CustomerWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CustomerWebApp.Pages.Customers
{
    public class DeleteModel : PageModel
    {
        

        [BindProperty] //
        public Customer Customers { get; set; }
        public IActionResult OnGet(int? itemid)
        {
            if ( itemid == null)
            {
                return NotFound();
            }
            string requestStr = "http://localhost:5146/Customer" + "/" + itemid;
            var Client = new HttpClient();
            var task = Client.GetFromJsonAsync<Customer>(requestStr);
            Customers = task.Result;

            return Page();
            

        }
        public IActionResult OnPost(int? itemid)
        {
            if (itemid == null ) { return NotFound(); }

            string requestStr = IndexModel.WebAPI_url() + "/" + itemid;
            var Client = new HttpClient();
            var task = Client.DeleteFromJsonAsync<Customer>(requestStr);
            return RedirectToPage(nameof(Index));

        }
    }
}
