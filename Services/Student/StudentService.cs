using LoadDB_Razor.Models;

namespace LoadDb.Services.StudentService{
    public class StudentService{
        public void CreateStudent(Student? student){
            if(student != null){
                if(PRN221_DBContext.Instance.Students.Find(student.Id) == null){
                    PRN221_DBContext.Instance.Students.Add(student);
                    PRN221_DBContext.Instance.SaveChanges();
                }
                else{
                    
                }
            }
        }
    }
}