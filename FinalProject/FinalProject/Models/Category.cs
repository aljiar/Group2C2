﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FinalProject
{
    public class Category
    {
        [JsonProperty(Required = Required.Always)]
        public string Name { get; set; }
        [JsonProperty(Required = Required.Always)]
        public string Description { get; set; }


        public void showCategories()
        {
            Console.WriteLine("NAME: " + Name);
            Console.WriteLine("DESCRIPTION: " + Description);
        }
    }
}
