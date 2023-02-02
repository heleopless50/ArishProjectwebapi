using ArishProject.Dtos;
using ArishProject.Entities;

namespace ArishProject
{
    public static class Extentions
    {
        public static StudentDto AsDto(this Student student)
        {
            return new StudentDto
            {
                NameAr = student.NameAr,
                NameEn = student.NameEn,
                Id = student.Id,
                Department = student.Department,
                Grade = student.Grade
            };
        }
    }
}
