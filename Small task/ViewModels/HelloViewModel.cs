﻿using System.ComponentModel.DataAnnotations;

namespace Small_task.ViewModels
{
    public class HelloViewModel
    {
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
    }
}
