using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BulkyWeb_RazorProject.Data;
using BulkyWeb_RazorProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace BulkyWeb_RazorProject.Pages.Categories
{
    public class Edit : PageModel
    {
       private readonly ApplicationDbContext dbContext;

        public Category Category { get; set; }

        public Edit(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                dbContext.Update(Category);
                dbContext.SaveChanges();

                return RedirectToPage("Index");
            }

            return Page();
        }
    }
}