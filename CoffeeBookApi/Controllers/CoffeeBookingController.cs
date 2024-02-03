using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CoffeeBookApi.Models;
using CoffeeBookApi.Data;

namespace CoffeeBookApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CoffeeBookingController : ControllerBase
    {

        private readonly ApiContext _context;

        public CoffeeBookingController(ApiContext context)
        {
            _context = context;
        }

        //Create/Edit
        [HttpPost]
        public JsonResult CreateEdit(CoffeeBooking table)
        {
            if(table.Id == 0)
            {
                _context.Booking.Add(table);
            }
            else
            {
                var tableInDb = _context.Booking.Find(table.Id);

                if (tableInDb == null)
                    return new JsonResult(NotFound());

                tableInDb = table;
            }
            _context.SaveChanges();
            return new JsonResult(Ok(table));
        }

        // Get 
        [HttpGet]
        public JsonResult Get(int id)
        {
            var result = _context.Booking.Find(id);
            if (result == null)
                return new JsonResult(NotFound());
            return new  JsonResult(Ok(result));
        }
        //Delete
        [HttpDelete]
        public JsonResult Delete(int id)
        {
            var result = _context.Booking.Find(id);
            if (result == null)
                return new JsonResult(NotFound());

            _context.Booking.Remove(result);
            _context.SaveChanges();
            return new JsonResult(NoContent());
        }

        //Get 
        [HttpGet]
        public JsonResult GetAll()
        {
            var result = _context.Booking.ToList();
            return new JsonResult(Ok(result));

        }
    }
}
