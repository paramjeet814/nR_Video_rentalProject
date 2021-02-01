using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace nR_Video_rentalProject
{
    public partial class Form2 : Form
    {
        int BookingID = 0;
        int Option = 0;
        public Form2()
        {
            InitializeComponent();
        }

        // saving customers details 
        private void btnCustomerUpdate__rental_Click(object sender, EventArgs e)
        {
            Client client = new Client(Convert.ToInt32(Cli_ID.Text), txtName.Text, txtAddress.Text, txtContact.Text, cus_email.Text, txtCountry.Text);
            client.UpdateClient();
            MessageBox.Show("Client details are saved ");
            txtName.Text = "";
            txtAddress.Text = "";
            txtContact.Text = "";
            txtCountry.Text = "";
            cus_email.Text = "";


        }

        // for purpose of adding video record
        private void btn_video_add__rental_Click(object sender, EventArgs e)
        {
            Movie movie = new Movie(1,txtTitle.Text,txtRatting.Text,txtYear.Text,txtCost.Text,txtCopies.Text,txtGenre.Text);
            movie.AddMovie();
            MessageBox.Show("Movie record is stored ");
            txtTitle.Text = "";
            txtRatting.Text = "";
            txtYear.Text = "";
            txtCost.Text = "";
            txtCopies.Text = "";
            txtGenre.Text = "";

        }

        // adding customers in the database 
        private void CustomerAdd_rental_Click(object sender, EventArgs e)
        {
            Client client = new Client(1,txtName.Text,txtAddress.Text,txtContact.Text,cus_email.Text,txtCountry.Text);
            client.AddClient();
            MessageBox.Show("Client details are saved ");
            txtName.Text = "";
            txtAddress.Text = "";
            txtContact.Text = "";
            txtCountry.Text = "";
            cus_email.Text = "";

        }
        // for deleting customers 
        private void CustomerDelete__rental_Click(object sender, EventArgs e)
        {

            Client client = new Client(Convert.ToInt32(Cli_ID.Text), txtName.Text, txtAddress.Text, txtContact.Text, cus_email.Text, txtCountry.Text);
            client.delClient();
            MessageBox.Show("Seletecd Client details are removed  ");

            Cli_ID.Text = "";
            txtName.Text = "";
            txtAddress.Text = "";
            txtContact.Text = "";
            txtCountry.Text = "";
            cus_email.Text = "";

        }

        // for saving date
        private void txtYear_TextChanged(object sender, EventArgs e)
        {
            try
            {

                DateTime dateNow = DateTime.Now;

                int Currentyear = dateNow.Year;

                int diffYear = Currentyear - Convert.ToInt32(txtYear.Text);
                int cost = 0;
                // MessageBox.Show(diff.ToString());
                if (diffYear >= 5)
                {
                    cost = 2;
                }
                if (diffYear >= 0 && diffYear < 5)
                {
                    cost = 5;
                }

                txtCost.Text = "" + cost;
            }
            catch (Exception ex)
            {
                
            }

        }

        // for deleting video 
        private void btnVideoDelete_Click(object sender, EventArgs e)
        {
            Movie movie = new Movie(Convert.ToInt32(MvID.Text), txtTitle.Text, txtRatting.Text, txtYear.Text, txtCost.Text, txtCopies.Text, txtGenre.Text);
            movie.delMovie();
            MessageBox.Show("Movie record is deleted ");
            MvID.Text = "";
            txtTitle.Text = "";
            txtRatting.Text = "";
            txtYear.Text = "";
            txtCost.Text = "";
            txtCopies.Text = "";
            txtGenre.Text = "";

        }

        //for updating the video rental
        private void btnVideoUpdate_rental_Click(object sender, EventArgs e)
        {
            Movie movie = new Movie(Convert.ToInt32(MvID.Text), txtTitle.Text, txtRatting.Text, txtYear.Text, txtCost.Text, txtCopies.Text, txtGenre.Text);
            movie.UpdateMovie();
            MessageBox.Show("Movie record is Update ");
            MvID.Text = "";
            txtTitle.Text = "";
            txtRatting.Text = "";
            txtYear.Text = "";
            txtCost.Text = "";
            txtCopies.Text = "";
            txtGenre.Text = "";

        }

        // for issue the movie 
        private void btnVideoIssue_rental_Click(object sender, EventArgs e)
        {

            Booking booking = new Booking(1,Convert.ToInt32(Cli_ID.Text),Convert.ToInt32(MvID.Text),BookingDate.Text,"Booked");
            DataTable tbl = new DataTable();
            tbl = booking.CmdRecord("select * from Booking where ClientID="+ Convert.ToInt32(Cli_ID.Text) + " and ReturnDate='Booked'");
            int customerBooking = tbl.Rows.Count - 1;

            tbl = new DataTable();
            tbl = booking.CmdRecord("select * from Movie where ID=" + Convert.ToInt32(MvID.Text) + "");
            int Copies= Convert.ToInt32(tbl.Rows[0]["MvCopies"].ToString());

            tbl = new DataTable();
            tbl = booking.CmdRecord("select * from Booking where MovieID=" + Convert.ToInt32(MvID.Text) + " and ReturnDate='Booked'");
            int BookingMovie= tbl.Rows.Count-1;



            if (customerBooking < 2) {
                if (BookingMovie < Copies)
                {
                    booking.BookMovie();
                    MessageBox.Show("Movie is Booked");
                }
                else {
                    MessageBox.Show("All Sample are Booked ");
                }
            }
            else {
                MessageBox.Show("You canot book more movie ");
            }
            


            
            MvID.Text = "";
            txtTitle.Text = "";
            txtRatting.Text = "";
            txtYear.Text = "";
            txtCost.Text = "";
            txtCopies.Text = "";
            txtGenre.Text = "";

            Cli_ID.Text = "";
            txtName.Text = "";
            txtAddress.Text = "";
            txtContact.Text = "";
            txtCountry.Text = "";
            cus_email.Text = "";


        }

        private void btnVideoReturn_rental_Click(object sender, EventArgs e)
        {
            Booking booking = new Booking(BookingID, Convert.ToInt32(Cli_ID.Text), Convert.ToInt32(MvID.Text), BookingDate.Text, ReturnDate.Text);

            //get the cost ofthe mvie 
            DataTable tbl = new DataTable();
            tbl = new DataTable();
            tbl = booking.CmdRecord("select * from Movie where ID=" + Convert.ToInt32(MvID.Text) + "");
            int Cost = Convert.ToInt32(tbl.Rows[0]["MvCost"].ToString());


            DateTime current_date = DateTime.Now;

            //convert the old date from string to Date fromat
            DateTime prev_date = Convert.ToDateTime(BookingDate.Text);


            //get the difference in the days fromat
            String Daysdiff = (current_date - prev_date).TotalDays.ToString();


            // calculate the round off value 
            Double DaysInterval = Math.Round(Convert.ToDouble(Daysdiff));


            int total = Cost *Convert.ToInt32( DaysInterval);

            booking.ReturneMovie();
            MessageBox.Show("Movie is returned and Bill is $"+total);
            MvID.Text = "";
            txtTitle.Text = "";
            txtRatting.Text = "";
            txtYear.Text = "";
            txtCost.Text = "";
            txtCopies.Text = "";
            txtGenre.Text = "";

            Cli_ID.Text = "";
            txtName.Text = "";
            txtAddress.Text = "";
            txtContact.Text = "";
            txtCountry.Text = "";
            cus_email.Text = "";

        }

        private void show_mov_Click(object sender, EventArgs e)
        {
            Option = 1;
            Movie movie = new Movie(1,"1","1","1","1","1","1");
            DatabaseTable.DataSource =movie.CmdRecord("select * from Movie");

        }

        private void show_customer_Click(object sender, EventArgs e)
        {
            Option = 2;
            Client client = new Client(1, "1", "1", "1", "1", "1");
            DatabaseTable.DataSource = client.CmdRecord("select * from client");


        }

        // showing videos 
        private void show_videos_Click(object sender, EventArgs e)
        {
            Option = 3;
            Booking booking = new Booking(1, 1, 1,"1", "1");
            DatabaseTable.DataSource = booking.CmdRecord("select * from Booking ");
        }

        private void DatabaseTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void popular_mov_Click(object sender, EventArgs e)
        {
            //compare the booking and fetch the most viewed movie
            DataTable tblData = new DataTable();
            Booking booking = new Booking(1, 1, 1, "1", "1");

            tblData = booking.CmdRecord("select * from Movie");
            int x = 0, y = 0, cunt = 0;
            String Title = "";
            for (x = 0; x < tblData.Rows.Count; x++)
            {
                DataTable tblData1 = new DataTable();
                tblData1 = booking.CmdRecord("select * from Booking where MovieID='" + tblData.Rows[x]["ID"].ToString() + "'");

                if (tblData1.Rows.Count > cunt)
                {
                    Title = tblData.Rows[x]["Mvtitle"].ToString();
                    cunt = tblData1.Rows.Count;
                }

            }

            MessageBox.Show("Best Movie is " + Title);

        }
        
        // when user will click on cells 

        private void DatabaseTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Option == 1)
            {
                MvID.Text = DatabaseTable.CurrentRow.Cells[0].Value.ToString();
                txtTitle.Text = DatabaseTable.CurrentRow.Cells[1].Value.ToString();
                txtRatting.Text = DatabaseTable.CurrentRow.Cells[2].Value.ToString();
                txtYear.Text = DatabaseTable.CurrentRow.Cells[3].Value.ToString();
                txtCost.Text = DatabaseTable.CurrentRow.Cells[4].Value.ToString();
                txtCopies.Text = DatabaseTable.CurrentRow.Cells[5].Value.ToString();
                txtGenre.Text = DatabaseTable.CurrentRow.Cells[6].Value.ToString();
            }
            if (Option == 2)
            {
                Cli_ID.Text = DatabaseTable.CurrentRow.Cells[0].Value.ToString();
                txtName.Text = DatabaseTable.CurrentRow.Cells[1].Value.ToString();
                txtAddress.Text = DatabaseTable.CurrentRow.Cells[2].Value.ToString();
                txtContact.Text = DatabaseTable.CurrentRow.Cells[3].Value.ToString();
                cus_email.Text = DatabaseTable.CurrentRow.Cells[4].Value.ToString();
                txtCountry.Text = DatabaseTable.CurrentRow.Cells[5].Value.ToString();
            }
            if (Option == 3)
            {

                BookingID = Convert.ToInt32(DatabaseTable.CurrentRow.Cells[0].Value.ToString());
                MvID.Text = DatabaseTable.CurrentRow.Cells[2].Value.ToString();
                Cli_ID.Text = DatabaseTable.CurrentRow.Cells[1].Value.ToString();
                BookingDate.Text = DatabaseTable.CurrentRow.Cells[3].Value.ToString();
            }
            Option = 0;
        }

        private void popul_custmer_Click(object sender, EventArgs e)
        {

            //compare the booking and fetch the most viewed movie
            DataTable tblData = new DataTable();
            Booking booking = new Booking(1, 1, 1, "1", "1");

            tblData = booking.CmdRecord("select * from client");
            int x = 0, y = 0, cunt = 0;
            String Title = "";
            for (x = 0; x < tblData.Rows.Count; x++)
            {
                DataTable tblData1 = new DataTable();
                tblData1 = booking.CmdRecord("select * from Booking where ClientID='" + tblData.Rows[x]["ID"].ToString() + "'");

                if (tblData1.Rows.Count > cunt)
                {
                    Title = tblData.Rows[x]["clName"].ToString();
                    cunt = tblData1.Rows.Count;
                }

            }

            MessageBox.Show("Best Client is " + Title);
        }
    }
}
