using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PIO.Controllers.Api
{
    public class CategoryController : ApiController
    {
        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public IHttpActionResult Delete(int id)
        {
            var categoryInDb = Container.DbContext.Categories.SingleOrDefault(c => c.Id == id);
            if (categoryInDb != null)
            {
                Container.DbContext.Categories.Remove(categoryInDb);
                Container.DbContext.SaveChanges();
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

    }
}
