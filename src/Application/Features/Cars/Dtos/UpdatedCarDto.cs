﻿using Core.Security.Dtos;
using Domain.Enums;

namespace Application.Features.Cars.Dtos
{
    public class UpdatedCarDto : IDto
    {
        public int Id { get; set; }
        public int ModelId { get; set; }
        public CarState CarState { get; set; }
        public int Kilometer { get; set; }
        public short ModelYear { get; set; }
        public string Plate { get; set; }
    }
}
