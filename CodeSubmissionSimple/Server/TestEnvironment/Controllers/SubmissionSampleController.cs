﻿using AutoMapper;
using CodeSubmissionSimple.Server.TestEnvironment;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodeSubmissionSampleSimple.Server.TestEnvironment
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubmissionSampleController : ControllerBase
    {
        private readonly IWorkOfUnit _workOfUnit;

        public SubmissionSampleController(IWorkOfUnit workofUnit)
        {
            _workOfUnit = workofUnit;
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

        // GET api/<AnswersController>/nid=1
        [HttpGet("emai={userEmail}")]
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

        // Post api/<AnswersController>
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
    }
}