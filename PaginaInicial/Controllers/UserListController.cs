using PaginaInicial.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Bogus;

namespace PaginaInicial.Controllers
{
    public class UserListController : ApiController
    {

       // public static List<Item> us;
        public static Faker<UserList> lis;

        public static List<UserList> Userlist = new List<UserList>
        {
            //just an example of a list
            new UserList() { ID= 0, Name = "Users", Items = {
                    new Item { Id = 0, Name = "Mike", UserListId = 0 },
                    new Item { Id = 1, Name = "Tom", UserListId = 0 },
                    new Item { Id = 2, Name = "Esteban", UserListId = 0 }
                }
            },
            new UserList() { ID = 1, Name = "Hardware" }
        };
        // GET: api/UserLisr
       public IHttpActionResult Get(int id)
        {


            var Items = new Faker<Item>()
            .StrictMode(false)
            .CustomInstantiator(f => new Item())
            .Rules((f, o) =>
            {
                o.Id = f.Random.Number(10, 30);
                o.Name = f.Name.LastName();
                o.Price = f.Random.Number(30, 50);
                o.ImagenUrl = f.Image.Image();
                o.UserListId = 0;


            });
            //20 persons
            var item = Items.Generate(20);


            var Lists = new Faker<UserList>()
           .StrictMode(false)
           .CustomInstantiator(f => new UserList())
           .Rules((f, o) =>
           {
               o.ID = 0;
               o.Name = f.Name.LastName();
               o.Items = item;


           });
            //only 1 list
            var item2 = Lists.Generate(1).FirstOrDefault(s => s.ID == id);

            //if is not null
            if (item2 == null)
            {
                return NotFound();

            }
            //get the list with the persons -- go to ajax
           // us = item;
            lis = Lists;
            return Ok(item2);
        }


        //    UserList result =
        //        shoppingLists.FirstOrDefault(s => s.ID == id);

        //    if (result == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(result);
        //}



        // POST: api/UserList
        public IEnumerable Post([FromBody]UserList newList)
        {
            newList.ID = Userlist.Count;
            Userlist.Add(newList);

            return Userlist;
        }

        // PUT: api/UserList/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/UserList/5
        public void Delete(int id)
        {
        }
    }
}
