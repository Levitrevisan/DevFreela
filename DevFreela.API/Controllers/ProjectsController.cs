using DevFreela.Application.Commands.CreateComment;
using DevFreela.Application.Commands.CreateProject;
using DevFreela.Application.Commands.DeleteProject;
using DevFreela.Application.Commands.FinishProject;
using DevFreela.Application.Commands.StartProject;
using DevFreela.Application.Commands.UpdateProject;
using DevFreela.Application.Queries.GetAllProjects;
using DevFreela.Application.Services.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [Route("api/projects")]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectService _projectService;
        private readonly IMediator _mediator;

        public ProjectsController(IProjectService projectService, IMediator mediator)
        {
            _projectService = projectService;
            _mediator = mediator;
        }

        // api/projects?query=net core
        [HttpGet]
        public async Task<IActionResult> Get(string query)
        {
            var getAllProjectsQuery = new GetAllProjectsQuery(query);
            var projects = await _mediator.Send(getAllProjectsQuery);
            return Ok(projects);
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
        public async Task<IActionResult> Post([FromBody] CreateProjectCommand command)
        {
            if (command.Title.Length > 50)
            {
                return BadRequest("Tamanho maior do que o permitido");
            }
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }

        // api/projects/{id}/start
        [HttpPut("{id}/start")]

        public async Task<IActionResult> startProject(int id)
        {
            var command = new StartProjectCommand { Id = id };

            await _mediator.Send(command);

            return NoContent();
        }


        // api/projects/2
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] UpdateProjectCommand command, int id)
        {
            if (command.Description.Length > 200)
            {
                return BadRequest("Tamanho do texto excede o limite");
            }

            command.Id = id;

            await _mediator.Send(command);

            return NoContent();
        }

        // api/projects/3
        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteProjectCommand { Id = id };

            await _mediator.Send(command);

            return NoContent();

        }

        // api/projects/1/comments POST
        [HttpPost("{id}/comments")]

        public async Task<IActionResult> PostComment(int id, [FromBody] CreateCommentCommand command)
        {
            command.ProjectId = id;
            await _mediator.Send(command);

            return NoContent();
        }

        // api/projects/{id}/finish
        [HttpPut("{id}/finish")]

        public async Task<IActionResult> finishProject(int id)
        {
            var command = new FinishProjectCommand { Id = id };

            await _mediator.Send(command);

            return NoContent();
        }


    }

}
