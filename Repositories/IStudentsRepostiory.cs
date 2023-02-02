using ArishProject.Entities;

namespace ArishProject.Repositories
{

        public interface IStudentsRepostiory
        {
            Task<Student> GetStudentAsync(string id);
            Task<IEnumerable<Student>> GetStudentsAsync();
            Task CreateStudentAsync(Student student);
            Task UpdateStudentAsync(Student student);
            Task DeleteStudentAsync(string id);
        
    }
}
