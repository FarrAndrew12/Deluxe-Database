using System;
using System.Collections.Generic;

namespace DatabaseDeluxe.Models
{
    public partial class StudentId
    {
        public int Id { get; set; }
        public string? StudentName { get; set; }
        public string? HomeTown { get; set; }
        public string? FavFood { get; set; }
    }
}
