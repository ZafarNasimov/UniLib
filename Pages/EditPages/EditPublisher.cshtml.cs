using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Unilib.DatabaseUtil;
using Unilib.Models;

namespace Unilib.Pages.EditPages
{
    public class EditPublisherModel : PageModel
    {
        public Publisher publisher = new();
        public IActionResult OnGet(int id)
        {
            using (UnilibContext context = new())
            {
                publisher = context.Publishers.FirstOrDefault(a => a.Id == id);
                if (publisher == null)
                {
                    return RedirectToPage("/NotFound");
                }
            }
            return Page();
        }

        public IActionResult OnPost(int id)
        {
            using (UnilibContext context = new())
            {
                var publisher = context.Publishers.FirstOrDefault(a => a.Id == id);

                if (publisher == null)
                {
                    return RedirectToPage("/NotFound");
                }

                string name = Request.Form["Name"];
                string address = Request.Form["Address"];
                string contactInfo = Request.Form["ContactInfo"];

                publisher.Name = name;
                publisher.Address = address;
                publisher.Contact_Info = contactInfo;

                try
                {
                    context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return RedirectToPage("/Error");
                }
            }
            return RedirectToPage("/MainPages/Publisher");
        }
    }
}
