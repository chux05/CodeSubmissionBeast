using AutoMapper;
using CodeSubmissionSimple.Server.TestEnvironment;
using CodeSubmissionSimple.Server.TestEnvironment.IRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeSubmissionSampleSimple.Server.TestEnvironment
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubmissionSampleController : ControllerBase
    {
        private readonly IWorkOfUnit _workOfUnit;
        private readonly ISampleTest test;
        private readonly AppDbContext context;

        public SubmissionSampleController(IWorkOfUnit workofUnit, ISampleTest test, AppDbContext context)
        {
            _workOfUnit = workofUnit;
            this.test = test;
            this.context = context;
        }

        // GET: api/<SubmissionSamplesController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetSubmissionSamples()
        {
            try
            {
                var SubmissionSamples = await _workOfUnit.SubmissionSamples.GetAll();
             
                return Ok(SubmissionSamples);

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpGet("email")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<HashSet<string>> GetSubmissionsPerEmail()
        {
            try
            {
                var SubmissionSamples = await _workOfUnit.SubmissionSamples.GetAll();

                HashSet<string> df = new HashSet<string>();
                foreach (var sub in SubmissionSamples)
                {
                    df.Add(sub.UserEmail);
                }
                
                return df;

            }
            catch (Exception e)
            {
                return null;
            }
        }

        // GET api/<SubmissionSamplesController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetSingleSubmissionAnswer(int id)
        {
            try
            {
                var SubmissionSample = await _workOfUnit.SubmissionSamples.Get(q => q.Id == id);
                return Ok(SubmissionSample);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        // GET api/SubmissionSamplesController>/email=test@gmail.com
        [HttpGet("email={userEmail}")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAnswersOfCandidate(string userEmail)
        {
            try
            {
                var Answer = await _workOfUnit.SubmissionSamples.GetAll(q => q.UserEmail == userEmail);
                return Ok(Answer);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        // Post api/<SubmissionSamplesController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateAnswers([FromBody]List<SubmissionSample> answers)
        {
            if (!ModelState.IsValid)
            {

                return BadRequest(ModelState);
            }
            try
            {
                await _workOfUnit.SubmissionSamples.InsertRange(answers);
                await _workOfUnit.Save();

                return CreatedAtAction("GetAnswersOfCandidate", new { userEmail = answers[0].UserEmail}, answers);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        // DELETE api/<SubmissionsController>/5
        [HttpDelete("email={userEmail}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteSubmissions(string userEmail)
        {
           
            try
            {
                var submissions = await _workOfUnit.SubmissionSamples.GetAll(q => q.UserEmail == userEmail);

                if (submissions == null)
                {
                    return BadRequest("Submitted data is invalid");
                }

                 _workOfUnit.SubmissionSamples.DeleteRange(submissions);
                await _workOfUnit.Save();

                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }

        }


        //get unique submissions by email
        [HttpGet("user")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetDistinctUsers()
        {
             try
            {               
                
                IQueryable<SubmissionSample> query = context.SubmissionSamples;

                var SubmissionSamples = (from p in query                             
                             select p.UserEmail).Distinct().ToList();

                return Ok(SubmissionSamples);
          
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

    }
}
