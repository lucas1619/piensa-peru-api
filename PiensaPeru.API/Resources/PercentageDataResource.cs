﻿using PiensaPeru.API.Domain.Models;

namespace PiensaPeru.API.Resources
{
    public class PercentageDataResource
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string? Description { get; set; }
        public int ContentId { get; set; }
        public string? DataType { get; set; }
    }
}
