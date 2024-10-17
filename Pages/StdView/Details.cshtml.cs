﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LoadDB_Razor.Models;

namespace LoadDB_Razor.Pages.StdView
{
    public class DetailsModel : PageModel
    {
        private readonly LoadDB_Razor.Models.PRN221_DBContext _context;

        public DetailsModel(LoadDB_Razor.Models.PRN221_DBContext context)
        {
            _context = context;
        }

      public Student Student { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Students == null)
            {
                return NotFound();
            }

            var student = await _context.Students.FirstOrDefaultAsync(m => m.Id == id);
            if (student == null)
            {
                return NotFound();
            }
            else 
            {
                student.Depart = await _context.Departments.FirstOrDefaultAsync(m => m.Id == student.DepartId);
                Student = student;
            }
            return Page();
        }
    }
}
