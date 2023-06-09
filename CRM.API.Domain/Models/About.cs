﻿using System.ComponentModel.DataAnnotations.Schema;

namespace CRM.API.Models
{
    [Table("About")]
    public class About
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Text { get; set; }
    }
}
