using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Yuli_Garnaga_test.Data;

namespace Yuli_Garnaga_test.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class QuestionsController : Controller
    {
        private readonly ContextDB _contextDb;

        public QuestionsController(ContextDB contextDb)
        {
            _contextDb = contextDb;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllQuestions()
        {
            var customers = await _contextDb.Questions.ToListAsync();
            return Ok(customers);
        }
        [HttpGet("{title}")]
        public async Task<IActionResult> GetQuestions([FromRoute] string title)
        {
            var question = await _contextDb.Questions.Where(x => x.Title == title).ToListAsync();
            if (question == null)
            {
                return NotFound();
            }
            return Ok(question);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllQAndA()
        {
            var query =  (from q in _contextDb.Questions
                         join a in _contextDb.Answers on q.Id equals a.QId

                         select new
                         {
                             q.Id,
                             q.Title,
                             q.Description_Q,
                             a.TypeId,
                             a.Description
                         });

            var all = await query.ToListAsync();

            return Ok(all);
        }
    }
}

