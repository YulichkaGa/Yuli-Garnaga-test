using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer.Server;
using System.Collections.Generic;
using Yuli_Garnaga_test.Data;
using Yuli_Garnaga_test.Models;

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
        public async Task<IActionResult> GetAllQuestionsByTitle([FromRoute] string title)
        {
            var question = await _contextDb.Questions.Where(x => x.Title == title).ToListAsync();
            if (question == null)
            {
                return NotFound();
            }
            return Ok(question);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllQuestionsAnswers()
        {
            var query = (from q in _contextDb.Questions
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
        [HttpGet]
        public async Task<IActionResult> GetAnswerToTheQuestion()
        {
            var query = from question in _contextDb.Questions
                        join answer in _contextDb.Answers on question.Id equals answer.QId
                        join type in _contextDb.Types on question.TypeId equals type.Id
                        select new
                        {
                            QuestionId = question.Id,
                            QuestionDescription = question.Description_Q,
                            AnswerDescription = answer.Description
                        };
            var result = await query.ToListAsync();
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> AddCustomer([FromBody] Questions questionRequest)
        {

            await _contextDb.Questions.AddAsync(questionRequest);
            await _contextDb.SaveChangesAsync();
            return CreatedAtRoute( new { id = questionRequest.Id }, questionRequest);
        }
        [HttpGet]
        public async Task<IActionResult> GetIfAnswerIsCorrect(string answerName)
        {
            var query = from answer in _contextDb.Answers
                        where answer.Description.Contains(answerName)
                        select answer;
            var result = await query.ToListAsync();
            return Ok(result);

        }
    }
}



            
