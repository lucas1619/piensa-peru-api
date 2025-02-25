﻿using System.ComponentModel.DataAnnotations;

namespace PiensaPeru.API.Resources.UserBoundedContextResources
{
    public class SavePlanResource
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public int Price { get; set; }
    }
}
