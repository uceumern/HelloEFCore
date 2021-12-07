using Microsoft.Data.SqlClient;
using System.Diagnostics;

namespace HelloDatabase
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var connectionString = "Server=.;Database=Northwind;Trusted_Connection=True;trustservercertificate=true";

            var sw = new Stopwatch();
            sw.Start();
            try
            {
                using (var sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();

                    using (var cmd = sqlConnection.CreateCommand())
                    {
                        cmd.CommandText = "SELECT COUNT(*) FROM Employees";
                        var count = (int)cmd.ExecuteScalar();
                        label1.Text = $"Found {count} employees in db.";
                    }

                    using (var cmdEmployees = sqlConnection.CreateCommand())
                    {
                        cmdEmployees.CommandText = "SELECT * FROM Employees";
                        var reader = cmdEmployees.ExecuteReader();

                        var employees = new List<Employee>();

                        while (reader.Read())
                        {
                            // ok
                            var firstName = reader.GetString(2);
                            // bad
                            var lastName = reader["LastName"].ToString();
                            // best
                            var birthDate = reader.GetDateTime(reader.GetOrdinal("BirthDate"));

                            var employee = new Employee { FirstName = firstName, LastName = lastName, BirthDate = birthDate };
                            employees.Add(employee);
                        }

                        dataGridView1.DataSource = employees;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Caught exception: {ex.Message}", "Error");
            }

            sw.Stop();
            Trace.WriteLine($"Elapsed: {sw.Elapsed}"); 
        }
    }
}