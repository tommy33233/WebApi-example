using System.Collections.Generic;
using System.Data.Entity;
using System.Web.Http;
using WebApiApp.Models;
using WebApiApp.EF;

namespace WebApiApp.Controllers
{
    public class ValuesController : ApiController
    {
        TestContext db = new TestContext();

        public IEnumerable<Country> GetCountries()
        {
            return db.Countries;
        }

        public Country GetCountry(int id)
        {
            Country country = db.Countries.Find(id);
            return country;
        }

        [HttpPost]
        public void CreateCountry([FromBody]Country country)
        {
            db.Countries.Add(country);
            db.SaveChanges();
        }

        [HttpPut]
        public void EditCountry(int id, [FromBody]Country country)
        {
            if (id == country.CountryId)
            {
                db.Entry(country).State = EntityState.Modified;

                db.SaveChanges();
            }
        }

        public void DeleteCountry(int id)
        {
            Country country = db.Countries.Find(id);
            if (country != null)
            {
                db.Countries.Remove(country);
                db.SaveChanges();
            }
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
