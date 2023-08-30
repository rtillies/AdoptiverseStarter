using AdoptiverseAPI.DataAccess;
using AdoptiverseAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AdoptiverseAPI.Controllers
{
    [Route("/api/shelters")]
    [ApiController]
    public class SheltersController : ControllerBase
    {
        private readonly AdoptiverseApiContext _context;

        public SheltersController(AdoptiverseApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult GetShelters()
        {
            var shelters = _context
                .Shelters
                .Include(s => s.Pets)
                .ToList();

            return new JsonResult(shelters);
        }

        // The following endpoint will return pets for a specific shelter
        [HttpGet("{id}/pets")]
        public ActionResult GetShelterPets(int id)
        {
            var pets = _context
                .Pets
                .Include(p => p.Shelter)
                .Where(p => p.Shelter.Id == id);

            return new JsonResult(pets);
        }

        [HttpGet("{id}")]
        public ActionResult GetShelter(int id)
        {
            var shelter = _context
                .Shelters
                .Include(s => s.Pets)
                .Where(s => s.Id == id)
                .First();

            return new JsonResult(shelter);
        }

        [HttpPost]
        public void CreateShelter(Shelter shelter)
        {
            _context.Shelters.Add(shelter);
            _context.SaveChanges();

            Response.StatusCode = 204;

            return;
        }

        [HttpPatch]
        [Route("{id}")]
        public void UpdateShelter(Shelter shelter)
        {
            _context.Shelters.Update(shelter);
            _context.SaveChanges();

            Response.StatusCode = 204;

            return;
        }

        [HttpDelete]
        [Route("{id}")]
        public void DeleteShelter(int id)
        {
            var shelter = _context.Shelters.Find(id);
            _context.Shelters.Remove(shelter);

            _context.SaveChanges();
            Response.StatusCode = 204;

            return;
        }
    }
}