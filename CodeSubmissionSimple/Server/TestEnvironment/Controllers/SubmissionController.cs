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
    public class SubmissionController : ControllerBase
    {
        private readonly IWorkOfUnit _unitOfWork;

        public SubmissionController(IWorkOfUnit workofUnit)
        {
            _unitOfWork = workofUnit;
        }

        // GET: api/<SubmissionsController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetSubmissions()
        {
            try
            {
                var Submissions = await _unitOfWork.Submissions.GetAll();
             
                return Ok(Submissions);

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        // GET api/<SubmissionsController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetStatus(int id)
        {
            try
            {
                var Submission = await _unitOfWork.Submissions.Get(q => q.Id == id);
                return Ok(Submission);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        // POST api/<SubmissionsController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateStatus([FromBody] Submission submission)
        {

            if (!ModelState.IsValid)
            {

                return BadRequest(ModelState);
            }


            try
            {

                await _unitOfWork.Submissions.Insert(submission);
                await _unitOfWork.Save();

                return CreatedAtAction("GetStatus", new { id = submission.Id }, submission);

            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    e.InnerException);
            }


        }


        // PUT api/<SubmissionsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStatus(int id, [FromBody] Submission submission)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var originalStatus = await _unitOfWork.Submissions.Get(q => q.Id == id);

                if (originalStatus == null)
                {
                    return BadRequest("Submitted data is invalid");
                }
                _unitOfWork.Submissions.Update(originalStatus);
                await _unitOfWork.Save();

                return NoContent();

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }

        }


        // DELETE api/<SubmissionsController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteStatus(int id)
        {
            if (id < 1)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var submission = await _unitOfWork.Submissions.Get(q => q.Id == id);

                if (submission == null)
                {
                    return BadRequest("Submitted data is invalid");
                }

                await _unitOfWork.Submissions.Delete(id);
                await _unitOfWork.Save();

                return NoContent();


            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }

        }
    }
}
