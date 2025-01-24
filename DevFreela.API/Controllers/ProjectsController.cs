using DevFreela.API.Entities;
using DevFreela.API.Models;
using DevFreela.API.Persistence;
using DevFreela.API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace DevFreela.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly DevFreelaDbContext _context;
        //Construtor
        public ProjectsController(DevFreelaDbContext context)
        {
            _context = context;
        }

        //Busca -> GET api/projects?/search=crm
        [HttpGet]
        public IActionResult Get(string search = "", int page =0, int size =3)
        {
            var projects = _context.Projects
                .Include(p => p.Client)
                .Include(p => p.Freelancer)
                //filtro
                .Where(p => !p.IsDeleted &&(search == "" || p.Title.Contains(search) 
                    || p.Description.Contains(search)))
                //Paginação
                .Skip(page * size)
                .Take(size)
                .ToList();

            var model = projects.Select(ProjectItemViewModel.FromEntity).ToList();

            return Ok(model);
        }

        //Busca -> api/projects/1234(id)
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var project = _context.Projects
                .Include(p => p.Client)
                .Include(p => p.Freelancer)
                .Include(p => p.Comments)
                .SingleOrDefault(p => p.Id == id);

            var model = ProjectViewModel.FromEntity(project);

            return Ok(model);
        }

        //Cadastro -> Post api/projects
        [HttpPost]
        public IActionResult Post(CreateProjectInputModel model)
        {
            var project = model.ToEntity();

            _context.Projects.Add(project);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = 1 }, model);
        }

        //Atualizar -> PUT api/project/1234(id)
        [HttpPut]
        public IActionResult Put(int id, UpdateProjectModel model)
        {
            var project = _context.Projects
                .SingleOrDefault(p => p.Id == id);

            if (project is null)
            {
                return NotFound();
            }

            project.Update(model.Title, model.Description, model.TotalCOst);
            _context.Projects.Update(project);
            _context.SaveChanges();
            return NoContent();
        }

        //Deletar -> Delete api/project/1234(id)
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var project = _context.Projects
                .SingleOrDefault(p => p.Id == id);

            if (project is null)
            {
                return NotFound();
            }
            project.SetAsDeleted();
            _context.Projects.Update(project);
            _context.SaveChanges();

            return NoContent();
        }


        //Atualizar -> PUT api/projects1234/start
        [HttpPut("{id}/start")]
        public IActionResult Start(int id)
        {
            var project = _context.Projects
                .SingleOrDefault(p => p.Id == id);

            if (project is null)
            {
                return NotFound();
            }
            project.Start();
            _context.Projects.Update(project);
            _context.SaveChanges();

            return NoContent();
        }

        //Atualizar -> PUT api/projects1234/complete
        [HttpPut("{id}/complete")]
        public IActionResult Complete(int id)
        {
            var project = _context.Projects
                .SingleOrDefault(p => p.Id == id);

            if (project is null)
            {
                return NotFound();
            }
            project.Complete();
            _context.Projects.Update(project);
            _context.SaveChanges();
            return NoContent();
        }

        //Cadastro -> POST api/projects/1234/comments
        [HttpPost("{id}/comments")]
        public IActionResult PostComment(int id, CreateProjectCommentInputModel model)
        {
            var project = _context.Projects
                .SingleOrDefault(p => p.Id == id);

            if (project is null)
            {
                return NotFound();
            }
            var comment = new ProjectComment(model.Content, model.IdProject, model.IdUser);

            _context.ProjectComments.Add(comment);
            _context.SaveChanges();

            return Ok();
        }


    }
}
