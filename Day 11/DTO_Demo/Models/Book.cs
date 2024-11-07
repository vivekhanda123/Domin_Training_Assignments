﻿namespace DTO_Demo.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string? Genre { get; set; }

    }
    public record BookDTO(int Id, string Title, string Author, decimal Price);
}
