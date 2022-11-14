using System.Data;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;

namespace StudentManagement.Models
{
    public class StudentDataAccessLayer
    {
        string connectionString = "Data Source=INBAWN170240\\SQLEXPRESS;Initial Catalog=StudentDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        //To View all student details    
        public IEnumerable<Student> GetAllStudents()
        {
            List<Student> lststudent = new List<Student>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetAllStudents", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Student student = new Student();

                    student.ID = Convert.ToInt32(rdr["StudentID"]);
                    student.Name = rdr["StudentName"].ToString();
                    student.Age = rdr["StudentAge"].ToString();
                    student.Gender = rdr["StudentGender"].ToString();
                    student.Department = rdr["StudentDepartment"].ToString();
                    student.CreateDate = Convert.ToDateTime(rdr["StudentCreateDate"]);

                    lststudent.Add(student);
                }
                con.Close();
            }
            return lststudent;
        }

        //To Add new employee record    
        public void AddStudent(Student student)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("AddStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@StudentName", student.Name);
                cmd.Parameters.AddWithValue("@StudentAge", student.Age);
                cmd.Parameters.AddWithValue("@StudentDOB", student.DOB);
                cmd.Parameters.AddWithValue("@StudentGender", student.Gender);
                cmd.Parameters.AddWithValue("@StudentPhone", student.Phone);
                cmd.Parameters.AddWithValue("@StudentEmail", student.Email);
                cmd.Parameters.AddWithValue("@StudentAddress", student.Address);
                cmd.Parameters.AddWithValue("@StudentDepartment", student.Department);


                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        //To Update the records of a particluar employee  
        public void UpdateStudent(Student student)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("UpdateStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@StudentID", student.ID);
                cmd.Parameters.AddWithValue("@StudentName", student.Name);
                cmd.Parameters.AddWithValue("@StudentAge", student.Age);
                cmd.Parameters.AddWithValue("@StudentDOB", student.DOB);
                cmd.Parameters.AddWithValue("@StudentGender", student.Gender);
                cmd.Parameters.AddWithValue("@StudentPhone", student.Phone);
                cmd.Parameters.AddWithValue("@StudentEmail", student.Email);
                cmd.Parameters.AddWithValue("@StudentAddress", student.Address);
                cmd.Parameters.AddWithValue("@StudentDepartment", student.Department);


                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }


        //Get the details of a particular student
        public Student GetStudentData(int id)
        {
            Student student = new Student();

            using (SqlConnection con = new SqlConnection(connectionString))
            {

                string sqlQuery = "SELECT * FROM Student WHERE StudentID= " + id;
                SqlCommand cmd = new SqlCommand(sqlQuery, con);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {

                    student.ID = Convert.ToInt32(rdr["StudentID"]);
                    student.Name = rdr["StudentName"].ToString();
                    student.Age = rdr["StudentAge"].ToString();
                    student.DOB = rdr["StudentDOB"].ToString();
                    student.Gender = rdr["StudentGender"].ToString();
                    student.Phone = rdr["StudentPhone"].ToString();
                    student.Email = rdr["StudentEmail"].ToString();
                    student.Address = rdr["StudentAddress"].ToString();
                    student.Department = rdr["StudentDepartment"].ToString();


                }
            }
            return student;
        }



        //To Delete the record on a particular employee  
        public void DeleteStudent(int id)
        {

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("DeleteStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@StudentID", id);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}