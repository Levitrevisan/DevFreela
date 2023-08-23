using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DevFreela.API.Controllers
{
    [Route("api/projects")]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectsController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        // api/projects?query=net core
        [HttpGet]
        public IActionResult Get(string query)
        {
            var project = _projectService.GetAll(query);
            return Ok(project);
        }


        // api/projects/3
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var project = _projectService.GetById(id);

            if (project == null)
            {
                return NotFound();
            }

            return Ok(project);
        }


        [HttpPost]
        public IActionResult Post([FromBody] NewProjectInputModel newProject)
        {
            if (newProject.Title.Length > 50)
            {
                return BadRequest("Tamanho maior do que o permitido");
            }

            var id = _projectService.Create(newProject);

            return CreatedAtAction(nameof(GetById), new { id = id }, newProject);
        }

        // api/projects/2
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] UpdateProjectInputModel inputModel)
        {
            if (inputModel.Description.Length > 200)
            {
                return BadRequest("Tamanho do texto excede o limite");
            }

            _projectService.Update(inputModel);

            return NoContent();
        }

        // api/projects/3
        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {
            _projectService.Delete(id);            
            return NoContent();

        }

        // api/projects/1/comments POST
        [HttpPost("{id}/comments")]

        public IActionResult PostComment(int id, [FromBody] CreateCommentInputModel inputModel)
        {
            _projectService.CreateComment(inputModel);
            
            return NoContent();
        }

        // api/projects/{id}/start
        [HttpPut("{id}/start")]

        public IActionResult startProject(int id)
        {
            _projectService.Start(id);

            return NoContent();
        }

        // api/projects/{id}/finish
        [HttpPut("{id}/finish")]

        public IActionResult finishProject(int id)
        {

            _projectService.Finish(id);
            return NoContent();
        }


    }

}
