﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    class Category
    {
        public string Name { get; set; }
        public string Description { get; set; }


        public void showCategories()
        {
            Console.WriteLine("NAME: " + Name);
            Console.WriteLine("DESCRIPTION: " + Description);
        }
    }
}
