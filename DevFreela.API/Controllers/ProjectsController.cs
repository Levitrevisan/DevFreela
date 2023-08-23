using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DevFreela.API.Controllers
{
    [Route("api/projects")]
    public class ProjectsController : ControllerBase
    {
        // Utilizando uma configuração do sistema para configurar como o modelo vai se comportar. Neste caso, 
        // estou utilizando uma propriedade e hora de início e hora de fim permitida para a execussão do programa que está 
        // definida no appsetting.json que define que horas que o meu programa deve ser executado. esta propriedade pode ser
        // definida e posso configurar o projeto para, por exemplo, apenas utilizar quando o código estiver rodando em produção
        // mas desabilitada se o projeto estiver rodando em modo debug

        private readonly OpeningTimeOption _option;
        public ProjectsController(IOptions<OpeningTimeOption> option)
        {
            _option = option.Value;
        }

        // api/projects?query=net core
        [HttpGet]
        public IActionResult Get(string query)
        {
            // TODO Buscar todos ou filtrar
            return Ok();
        }


        // api/projects/3
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // TODO Buscar o projeto

            // TODO return NotFound();

            return Ok();
        }


        [HttpPost]
        public IActionResult Post([FromBody] CreateProjectModel createProject)
        {
            if (createProject.Title.Length > 50)
            {
                return BadRequest("Tamanho maior do que o permitido");
            }

            // TODO Cadastrar o projeto

            return CreatedAtAction(nameof(GetById), new { id = createProject.Id }, createProject);
        }

        // api/projects/2
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateProjectModel updateProject)
        {
            if (updateProject.Description.Length > 200)
            {
                return BadRequest("Tamanho do texto excede o limite");
            }

            // TODO Atualizo o objeto

            return NoContent();
        }

        // api/projects/3
        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {
            // TODO Buscar, se não existir, retorna NotFound. Se existir, deleta

            // TODO Remover
            return NoContent();

        }

        // api/projects/1/comments POST
        [HttpPost("{id}/comments")]

        public IActionResult PostComment(int id, [FromBody] CreateCommentModel createCommentModel)
        {
            // não faz sentido retornar o comentário criado, ou o projeto nesse caso. Portanto
            // retorno no content
            return NoContent();
        }

        // api/projects/{id}/start
        [HttpPut("{id}/start")]

        public IActionResult startProject(int id)
        {
            return NoContent();
        }

        // api/projects/{id}/finish
        [HttpPut("{id}/finish")]

        public IActionResult finishProject(int id)
        {
            return NoContent();
        }


    }

}
