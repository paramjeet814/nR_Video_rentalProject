using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nR_Video_rentalProject
{
   public class Movie
    {
        public int ID;
        public String title;
        public String ratting;
        public String Year;
        public String cost;
        public String copies;
        public String Genre;

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


        public Movie(int _id, String _title, String _ratting, String _year, String _Cost, String _copies,String _genre) {
            this.ID = _id;
            this.title = _title;
            this.ratting = _ratting;
            this.Year = _year;
            this.cost = _Cost;
            this.copies = _copies;
            this.Genre = _genre;
        }


        //this function is used to add the details of the Movie
        public Boolean AddMovie()
        {
            String Query = "insert into Movie(Mvtitle,MvRatting,MvYear,MvCost,MvCopies,MvGenre) values ('" +title + "','" + ratting+ "','" + Year + "','" + cost + "','" + copies + "','"+Genre+"')";
            CmdQuery(Query);
            return true;
        }
        //this boolean type function is sued to update the record  
        public Boolean UpdateMovie()
        {
            String Query = "Update Movie set Mvtitle='"+title+"',MvRatting='"+ratting+"',MvYear='"+Year+"',MvCost='"+cost+"',MvCopies='"+copies+"',MvGenre='"+Genre+"' where ID="+ID+"";
            CmdQuery(Query);
            return true;
        }

        //this boolean type function is sued to delete  the record 
        public Boolean delMovie()
        {
            String Query = "delete from Movie where ID=" + ID + "";
            CmdQuery(Query);
            return true;
        }
    }
}
