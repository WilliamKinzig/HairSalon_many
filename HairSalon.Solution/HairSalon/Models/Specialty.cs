using MySql.Data.MySqlClient;
using System.Collections.Generic;


namespace HairSalon.Models
{
  public class Specialty
  {
    private int _specialty_id;
    private string _specialty_name;

    /******************************************************************************/

    public Specialty(string name, int id = 0)
    {
      _specialty_name = name;
      _specialty_id = id;
    }

    /******************************************************************************/

    public int GetId()
    {
      return _specialty_id;
    }

    /******************************************************************************/

    public string GetName()
    {
      return _specialty_name;
    }
    /******************************************************************************/

    public override int GetHashCode()
    {
      return this.GetId().GetHashCode();
    }

    /******************************************************************************/

    public override bool Equals(System.Object otherSpecialty)
    {
      if(!(otherSpecialty is Specialty))
      {
        return false;
      }
      else
      {
        Specialty newSpecialty = (Specialty) otherSpecialty;
        bool idEquality = (this.GetId() == newSpecialty.GetId());
        bool nameEquality = (this.GetName() == newSpecialty.GetName());
        return(idEquality && nameEquality);
      }
    }

    /******************************************************************************/

    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO specialties (Name) VALUES (@name);";

      cmd.Parameters.Add(new MySqlParameter("@name", _specialty_name));

      cmd.ExecuteNonQuery();
      _specialty_id = (int) cmd.LastInsertedId;
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    /**************************ILOVEKISSINGDOGS*****************************************/

    public void AddStylist(Stylist newStylist)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO stylists_specialties (stylist_id, specialty_id) VALUES (@StylistId, @SpecialtyId);";

      cmd.Parameters.Add(new MySqlParameter("@SpecialtyId", _specialty_id));
      cmd.Parameters.Add(new MySqlParameter("@StylistId", newStylist.GetId()));

      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    /******************************************************************************/

    public static Specialty Find(int id)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM specialties WHERE id = (@searchId);";

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
      Specialty newSpecialty = new Specialty(name, iD);
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return newSpecialty;
    }

    /******************************************************************************/

    public void Edit(string newName)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"UPDATE specialties SET Name = @newName WHERE id = @searchId;";

      cmd.Parameters.Add(new MySqlParameter("@searchId", _specialty_id));
      cmd.Parameters.Add(new MySqlParameter("@newName", newName));

      cmd.ExecuteNonQuery();
      _specialty_name = newName;

      conn.Close();
      if (conn != null)
      {
          conn.Dispose();
      }
    }

    /******************************************************************************/

    public List<Stylist> GetStylists()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT stylists.* FROM specialties
      JOIN stylists_specialties ON (specialties.id = stylists_specialties.specialty_id)
      JOIN stylists ON (stylists_specialties.stylist_id = stylists.id)
      WHERE specialties.id = @SpecialtyId;";

      cmd.Parameters.Add(new MySqlParameter("@SpecialtyId", _specialty_id));

      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      List<Stylist> stylists = new List<Stylist>{};

      while(rdr.Read())
      {
        int stylistId = rdr.GetInt32(0);
        string stylistTitle = rdr.GetString(1);
        Stylist newStylist = new Stylist(stylistTitle, stylistId);
        stylists.Add(newStylist);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }

      return stylists;
    }

    /******************************************************************************/

    public static List<Specialty> GetAll()
    {
      List<Specialty> specialties = new List<Specialty> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM specialties;";
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int id = rdr.GetInt32(0);
        string name = rdr.GetString(1);
        Specialty newSpecialty = new Specialty(name, id);
        specialties.Add(newSpecialty);
      }
      conn.Close();
      if (conn != null)
      {
          conn.Dispose();
      }

      return specialties;
    }

    /******************************************************************************/

    public void Delete()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM specialties WHERE id = @thisId;";

      cmd.Parameters.Add(new MySqlParameter("@thisID", _specialty_id));

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
      cmd.CommandText = @"DELETE * FROM specialties; DELETE * FROM stylists; DELETE * FROM stylists_specialties;";
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
          conn.Dispose();
      }
    }
  }
}
