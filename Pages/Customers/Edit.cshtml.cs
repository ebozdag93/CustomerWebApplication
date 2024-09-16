using CustomerWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CustomerWebApp.Pages.Customers
{
    public class EditModel : PageModel
    {
       

        [BindProperty] //
        public Customer Customers { get; set; }

        public async Task<ActionResult> OnGetAsync(int? itemid)
        {
            if ( itemid == null)
            {
                return NotFound();
            }

            string requestStr = IndexModel.WebAPI_url() + "/" + itemid;
            var Client = new HttpClient();
            var task = Client.GetFromJsonAsync<Customer>(requestStr);
            Customers = task.Result;

            return Page();

        }

        public IActionResult OnPostAsync()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
            string requestStr = "http://localhost:5146/Customer";
            var Client = new HttpClient();
            var task = Client.PutAsJsonAsync(requestStr, Customers);
            var str = task.Result.Content.ReadAsStringAsync();
            return RedirectToPage(nameof(Index));

        }
    }
}
