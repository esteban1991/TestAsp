using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaginaInicial.Models
{
    public class Item
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string  ImagenUrl { get; set; }
        public bool Checked { get; set; }
        public  int UserListId { get; set; }

        public Item()
        {
            Id = 0;
            Name = string.Empty;
            Description = string.Empty;
            Price = 0;
            ImagenUrl = string.Empty;
            Checked = false;
            UserListId = -1;
        }
    }
}