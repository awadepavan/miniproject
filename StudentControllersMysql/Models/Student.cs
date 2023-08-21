using MySql.Data.MySqlClient;
using System.Data;

namespace StudentControllersMysql.Models
{
    public class Student
    {
        public int StuId { get; set; }
        public string StuName { get; set; }

        public string StuSurName { get; set; }

        public String StuEmail { get; set; }
        public string StuPhoneNo { get; set; }

        public string StuCourse { get; set; }

        public int StuCourseFees { get; set; }

        static string Db = @"server=localhost;userid=root;password=awadepavan8805@;database=Dotnet";


        public static List<Student> GetAllStudents()
        {
            List<Student> lststd = new List<Student>();

            MySqlConnection cn = new MySqlConnection();


            cn.ConnectionString = Db;
            cn.Open();

            try
            {


                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Studentsdata ";

                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {

                    Student obj = new Student();

                    obj.StuId = dr.GetInt32("StuId");
                    obj.StuName = dr.GetString("StuName");
                    obj.StuSurName = dr.GetString("StuSurName");
                    obj.StuEmail = dr.GetString("StuEmail");
                    obj.StuPhoneNo = dr.GetString("StuPhoneNo");
                    obj.StuCourse = dr.GetString("StuCourse");
                    obj.StuCourseFees = dr.GetInt32("StuCourseFees");

                    lststd.Add(obj);

                }

                dr.Close();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cn.Close();
            }
            return lststd;
        }


        public static Student GetSingleStudent(int StuId)
        {


            Student emp = new Student();
            MySqlConnection cn = new MySqlConnection();
            cn.ConnectionString = Db;
            cn.Open();
            try
            {

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Studentsdata where StuId=@StuId";

                cmd.Parameters.AddWithValue("@StuId", StuId);

                MySqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    emp.StuId = StuId;
                    emp.StuName = dr.GetString("StuName");
                    emp.StuSurName = dr.GetString("StuSurName");
                    emp.StuEmail = dr.GetString("StuEmail");
                    emp.StuPhoneNo = dr.GetString("StuPhoneNo");
                    emp.StuCourse = dr.GetString("StuCourse");
                    emp.StuCourseFees = dr.GetInt32("StuCourseFees");

                }
                else
                {
                    //if not found
                    emp = null;
                }
                dr.Close();

            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cn.Close();
            }
            return emp;
        }

        public static void InsertStudent(Student obj)
        {
            MySqlConnection cn = new MySqlConnection();
            cn.ConnectionString = Db;
            cn.Open();
            try
            {

                MySqlCommand cmdInsert = new MySqlCommand();
                cmdInsert.Connection = cn;
                cmdInsert.CommandType = CommandType.Text;
                cmdInsert.CommandText = "Insert into Studentsdata values(@StuId,@StuName,@StuSurName,@StuEmail,@StuPhoneNo,@StuCourse,@StuCourseFees)";


                cmdInsert.Parameters.AddWithValue("@StuId", obj.StuId);
                cmdInsert.Parameters.AddWithValue("@StuName", obj.StuName);
                cmdInsert.Parameters.AddWithValue("@StuSurName", obj.StuSurName);
                cmdInsert.Parameters.AddWithValue("@StuEmail", obj.StuEmail);
                cmdInsert.Parameters.AddWithValue("@StuPhoneNo", obj.StuPhoneNo);
                cmdInsert.Parameters.AddWithValue("@StuCourse", obj.StuCourse);
                cmdInsert.Parameters.AddWithValue("@StuCourseFees", obj.StuCourseFees);
                cmdInsert.ExecuteNonQuery();





                cmdInsert.ExecuteNonQuery();

                Console.WriteLine("okay");

            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cn.Close();
            }
        }

        public static void UpdateStudent(Student obj)
        {


            MySqlConnection cn = new MySqlConnection();
            cn.ConnectionString = Db;
            cn.Open();
            try
            {


                MySqlCommand cmdInsert = new MySqlCommand();
                cmdInsert.Connection = cn;
                cmdInsert.CommandType = CommandType.Text;

                cmdInsert.CommandText = "UPDATE Studentsdata SET StuName = @StuName, StuSurName=@StuSurName , StuEmail =@StuEmail, StuPhoneNo= @StuPhoneNo,StuCourse=@StuCourse,StuCourseFees=@StuCourseFees WHERE StuId = @StuId";

                cmdInsert.Parameters.AddWithValue("@StuId", obj.StuId);
                cmdInsert.Parameters.AddWithValue("@StuName", obj.StuName);
                cmdInsert.Parameters.AddWithValue("@StuSurName", obj.StuSurName);
                cmdInsert.Parameters.AddWithValue("@StuEmail", obj.StuEmail);
                cmdInsert.Parameters.AddWithValue(" @StuPhoneNo", obj.StuPhoneNo);
                cmdInsert.Parameters.AddWithValue(" @StuCourse", obj.StuCourse);
                cmdInsert.Parameters.AddWithValue(" @StuCourseFees", obj.StuCourseFees);

                cmdInsert.ExecuteNonQuery();
                Console.WriteLine("update Sucessfull");
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cn.Close();
            }
        }

        public static void DeleteStudent(int StuId)
        {


            MySqlConnection cn = new MySqlConnection();
            cn.ConnectionString = Db;
            cn.Open();
            try
            {

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "DELETE FROM Studentsdata WHERE @stuId =StuId";

                cmd.Parameters.AddWithValue("@StuId", StuId);

                cmd.ExecuteNonQuery();

                Console.WriteLine("Delete successful");
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cn.Close();
            }
        }
    }
}
