using Npgsql;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;

namespace WinFormsApp4
{
    public partial class Form1 : Form
    {
        string connectionString = "Host=localhost;Username=postgres;Password=postgres;Database=dbdatadiri";
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nama = textBox1.Text;
            string alamat = textBox2.Text;

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                if (!string.IsNullOrWhiteSpace(nama) && !string.IsNullOrWhiteSpace(alamat))
                {

                    string sql = "INSERT INTO dataperson (Nama, Alamat) VALUES (@Nama, @Alamat)";
                    using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@Nama", nama);
                        command.Parameters.AddWithValue("@Alamat", alamat);

                        connection.Open();

                        int rowsAffected = command.ExecuteNonQuery();


                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Data berhasil dimasukkan ke dalam database.");
                            textBox1.Text = "";
                            textBox2.Text = "";

                        }
                        else
                        {
                            MessageBox.Show("Gagal memasukkan data ke dalam database.");
                        }

                    }
                }
                else
                {
                    MessageBox.Show("data belum dimasukkan!");

                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";

        }
    }
}
