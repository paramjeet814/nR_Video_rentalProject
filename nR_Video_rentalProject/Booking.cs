using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nR_Video_rentalProject
{
    public class Booking
    {
        int BookID;
        int ClientID;
        int MovieID;
        String BookingDate;
        String ReturnDate;


        //create the instance of the SQL Connection class
        SqlConnection conn;

        //write the connection sstring to assthe data form one for to the database 
        String conStr = "Data Source=DESKTOP-G2UGPMF\\SQLEXPRESS;Initial Catalog=nr_VideoRental;Integrated Security=True";

        //command are use to excute the command of isnert , delete , update
        SqlCommand cmd;

        //data reader is used to read thedata from the database table 
        SqlDataReader DReader;


        //method used to execute query which doent return any thing only modifit the database
        public void CmdQuery(String query)
        {
            conn = new SqlConnection(conStr);
            conn.Open();
            cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        // this method is used to search the record from the data base and then pass the whole record to the query using where clause of the sql
        public DataTable CmdRecord(String qry)
        {
            DataTable tbl = new DataTable();

            conn = new SqlConnection(conStr);

            conn.Open();

            cmd = new SqlCommand(qry, conn);

            DReader = cmd.ExecuteReader();

            tbl.Load(DReader);

            conn.Close();

            return tbl;
        }

        //prameterized constructr of the class 
        public Booking(int id,int cID, int Mid, String Bdate, String RDate) {
            this.BookID = id;
            this.ClientID = cID;
            this.MovieID = Mid;
            this.BookingDate = Bdate;
            this.ReturnDate = RDate;
        }


        //this function is used to add the details of the Movie
        public Boolean BookMovie()
        {
            String Query = "insert into Booking(ClientID,MovieID,BookingDate,ReturnDate) values (" + ClientID+ "," + MovieID + ",'" + BookingDate + "','" + ReturnDate + "')";
            CmdQuery(Query);
            return true;
        }
        //this boolean type function is sued to update the record  
        public Boolean ReturneMovie()
        {
            String Query = "Update Booking set ClientID=" + ClientID + ",MovieID=" + MovieID + ",BookingDate='" + BookingDate + "',ReturnDate='" + ReturnDate+ "' where BookID=" + BookID + "";
            CmdQuery(Query);
            return true;
        }


    }
}
