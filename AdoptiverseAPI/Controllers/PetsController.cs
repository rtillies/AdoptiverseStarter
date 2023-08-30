using AdoptiverseAPI.DataAccess;
using AdoptiverseAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AdoptiverseAPI.Controllers
{
    [Route("/api/pets")]
    [ApiController]
    public class PetsController : ControllerBase
    {
        private readonly AdoptiverseApiContext _context;

        public PetsController(AdoptiverseApiContext context)
        {
            _context = context;
        }

        // The following enpoint will return pets regardless of Shelter
        [HttpGet]
        public ActionResult GetPets()
        {
            var pets = _context
                .Pets
                .Include(p => p.Shelter)
                .ToList();

            return new JsonResult(pets);
        }

        [HttpGet("{id}")]
        public ActionResult GetPet(int id)
        {
            var pet = _context
                .Pets
                .Include(p => p.Shelter)
                .Where(p => p.Id == id)
                .First();

            return new JsonResult(pet);
        }

        [HttpPost]
        public void CreatePet(Pet pet)
        {
            _context.Pets.Add(pet);
            _context.SaveChanges();

            Response.StatusCode = 204;

            return;
        }

        [HttpPatch]
        [Route("{id}")]
        public void UpdatePet(Pet pet)
        {
            _context.Pets.Update(pet);
            _context.SaveChanges();

            Response.StatusCode = 204;

            return;
        }

        [HttpDelete]
        [Route("{id}")]
        public void DeletePet(int id)
        {
            var pet = _context.Pets.Find(id);
            _context.Pets.Remove(pet);

            _context.SaveChanges();
            Response.StatusCode = 204;

            return;
        }
    }
}
