﻿using AutoMapper;
using MeetUpAPI.Entites;
using MeetUpAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetUpAPI
{
    public class MeetupProfile : Profile
    {
        public MeetupProfile()
        {
            CreateMap<Meetup, MeetupDetailsDto>()
                .ForMember(m => m.City, map => map.MapFrom(meetup => meetup.Location.City))
                .ForMember(m => m.PostCode, map => map.MapFrom(meetup => meetup.Location.PostCode))
                .ForMember(m => m.Street, map => map.MapFrom(meetup => meetup.Location.Street));

            CreateMap<MeetupDto, Meetup>();

            CreateMap<LectureDto, Lecture>()
                .ReverseMap();

          //  CreateMap<Lecture, LectureDto>();


        }

    }
}