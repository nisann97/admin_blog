﻿using System.ComponentModel.DataAnnotations;

namespace test.ViewModels.Blogs
{
    public class BlogEditVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Can't be empty")]
        [StringLength(20)]
        public string Title { get; set; }
        [Required(ErrorMessage = "Can't be empty")]
        [StringLength(20)]
        public string Description { get; set; }
        public string Image { get; set; }
        public DateTime Date { get; set; }
    }
}
