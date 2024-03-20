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
    [BindProperties]
    public class Delete : PageModel
    {
        private readonly ApplicationDbContext dbContext;

        public Category Category { get; set; }

        public Delete(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void OnGet(int? id)
        {
            if (id != null && id != 0)
            {
                Category = dbContext.Category.Find(id);
            }
        }

        public IActionResult OnPost()
        {
            var category = dbContext.Category.Find(Category.Id);

            if (category == null)
            {
                return NotFound();
            }

            dbContext.Category.Remove(category);
            dbContext.SaveChanges();
            TempData["Success"] = "Category deleted successfully";

            return RedirectToPage("Index");
        }
    }
}