﻿using System;
using System.Collections.Generic;

namespace LoadDB_Razor.Models
{
    public partial class Student
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public bool Gender { get; set; }
        public string DepartId { get; set; } = null!;
        public DateTime? Dob { get; set; }
        public double Gpa { get; set; }

        public virtual Department? Depart { get; set; } = null!;
        
        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Gender: {Gender}, DepartId: {DepartId}, Dob: {Dob}, Gpa: {Gpa}";
        }
    }
}
