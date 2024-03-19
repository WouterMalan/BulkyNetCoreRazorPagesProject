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
    public class Index : PageModel
    {
        private readonly ApplicationDbContext dbContext;
        public List<Category> CategoryList { get; set; }
        
        public Index(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void OnGet()
        {
            CategoryList = dbContext.Category.OrderBy(x => x.DisplayOrder).ToList();
        }
    }
}