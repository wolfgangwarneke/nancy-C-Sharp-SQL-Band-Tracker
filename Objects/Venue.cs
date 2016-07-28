using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace BandTracker
{
  public class Venue
  {
    private int _id;
    private string _name;

    public Venue(string name, int id = 0)
    {
      this.SetName(name);
      this.SetId(id);
    }

    public void SetId(int id)
    {
      _id = id;
    }

    public int GetId()
    {
      return _id;
    }

    public void SetName(string name)
    {
      _name = name;
    }

    public string GetName()
    {
      return _name;
    }

    public static List<Venue> GetAll()
    {
      List<Venue> everyVenue = new List<Venue>{};
      SqlConnection conn = DB.Connection();
      SqlDataReader rdr = null;
      conn.Open();
      SqlCommand cmd = new SqlCommand("SELECT * FROM venues;", conn);
      rdr = cmd.ExecuteReader();
      while(rdr.Read())
      {
        int venueId = rdr.GetInt32(0);
        string venueName = rdr.GetString(1);
        Venue readVenue = new Venue(venueName, venueId);
        everyVenue.Add(readVenue);
      }
      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
      return everyVenue;
    }
    public void Save()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlDataReader rdr = null;
      SqlCommand cmd = new SqlCommand ("INSERT INTO venues (name) OUTPUT INSERTED.id VALUES (@VenueName);", conn);
      SqlParameter nameParameter = new SqlParameter();
      nameParameter.ParameterName = "@VenueName";
      nameParameter.Value = this.GetName();
      cmd.Parameters.Add(nameParameter);
      rdr = cmd.ExecuteReader();
      while (rdr.Read())
      {
       this._id = rdr.GetInt32(0);
      }
      if (rdr != null)
      {
       rdr.Close();
      }
      if (conn != null)
      {
       conn.Close();
      }
    }
    public static Venue FindById (int venueId)
    {
      List<Venue> matchingVenues = new List<Venue> {};
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlDataReader rdr = null;
      SqlCommand cmd = new SqlCommand ("SELECT * FROM venues WHERE id = @VenueId;", conn);
      SqlParameter idParameter = new SqlParameter ();
      idParameter.ParameterName = "@VenueId";
      idParameter.Value = venueId;
      cmd.Parameters.Add(idParameter);
      rdr = cmd.ExecuteReader();
      while (rdr.Read())
      {
        int id = rdr.GetInt32(0);
        string name = rdr.GetString(1);
        Venue newVenue = new Venue (name, id);
        matchingVenues.Add(newVenue);
      }
      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
      return matchingVenues[0];
    }
    public static Venue FindByVenueName (string venueName)
    {
      List<Venue> matchingVenues = new List<Venue> {};
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlDataReader rdr = null;
      SqlCommand cmd = new SqlCommand ("SELECT * FROM venues WHERE name = @VenueName;", conn);
      SqlParameter nameParameter = new SqlParameter ();
      nameParameter.ParameterName = "@VenueName";
      nameParameter.Value = venueName;
      cmd.Parameters.Add(nameParameter);
      rdr = cmd.ExecuteReader();
      while (rdr.Read())
      {
        int id = rdr.GetInt32(0);
        string name = rdr.GetString(1);
        Venue newVenue = new Venue (name, id);
        matchingVenues.Add(newVenue);
      }
      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
      return matchingVenues[0];
    }
    public static void DeleteAll()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand ("DELETE FROM venues; DELETE FROM bands_venues", conn);
      cmd.ExecuteNonQuery();
    }
    public void DeleteThis()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand ("DELETE FROM venues WHERE id = @VenueId;", conn);
      SqlParameter idParameter = new SqlParameter ();
      idParameter.ParameterName = "@VenueId";
      idParameter.Value = this.GetId();
      cmd.Parameters.Add(idParameter);
      cmd.ExecuteNonQuery();
    }

    public void UpdateVenueName(string newName)
    {
      SqlConnection conn = DB.Connection();
      SqlDataReader rdr;
      conn.Open();

      SqlCommand cmd = new SqlCommand("UPDATE venues SET name = @NewVenueName OUTPUT INSERTED.name WHERE id = @VenueId;", conn);

      SqlParameter newNameParameter = new SqlParameter();
      newNameParameter.ParameterName = "@NewVenueName";
      newNameParameter.Value = newName;
      cmd.Parameters.Add(newNameParameter);

      SqlParameter venueIdParameter = new SqlParameter();
      venueIdParameter.ParameterName = "@VenueId";
      venueIdParameter.Value = this.GetId();
      cmd.Parameters.Add(venueIdParameter);
      rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        this._name = rdr.GetString(0);
      }
      if (conn != null)
      {
        conn.Close();
      }
      if (rdr != null)
      {
        rdr.Close();
      }
    }

    public override bool Equals(System.Object otherVenue)
    {
      if (otherVenue is Venue)
      {
       Venue newVenue = (Venue) otherVenue;
       bool idEquality = (this.GetId() == newVenue.GetId());
       bool nameEquality = (this.GetName() == newVenue.GetName());
       return (idEquality && nameEquality);
      }
      else
      {
       return false;
      }
    }

    public List<Band> GetBandsPlayed()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT bands.* FROM bands JOIN bands_venues ON (bands.id = bands_venues.band_id) JOIN venues ON (bands_venues.venue_id = venues.id) WHERE venues.id = @VenueId;", conn);
      SqlParameter bandsId = new SqlParameter();
      bandsId.ParameterName = "@VenueId";
      bandsId.Value = this.GetId().ToString();
      cmd.Parameters.Add(bandsId);
      SqlDataReader rdr = cmd.ExecuteReader();

      List<Band> bandsPlayed = new List<Band>{};

      while(rdr.Read())
      {
        int bandId = rdr.GetInt32(0);
        string bandName = rdr.GetString(1);
        Band newBand = new Band(bandName, bandId);
        bandsPlayed.Add(newBand);
      }

      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
      return bandsPlayed;
    }

    public void AddBandToHistory(string bandName)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand ("INSERT INTO bands_venues (band_id, venue_id) OUTPUT INSERTED.id VALUES (@BandId, @VenueId);", conn);

      SqlParameter bandIdParameter = new SqlParameter();
      bandIdParameter.ParameterName = "@BandId";
      bandIdParameter.Value = Band.FindByName(bandName).GetId();
      cmd.Parameters.Add(bandIdParameter);

      SqlParameter venueIdParameter = new SqlParameter();
      venueIdParameter.ParameterName = "@VenueId";
      venueIdParameter.Value = this.GetId();
      cmd.Parameters.Add(venueIdParameter);
      cmd.ExecuteNonQuery();
      conn.Close();
    }

  }
}
