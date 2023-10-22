using EntityFrameworkDemo.Db;
using EntityFrameworkDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Student2Controller : ControllerBase
    {
        private readonly DemoDbContext dbContext;

        public Student2Controller()
        {
            dbContext = new DemoDbContext();
        }

        [HttpPost]
        public async Task LoadSampleDataAsync()
        {
            Student s1 = new Student()
            {
                FirstName = "Vipin",
                LastName = "kumar PS",

                Address = new Address()
                {
                    Street = "123 Main Street",
                    City = "Cityville",
                    State = "ST",
                    PostalCode = "12345",
                    Country = "Countryland"
                },

                MarkList = new List<Mark>()
                {
                    new Mark() { Name = "Biology", MarkObtained = 100 },
                    new Mark() { Name = "Botany", MarkObtained = 100 }
                },

                TeamList = new List<Team>()
                {
                   new Team() {Name="Chess"},
                  new Team() {Name="Table Tennis"}
                }
            };


            Student s2 = new Student()
            {
                FirstName = "Vishnu",
                LastName = "kumar",
                Address = new Address()
                {
                    Street = "456 Elm Street",
                    City = "Townsville",
                    State = "TS",
                    PostalCode = "54321",
                    Country = "Otherland"
                },

                MarkList = new List<Mark>()
                {
                    new Mark() { Name = "Physics", MarkObtained = 90 },
                    new Mark() { Name = "Maths", MarkObtained = 95 }
                },

                TeamList = new List<Team>()
                {
                   new Team() {Name="Cricket"},
                  new Team() {Name="Football"}
                }
            };

            dbContext.Students.Add(s1);
            dbContext.Students.Add(s2);
            await dbContext.SaveChangesAsync();
        }

        [HttpGet]

        public async Task<List<StudentViewModel>> GetAllAsync()
        {


            List<Student> students = await dbContext.Students.Include(x => x.Address).ToListAsync();


            //List<StudentViewModel> studentViewModels = new List<StudentViewModel>();

            //foreach (var item in students)
            //{

            //    studentViewModels.Add( new StudentViewModel()
            //    {


            //        FirstName=item.FirstName,   
            //        LastName=item.LastName,
            //        Address= new Address()
            //        {
            //            City = item.Address.City,
            //            State = item.Address.State,
            //            PostalCode = item.Address.PostalCode,
            //            Street = item.Address.Street
            //        }
            //    });
            //}


            List<StudentViewModel> result = await dbContext.Students.Include(x => x.Address).Include(x=>x.MarkList).Select(item => new StudentViewModel()
            {
                FirstName = item.FirstName,
                LastName = item.LastName,
                Address = item.Address,
                MarkList=item.MarkList,

               Id=item.Id
            }).ToListAsync();


            return result;

        }

        [HttpPost("Addstudent")]
        public async Task<Student> AddStudent( [FromBody]Student student)
        {

             dbContext.Students.Add(student);  
            await dbContext.SaveChangesAsync();

            return student;
        }

        [HttpGet("GetStudent")]
        public async Task<Student> GetStudent(int id)
        {

            Student? student=await dbContext.Students.Where(x => x.Id == id).FirstOrDefaultAsync();


            return student;
        }

        [HttpPatch("UpdateStudent")]
        public async Task<Student> GetStudent(int id, Student student)
        {

            Student? oldStudent = await dbContext.Students.Where(x => x.Id == id).FirstOrDefaultAsync();

            if(oldStudent != null)
            {
                oldStudent.FirstName= student.FirstName;
                oldStudent.LastName= student.LastName;  
            }
            await dbContext.SaveChangesAsync();
            return student;
        }


        [HttpDelete("DeleteStudent")]
        public async Task<Student> DeleteStudent(int id)
        {

            Student? student = await dbContext.Students.Where(x => x.Id == id).FirstOrDefaultAsync();

            dbContext.Students.Remove(student);
            await dbContext.SaveChangesAsync();
            return student;
        }

    }
}
