using System;

namespace ContosoPizza.Models
{
    #nullable enable
    public class Pizza
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public bool IsGlutenFree { get; set; }
    }
}