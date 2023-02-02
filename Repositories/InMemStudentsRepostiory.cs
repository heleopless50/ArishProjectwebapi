using ArishProject.Entities;
using Microsoft.AspNetCore.Http.Features;

namespace ArishProject.Repositories
{


    public class InMemStudentsRepostiory 
    {
        private readonly List<Student> students = new()
        {
            new Student{ NameAr="ahmed" , NameEn = "ahmed" , Id = "1234" , Department="geo" , Grade ="one"},
            new Student{  NameAr="mohamed" , NameEn = "mohamed" , Id = "2344" , Department="geo" , Grade ="two"},
        };
        public IEnumerable<Student> GetStudentsAsync()
        {
            return students;
        }
        public Student GetStudentAsync(string id)
        {
            return students.Where(student => student.Id == id).SingleOrDefault();
        }

        public void CreateStudentAsync(Student student)
        {
            students.Add(student);
        }

        public void UpdateStudentAsync(Student student)
        {
            var index = students.FindIndex(existingStudent => existingStudent.Id == student.Id);
            students[index] = student;
        }

        public void DeleteStudentAsync(string id)
        {
           var index = students.FindIndex(student => student.Id == id);
            students.Remove(students[index]);
        }
    }
}
