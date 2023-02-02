using ArishProject.Context;
using ArishProject.Entities;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ArishProject.Repositories
{
    public class MongoDbStudentsRepository : IStudentsRepostiory
    {
        private const string databaseName = "ArishDatabase";
        private const string collectionName = "studentsData";
        private readonly IMongoCollection<Student> studentsCollection;
        private readonly FilterDefinitionBuilder<Student> filterBuilder = Builders<Student>.Filter;
        
        public MongoDbStudentsRepository(IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase(databaseName);
            studentsCollection = database.GetCollection<Student>(collectionName);
        }
        public async Task CreateStudentAsync(Student student)
        {
            await studentsCollection.InsertOneAsync(student);
        }

        public async Task DeleteStudentAsync(string id)
        {
            var filter = filterBuilder.Eq(s => s.Id, id);
            await studentsCollection.DeleteOneAsync(filter);
        }


        public async Task<Student> GetStudentAsync(string id)
        {
            var filter = filterBuilder.Eq(s =>s.Id , id);
             var student = await studentsCollection.Find(filter).FirstOrDefaultAsync();
        
        //var student = studentsCollection.Find(new BsonDocument()).ToList().Find(a => a.Id == id);
            return student;
        }

  
        public async Task<IEnumerable<Student>> GetStudentsAsync()
        {
            return await studentsCollection.Find(new BsonDocument()).ToListAsync(); 
        }
   
        public async Task UpdateStudentAsync(Student student)
        {
           var filter = filterBuilder.Eq(existingStudent => existingStudent.Id, student.Id);
           await studentsCollection.ReplaceOneAsync(filter, student);
            
        }
    }

    public class SqlDbRepository : IStudentsRepostiory
    {
        private ArishContext _arishContext;
        public SqlDbRepository(ArishContext arishContext) {
            this._arishContext = arishContext;
        }
        public Task CreateStudentAsync(Student student)
        {
            throw new NotImplementedException();
        }

        public Task DeleteStudentAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<Student> GetStudentAsync(string id)
        {
            var student = await _arishContext.Students.FindAsync(id);
            if (student != null)
            {

            return student;
            }
            return null;
        }

        public async Task<IEnumerable<Student>> GetStudentsAsync()
        {
            return await _arishContext.Students.ToListAsync();

        }

        public Task UpdateStudentAsync(Student student)
        {
            throw new NotImplementedException();
        }
    }
}
