using System.ComponentModel.DataAnnotations;

namespace ArishProject.Dtos
{
    public record CreateStudentDto
    {
        [Required]
        public string Id { get; init; }
       
        public string? NameEn { get; init; }
        [Required]
        public string? NameAr { get; init; }

        [Required]
        public string? Grade { get; init; }
        [Required]
        public string? Department { get; set; }
    }
}
