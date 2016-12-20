using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.Azure.Mobile.Server;
using MobileBackend.DataObjects;
using MobileBackend.Models;

namespace MobileBackend.Controllers
{
    public class RideController : TableController<Ride>
    {
        MobileServiceContext context;

        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            context = new MobileServiceContext();
            DomainManager = new EntityDomainManager<Ride>(context, Request);
        }

        // GET tables/Ride
        [QueryableExpand("Driver,Passengers")]
        public IQueryable<Ride> GetAllRide()
        {
            return Query(); 
        }

        // GET tables/Ride/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<Ride> GetRide(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/Ride/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<Ride> PatchRide(string id, Delta<Ride> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/Ride
        public async Task<IHttpActionResult> PostRide(Ride item)
        {
            if (item.Driver != null)
            {
                if (context.Entry(item.Driver).State == System.Data.Entity.EntityState.Detached)
                    context.Users.Attach(item.Driver);
            }

            if (item.Passengers != null && item.Passengers.Any())
            {
                foreach (var passenger in item.Passengers)
                {
                    if (context.Entry(passenger).State == System.Data.Entity.EntityState.Detached)
                        context.Users.Attach(passenger);
                }
            }
                
            Ride current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/Ride/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteRide(string id)
        {
             return DeleteAsync(id);
        }
    }
}
