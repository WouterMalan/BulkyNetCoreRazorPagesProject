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
    public class Create : PageModel
    {
       private readonly ApplicationDbContext dbContext;

        public Category Category { get; set; }

        public Create(ApplicationDbContext dbContext)
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
                dbContext.Category.Add(Category);
                dbContext.SaveChanges();
                TempData["Success"] = "Category created successfully";

                return RedirectToPage("Index");
            }

            return Page();
        }
    }
}