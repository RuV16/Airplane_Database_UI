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

namespace Airplane_Database_UI
{
    /// <summary>
    /// Interaction logic for TicketInfo.xaml
    /// </summary>
    public partial class TicketInfo : Window
    {
        public TicketInfo()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string dbsCon = @"Data Source=LABSCIFIPC14\LOCALHOST; Initial Catalog=Planes; Integrated Security=True";
            SqlConnection sqlCon_ = new SqlConnection(dbsCon);

            try
            {
                sqlCon_.Open();
                string query = $"Select * from Tickets where TicketValueID = '{TID.Text}'";
                SqlCommand cmd = new SqlCommand(query, sqlCon_);
                cmd.ExecuteNonQuery();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                DataGrid_.ItemsSource = dt.DefaultView;
                adapter.Update(dt);

                MessageBox.Show("Successful loading");
                sqlCon_.Close();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            finally { sqlCon_.Close(); }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Window1 w1 = new Window1();
            w1.Show();
            this.Close();
        }

        private void Passenger_Click(object sender, RoutedEventArgs e)
        {
            PassengerInfo p1 = new PassengerInfo();
            p1.Show();
            this.Close();
        }

        private void Info_Click(object sender, RoutedEventArgs e)
        {
            TicketDetails td = new TicketDetails();
            td.Show();
            this.Close();
        }
    }
}
