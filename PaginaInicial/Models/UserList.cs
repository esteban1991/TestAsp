using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaginaInicial.Models
{
    public class UserList
    {

        public int ID { get; set; }
        public string Name { get; set; }
        public List<Item> Items{ get; set; }

        public UserList()
        {
            ID = 0;
            Name = string.Empty;
            Items = new List<Item>();
        }
    }
}