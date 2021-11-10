using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Razor_UI.Pages
{
    public class EditModel : PageModel
    {
        public PubsServiceBus.ServiceBus _service;

        [BindProperty]
        public Model.Author Author { get; set; }

        public EditModel(PubsServiceBus.ServiceBus service)
		{
            _service = service;
		}

        public void OnGet(string aid)
        {
            Author = _service.FindAuthor(aid);
        }

        public IActionResult OnPost()
		{
            if(ModelState.IsValid)
			{
                _service._auRepo.Update(Author);

                return RedirectToPage("Index");
            }

            return Page();
		}
    }
}
