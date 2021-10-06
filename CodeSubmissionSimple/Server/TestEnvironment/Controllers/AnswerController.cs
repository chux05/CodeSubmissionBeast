using AutoMapper;
using CodeSubmissionSimple.Server.TestEnvironment;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodeSubmissionSimple.Server.TestEnvironment
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswerController : ControllerBase
    {
        private readonly IWorkOfUnit _workofUnit;

        public AnswerController(IWorkOfUnit unitOfWork)
        {
            _workofUnit = unitOfWork;
        }

        // GET: api/<AnswersController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAnswers()
        {
            try
            {
                var Answers = await _workofUnit.Answers.GetAll();
             
                return Ok(Answers);

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        // GET api/<AnswersController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAnswer(int id)
        {
            try
            {
                var Answer = await _workofUnit.Answers.Get(q => q.Id == id);
                return Ok(Answer);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        // GET api/<AnswersController>/nid=1
        [HttpGet("nid={submissionid}")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAnswersForSubmission(int submissionid)
        {
            try
            {
                var Answer = await _workofUnit.Answers.GetAll(q => q.SubmissionId == submissionid);
                return Ok(Answer);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        // GET api/<AnswersController>/5
        [HttpGet("range")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateAnswers(IList<Answer> answers)
        {
            if (!ModelState.IsValid)
            {

                return BadRequest(ModelState);
            }
            try
            {
                await _workofUnit.Answers.InsertRange(answers);
                await _workofUnit.Save();

                return CreatedAtAction("GetAnswersForSubmission", new { id = answers[0].SubmissionId}, answers);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        // POST api/<AnswersController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateAnswer([FromBody] Answer Answer)
        {

            if (!ModelState.IsValid)
            {

                return BadRequest(ModelState);
            }


            try
            {

                await _workofUnit.Answers.Insert(Answer);
                await _workofUnit.Save();

                return CreatedAtAction("GetAnswer", new { id = Answer.Id }, Answer);

            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    e.InnerException);
            }


        }


        // PUT api/<AnswersController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAnswer(int id, [FromBody] Answer Answer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var originalAnswer = await _workofUnit.Answers.Get(q => q.Id == id);

                if (originalAnswer == null)
                {
                    return BadRequest("Submitted data is invalid");
                }
                _workofUnit.Answers.Update(originalAnswer);
                await _workofUnit.Save();

                return NoContent();

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }

        }


        // DELETE api/<AnswersController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteAnswer(int id)
        {
            if (id < 1)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var Answer = await _workofUnit.Answers.Get(q => q.Id == id);

                if (Answer == null)
                {
                    return BadRequest("Submitted data is invalid");
                }

                await _workofUnit.Answers.Delete(id);
                await _workofUnit.Save();

                return NoContent();


            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }

        }
    }
}
