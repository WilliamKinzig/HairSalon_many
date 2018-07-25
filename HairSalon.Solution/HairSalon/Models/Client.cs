using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace HairSalon.Models
{
  public class Client
  {
    private int _id;
    private string _name;
    private int _stylist_id;

    public Client(string Name, int stylistId = 0, int Id = 0)
    {
      _name = Name;
      _id = Id;
      _stylist_id = stylistId;
    }
    public int GetClientId()
    {
      return _id;
    }
    public string GetName()
    {
      return _name;
    }

/******************************************************************************/

    public override int GetHashCode()
    {
      return this.GetClientId().GetHashCode();
    }

/******************************************************************************/

    public override bool Equals(System.Object otherClient)
    {
      if(!(otherClient is Client))
      {
        return false;
      }
      else
      {
        Client newClient = (Client) otherClient;

        bool nameEquality = (this.GetName() == newClient.GetName());
        bool idEquality = (this.GetClientId() == newClient.GetClientId());
        bool stylistIdEquality = (this.GetClientId() == newClient.GetClientId());

        return(idEquality && stylistIdEquality && nameEquality);
      }
    }

/******************************************************************************/

    public static Client Find(int id)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM clients WHERE id = (@searchId);";

      MySqlParameter searchId = new MySqlParameter();
      searchId.ParameterName = "@searchId";
      searchId.Value = id;
      cmd.Parameters.Add(searchId);

      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      int iD = 0;
      string name = "";

      while(rdr.Read())
      {
        iD = rdr.GetInt32(0);
        name = rdr.GetString(1);

      }
      Client newClient = new Client(name, iD);
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }

      return newClient;
    }

/******************************************************************************/

    public void Edit(string newName)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;

      cmd.CommandText = @"UPDATE clients SET Name = @newName WHERE id = @searchId;";

      cmd.Parameters.Add(new MySqlParameter("@searchId", _id));
      cmd.Parameters.Add(new MySqlParameter("@newName", newName));

      cmd.ExecuteNonQuery();
      _name = newName;
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

/******************************************************************************/

    public static List<Client> GetAll()
    {
      List<Client> clientList = new List<Client> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM clients;";
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int id = rdr.GetInt32(0);
        string name = rdr.GetString(1);

        Client newClient = new Client(name, id);

        clientList.Add(newClient);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return clientList;
    }

/******************************************************************************/

    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO clients (name) VALUES (@name);";

      cmd.Parameters.Add(new MySqlParameter("@name", _name));

      cmd.ExecuteNonQuery();
      _id = (int) cmd.LastInsertedId;
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

/******************************************************************************/

    public void Delete()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM clients WHERE id = @thisId;";

      cmd.Parameters.Add(new MySqlParameter("@thisID", _id));

      cmd.ExecuteNonQuery();

      conn.Close();
      if(conn != null)
      {
        conn.Dispose();
      }
    }

/******************************************************************************/

    public static void DeleteAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM clients;";
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }
  }
}
