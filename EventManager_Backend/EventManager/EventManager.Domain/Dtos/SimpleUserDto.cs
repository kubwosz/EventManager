using System;
using System.Collections.Generic;
using System.Text;

namespace EventManager.Domain.Dtos
{
    public class SimpleUserDto
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string Surname { get; set; }

        public  List<LectureUserDto> LectureUsers { get; set; }

        public List<EventUserDto> EventUsers { get; set; }

        public List<ReviewDto> Reviews { get; set; }

        public List<EventDto> Events { get; set; }
    }
}
