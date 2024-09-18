using System;
using System.ComponentModel.DataAnnotations;

namespace eTicket.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        
        public string MovieName { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ImgUrl { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public MovieCategotry MovieCategory { get; set; }

    }
}
