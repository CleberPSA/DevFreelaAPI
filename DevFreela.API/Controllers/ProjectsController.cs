using DevFreela.API.Models;
using DevFreela.API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DevFreela.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {

        //Campo privado
        private readonly FreelanceTotalCostConfig _config;
        private readonly IConfigService _configService;

        //Construtor
        public ProjectsController(IOptions<FreelanceTotalCostConfig> options, 
            IConfigService configService)
        {
            _config = options.Value;
            _configService = configService;
        }

        //Busca -> GET api/projects?/search=crm
        [HttpGet]
        public IActionResult Get(string search = "")
        {
            return Ok(_configService.GetValues());
        }

        //Busca -> api/projects/1234(id)
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            throw new Exception();
 
            return Ok();
        }

        //Cadastro -> Post api/projects
        [HttpPost]
        public IActionResult Post(CreateProjectInputModel model)
        {
            if (model.TotalCost < _config.Minimun || model.TotalCost > _config.Maximun)
            {
                return BadRequest("Número fora dos limites");
            }

            return CreatedAtAction(nameof(GetById), new { id = 1 }, model);
        }

        //Atualizar -> PUT api/project/1234(id)
        [HttpPut]
        public IActionResult Put(int id, UpdateProjectModel model)
        {
            return NoContent();
        }

        //Deletar -> Delete api/project/1234(id)
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return NoContent();
        }


        //Atualizar -> PUT api/projects1234/start
        [HttpPut("{id}/start")]
        public IActionResult Start(int id)
        {
            return NoContent();
        }

        //Atualizar -> PUT api/projects1234/complete
        [HttpPut("{id}/complete")]
        public IActionResult Complete(int id)
        {
            return NoContent();
        }

        //Cadastro -> POST api/projects/1234/comments
        [HttpPost("{id}/comments")]
        public IActionResult PostComment(int id, CreateProjectCommentInputModel model)
        {
            return Ok();
        }


    }
}
