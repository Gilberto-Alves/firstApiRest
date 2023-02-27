using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using JornadaNet.Entities;
using JornadaNet.Models;
using JornadaNet.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace JornadaNet.Controllers
{
    [ApiController]
    [Route("api/shortnedLinks")]
    public class ShortnedLinkController : ControllerBase
    {
        private readonly DevEncurtaUrlDbContext _context;

        public ShortnedLinkController(DevEncurtaUrlDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get(){
            return Ok(_context.Links);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id) {
            var link = _context.Links.SingleOrDefault(l => l.Id == id);

            if(link == null) {
                return NotFound();
            }

            return Ok(link);
        }

        [HttpPost]
        public IActionResult Post([FromBody]AddOrUpdateShortenedLinkModel model){
            var link = new ShortnedCustomLink(model.Title, model.DestinationLink);
            
            _context.Links.Add(link);
            _context.SaveChanges();

            return CreatedAtAction("GetByid", new {id = link.Id}, link);
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromBody]int id, [FromBody]AddOrUpdateShortenedLinkModel model){

            var link = _context.Links.SingleOrDefault(l => l.Id == id);

            if(link == null) {
                return NotFound();
            }

            link.Update(model.Title, model.DestinationLink);

            _context.Links.Update(link);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id){

            var link = _context.Links.SingleOrDefault(l => l.Id == id);

            if(link == null) {
                return NotFound();
            }

            _context.Links.Remove(link);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpGet("/{code}")]
        public IActionResult RedirectLink(string code){
            var link = _context.Links.SingleOrDefault(l => l.Code == code);

            if(link == null) {
                return NotFound();
            }

            return Redirect(link.DestinationLink);
        }
    }
}