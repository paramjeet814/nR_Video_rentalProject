using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nR_Video_rentalProject
{
  public  class Client
    {
      public  int id;
        public String Name;
        public String Address;
        public String Contact;
        public String Email;
        public String Country;
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

        //parameterized constructor
       public Client(int _id, String _Name, String _Address, String _contact, String _Email,String _Country) {
            this.id = _id;
            this.Name = _Name;
            this.Address = _Address;
            this.Contact = _contact;
            this.Email = _Email;
            this.Country = _Country;
        }

        //this function is used to add the details of the client 
        public Boolean AddClient() {
            String Query = "insert into client(clName,clAddress,clContact,clEmail,clCountry) values ('"+Name+"','"+Address+"','"+Contact+"','"+Email+"','"+Country+"')";
            CmdQuery(Query);
            return true;
        }
        //this boolean type function is sued to update the record  
        public Boolean UpdateClient()
        {
            String Query = "Update client set clName='"+Name+"',clAddress='"+Address+"',clContact='"+Contact+"',clEmail='"+Email+"',clCountry='"+Country+ "' where ID=" + id + "";
            CmdQuery(Query);
            return true;
        }

        //this boolean type function is sued to delete  the record 
        public Boolean delClient() {
            String Query = "delete from client where ID="+id+"";
            CmdQuery(Query);
            return true;
        }


    }
}
