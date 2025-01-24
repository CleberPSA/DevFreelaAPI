using DevFreela.API.Entities;
using DevFreela.API.Models;
using DevFreela.API.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        private readonly DevFreelaDbContext _context;

        public SkillsController(DevFreelaDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            //var skills = _context.Skills.ToList();
            var skiils = _context.Skills
                .Where(s => !s.IsDeleted).ToList();

            if (skiils is null)
            {
                return NotFound();
            }


            var model = skiils.Select(SkillViewModel.FromEntity).ToList();


            return Ok(model);
        }


        [HttpPost]
        public IActionResult Post(CreateSkillInputModel model)
        {
            var skill = new Skill(model.Description);
            _context.Skills.Add(skill);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
