using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyProjectFriend_
{
    internal class Database
    {
        const string connectionString = @"Data Source=LAPTOP-60OVNJGF;Initial Catalog=LibraryTest;Integrated Security=True";
        static SqlConnection connection = new SqlConnection(connectionString);
        static SqlCommand command;
        static SqlDataReader reader;
        internal Database()
        {

        }

        public static void AddUserDB(int id, string name, string surname, string schoolname, string email, string password)
        {
            //Yeni kullanıcı ekleme
            command = new SqlCommand(@"INSERT INTO tblUsers(UserID,UserName,UserSurname,refSchoolID,UserEmail,UserPassword) VALUES (@id,@name,@surname,@schoolId,@email,@password)", connection);

            #region commands
            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@surname", surname);
            command.Parameters.AddWithValue("@schoolId", schoolname);//Düzeltme : 'refSchoolID' int(id) değil 'okul adı'(string) alır
            command.Parameters.AddWithValue("@email", email);
            command.Parameters.AddWithValue("@password", password);
            #endregion

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
        public static void cbxDefination(ComboBox comboBox, string table, string column)
        {
            //ComboBox içine verileri çekme
            connection.Open();
            reader = commandMethod($"Select * From {table} Order By {column}").ExecuteReader();
            while (reader.Read())
            {
                comboBox.Items.Add(reader[column]);
            }
            connection.Close();
        }
        public static bool emailcontrol(string email)
        {
            //Email kayıt kontrolü
            connection.Open();
            reader = commandMethod("Select UserEmail From TblUsers").ExecuteReader();
            while (reader.Read())
            {
                if (email == reader["UserEmail"].ToString())
                {
                    connection.Close();
                    reader.Close();
                    return true;
                }
            }
            reader.Close();
            connection.Close();
            return false;
        }
        public static bool enteranceControl(string email, string password)
        {
            connection.Open();
            reader = commandMethod($"Select * From TblUsers").ExecuteReader();

            while (reader.Read()) //Verileri okuma ve eşleşme kontrolü
            {
                if (email == reader["UserEmail"].ToString() && password == reader["UserPassword"].ToString())
                {
                    #region sync
                    //Yakalanan kullanıcı bilgilerini belleğe alma
                    User user = new User();
                    user.ID = Convert.ToInt32(reader["UserID"]);
                    user.Name = reader["UserName"].ToString();
                    user.Surname = reader["UserSurname"].ToString();
                    user.Email = reader["UserEmail"].ToString();
                    user.Password = reader["UserPassword"].ToString();
                    user.SchoolName = reader["refSchoolID"].ToString();
                    User.users.Add(user);
                    #endregion
                    connection.Close();
                    return true;
                }
                else
                {
                    MessageBox.Show("Hatalı şifre");
                    connection.Close();
                    return false;
                }
            }
            reader.Close();
            connection.Close();
            return false;
        }
        static SqlCommand commandMethod(string query)
        {
            //command kullanımını merkezleştirip tekrarlayan kodları azaltmak
            SqlCommand tblschlcommand = new SqlCommand(query, connection);
            tblschlcommand.CommandType = CommandType.Text;
            return tblschlcommand;
        }
    }
}
