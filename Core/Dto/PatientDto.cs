﻿using System;

namespace PracticeManagement.Core.Dto
{
    public class PatientDto
    {
        public int Id { get; set; }
        public string Token { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public byte CityId { get; set; }
        public CityDto Cities { get; set; }
        public int ProfesorId { get; set; }
        public ProfesorDto Profesor { get; set; }

        public DateTime DateTime { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
    }
}