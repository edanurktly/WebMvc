﻿using System.ComponentModel.DataAnnotations;

namespace CoreMvc.Models.EmployeeDTO
{
    public class EmployeeUpdateDto
    {
        public int EmployeeId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Ad Alani Zorunludur")]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Soyad Alani Zorunludur")]

        public string LastName { get; set; } = null!;



        public string? Title { get; set; }

        public string? TitleOfCourtesy { get; set; }

        public DateTime? BirthDate { get; set; }

        public DateTime? HireDate { get; set; }

        public string? Address { get; set; }

        public string? City { get; set; }

        public string? Region { get; set; }

        public string? PostalCode { get; set; }

        public string? Country { get; set; }

        public string? HomePhone { get; set; }

        public string? Extension { get; set; }

        public string? Notes { get; set; }


    }
}