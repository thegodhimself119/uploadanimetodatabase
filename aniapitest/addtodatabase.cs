using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aniapitest;


class addtodatabase
{


    public void adddata(int id,string name,string date,string link, string image,string genre)
    {
        string ConnectionString = @"Server=(localdb)\ProjectModels;Database=Anime;Trusted_Connection=True;MultipleActiveResultSets=true";
        SqlConnection con = new SqlConnection(ConnectionString);
        con.Open();
        SqlCommand sqlCommand = new SqlCommand("insert into AniModels values(@id,@name,@date,@link,@image,@genre)", con);
        sqlCommand.Parameters.AddWithValue("@id", id);
        sqlCommand.Parameters.AddWithValue("@name", name);
        sqlCommand.Parameters.AddWithValue("@date", date);
        sqlCommand.Parameters.AddWithValue("@link", link);
        sqlCommand.Parameters.AddWithValue("@image",image);
        sqlCommand.Parameters.AddWithValue("@genre", genre);
        sqlCommand.ExecuteNonQuery();
        con.Close();



    }
}


    
 

    
  
    
        
    

