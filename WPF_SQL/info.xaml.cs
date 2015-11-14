using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace WPF_SQL
{
    /// <summary>
    /// Interaction logic for info.xaml
    /// </summary>
    public partial class info : Window
    {
        public info()
        {
            InitializeComponent();  
            
        }

        private void btnLaatZien_Click(object sender, RoutedEventArgs e)
        {

            SqlConnection sql = new SqlConnection(clStam.Connstr);

            try
            {
                sql.Open();

                string query = "select Gebrnr, Vnaam, Tnaam, Anaam from Gebruikers";
                SqlCommand createCommand = new SqlCommand(query, sql);
                createCommand.ExecuteNonQuery();

                SqlDataAdapter dataAdp = new SqlDataAdapter(createCommand);
                DataTable dt = new DataTable("Gebruikers");
                dataAdp.Fill(dt);
                gegevens.ItemsSource = dt.DefaultView;
                dataAdp.Update(dt);

                sql.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

       
        
    }
}
