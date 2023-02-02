using System.ComponentModel.DataAnnotations;

namespace ArishProject.Dtos
{

        public record UpdateStudentDto
        {

            public string? NameEn { get; init; }
            [Required]
            public string NameAr { get; init; }
            [Required]

            public string Id { get; init; }
            [Required]
            public string Grade { get; init; }
            [Required]
            public string Department { get; set; }
        }
    
}
