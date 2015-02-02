using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using EasyStitch.Data.Entities;

namespace EasyStitch.Api.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using EasyStitch.Data.DataModel;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<Color>("Colors");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class ColorsController : ODataController
    {
        private EasyStitchModelContainer db = new EasyStitchModelContainer();

        // GET: odata/Colors
        [EnableQuery]
        public IQueryable<Color> GetColors()
        {
            return db.Colors;
        }

        // GET: odata/Colors(5)
        [EnableQuery]
        public SingleResult<Color> GetColor([FromODataUri] int key)
        {
            return SingleResult.Create(db.Colors.Where(color => color.Id == key));
        }

        // PUT: odata/Colors(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<Color> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Color color = db.Colors.Find(key);
            if (color == null)
            {
                return NotFound();
            }

            patch.Put(color);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ColorExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(color);
        }

        // POST: odata/Colors
        public IHttpActionResult Post(Color color)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Colors.Add(color);
            db.SaveChanges();

            return Created(color);
        }

        // PATCH: odata/Colors(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<Color> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Color color = db.Colors.Find(key);
            if (color == null)
            {
                return NotFound();
            }

            patch.Patch(color);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ColorExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(color);
        }

        // DELETE: odata/Colors(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            Color color = db.Colors.Find(key);
            if (color == null)
            {
                return NotFound();
            }

            db.Colors.Remove(color);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ColorExists(int key)
        {
            return db.Colors.Count(e => e.Id == key) > 0;
        }
    }
}
