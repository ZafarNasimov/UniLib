using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Unilib.DatabaseUtil;

namespace Unilib.Pages.MainPages
{
    public class PublisherModel : PageModel
    {
        public IActionResult OnPostDelete(int id)
        {
            using (UnilibContext context = new())
            {
                var publisher = context.Publishers.Find(id);

                if (publisher == null)
                {
                    return NotFound();
                }

                context.Publishers.Remove(publisher);
                context.SaveChanges();
            }


            return RedirectToPage("/MainPages/Publisher");
        }
    }
}
