﻿using System.ComponentModel.DataAnnotations;

namespace Projekt.Models
{
    public class DriverModel
    {
        public int Id { get; set; }
        public string? DriverId { get; set; }
        public string? UserName { get; set; }
        public string? Description { get; set; }
    }
}
