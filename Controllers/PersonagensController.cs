using Microsoft.AspNetCore.Mvc;
using ProjetoDBZ.Data;
using ProjetoDBZ.Models;
using Microsoft.EntityFrameworkCore;

namespace ProjetoDZ.Controllers
{
    [ApiController] //indica que é um controlador de API
    [Route ("api/[controller]")] //endpoint

    public class PersonagensController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;


        public PersonagensController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpPost]
        public async Task<IActionResult> AddPersonagem([FromBody] Personagem personagem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _appDbContext.DBZ.Add(personagem);
            await _appDbContext.SaveChangesAsync();

            return Created("Personagem adicionado com sucesso!", personagem);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Personagem>>> GetPersonagens()
        {
            var personagens = await _appDbContext.DBZ.ToListAsync();

            return Ok(personagens);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Personagem>> GetPersonagem(int id)
        {
            var personagem = await _appDbContext.DBZ.FindAsync(id);

            if (personagem == null)
            {
                return NotFound("Personagem não encontrado");
            }

            return Ok(personagem);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePersonagem(int id, [FromBody] Personagem personagemAtualizado)
        {
            var personagemExistente = await _appDbContext.DBZ.FindAsync(id);

            if (personagemExistente == null)
            {
                return NotFound("Personagem não encontrado");
            }

            _appDbContext.Entry(personagemExistente).CurrentValues.SetValues(personagemAtualizado);

            await _appDbContext.SaveChangesAsync();

            return StatusCode(201, personagemExistente);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersonagem(int id)
        {
            var personagem = await _appDbContext.DBZ.FindAsync(id);

            if (personagem == null)
            {
                return NotFound("Personagem não encontrado");
            }

            _appDbContext.DBZ.Remove(personagem);

            await _appDbContext.SaveChangesAsync();

            return Ok("Personagem deletado com sucesso.");
        }

    }
}