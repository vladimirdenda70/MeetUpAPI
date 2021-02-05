using AutoMapper;
using MeetUpAPI.Entites;
using MeetUpAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetUpAPI.Controllers
{
    [Route("api/meetup/{meetupName}/lecture")]

    public class LectureController:ControllerBase
    {
        private readonly MeetupContext _meetupContext;
        private readonly IMapper _mapper;

        public LectureController(MeetupContext meetupContext, IMapper mapper)
        {
            _meetupContext = meetupContext;
            _mapper = mapper;
        }

        public ActionResult Delete(string meetupName)
        {
            var meetup = _meetupContext.Meetups
              .Include(m => m.Lectures)
              .FirstOrDefault(m => m.Name.Replace(" ", "-").ToLower() == meetupName.ToLower());

            if (meetup == null)
            {
                return NotFound();
            }

            _meetupContext.Lectures.RemoveRange(meetup.Lectures);
            _meetupContext.SaveChanges();

            return NoContent();


        }

        [HttpGet]
        public ActionResult Get(string meetupName)
        {
            var meetup = _meetupContext.Meetups
              .Include(m => m.Lectures)
              .FirstOrDefault(m => m.Name.Replace(" ", "-").ToLower() == meetupName.ToLower());

            if (meetup == null)
            {
                return NotFound();
            }

            var lectures = _mapper.Map<List<LectureDto>>(meetup.Lectures);
            return Ok(lectures);
        }

        [HttpPost]
        public ActionResult Post(string meetupName, [FromBody] LectureDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var meetup = _meetupContext.Meetups
               .Include(m => m.Lectures)
               .FirstOrDefault(m => m.Name.Replace(" ", "-").ToLower() == meetupName.ToLower());

            if (meetup == null)
            {
                return NotFound();
            }

            var lecture = _mapper.Map<Lecture>(model);
            meetup.Lectures.Add(lecture);
            _meetupContext.SaveChanges();

            return Created($"api/meetup/{meetupName}",null);

        }
    }
}
