﻿namespace PiensaPeru.API.Domain.Models
{
    public class PercentageData
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string? Description { get; set; }
        public int ContentId { get; set; }
        public Content? Content { get; set; }
        public DataType? DataType { get; set; }
        public int DataTypeId { get; set; }

    }
}
