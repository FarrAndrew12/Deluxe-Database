using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseDeluxe.Models;

namespace DatabaseDeluxe
{
    class StudentCrud
    {
        StudentDataContext db = new StudentDataContext();   
        public List<StudentId> GetStudent()
        {
            return db.StudentIds.ToList();
        }
        public StudentId GetStudent(int id)
        {
            StudentId output = new StudentId();
            if(output != null)
            {
                return output;
            }
            else
            {
                StudentId errorSID = new StudentId();
                errorSID.StudentName = $"Sorry no student found in database at id {id}";
                return errorSID;
            }
        }

        public void CreateStudent(StudentId D)
        {
            db.StudentIds.Add(D);
            db.SaveChanges();
        }

        public void DeleteStudent(int id)
        {
            StudentId studentToRemove = GetStudent(id);
      
                db.StudentIds.Remove(studentToRemove);
                db.SaveChanges();
            
        }
    }
}
