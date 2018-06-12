using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PaginaInicial.Models;
namespace PaginaInicial.Controllers
{
    public class ItemController : ApiController
    {
        // GET: api/Item
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Item/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Item
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Item/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Item/5
        public IHttpActionResult Delete(int id)
        {
            UserList shoppingList = UserListController.Userlist[0];
            UserList dd = UserListController.lis;
         //   Item usuarios = UserListController.us[0];
           // int id2 = usuarios.Id;
            Item ss = dd.Items.FirstOrDefault(i => i.Id == id);
           // Item item = shoppingList.Items.FirstOrDefault(i => i.Id == id);
            //debo traer la lista
            if (ss == null)
            {
                return NotFound();
            }

            dd.Items.Remove(ss);

            return Ok(dd);


        }
    }
}
