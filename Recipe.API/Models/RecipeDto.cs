using System;
using System.Collections.Generic;

namespace Recipe.API.Models
{
    public class RecipeDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Instruction { get; set; }
    }
}