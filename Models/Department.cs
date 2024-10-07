﻿using System;
using System.Collections.Generic;

namespace LoadDB_Razor.Models
{
    public partial class Department
    {
        public Department()
        {
            Students = new HashSet<Student>();
        }

        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;

        public virtual ICollection<Student> Students { get; set; }
    }
}
