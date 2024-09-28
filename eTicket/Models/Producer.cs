﻿using eTicket.Data.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace eTicket.Models
{
    public class Producer :IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name ="Profile Picture")]
        public string ProfilePicture { get; set; }

        [Display(Name ="Full Name")]
        public string FullName { get; set; }

        [Display(Name ="Biography")]
        public string Bio { get; set; }

        //Relationships
        public List<Movie> Movies { get; set; }
    }
}
