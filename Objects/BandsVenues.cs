using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace BandTracker
{
  public class BandsVenues
  {
    // private int _id;
    // private int _bandId;
    // private int _venueId;
    //
    // public BandsVenues(int bandId, int venueId, int id = 0)
    // {
    //   this.SetName(name);
    //   this.SetId(id);
    // }

    // public void SetId(int id)
    // {
    //   _id = id;
    // }
    //
    // public int GetId()
    // {
    //   return _id;
    // }
    //
    // public void SetName(string name)
    // {
    //   _name = name;
    // }
    //
    // public string GetName()
    // {
    //   return _name;
    // }

    public static List<Venue> GetAllBandsVenues(int queryBandId)
    {
      List<Venue> everyVenueForThisBand = new List<Venue> {};
      SqlConnection conn = DB.Connection();
      SqlDataReader rdr = null;
      conn.Open();
      SqlCommand cmd = new SqlCommand("SELECT band_id,venue_id FROM bands_venues;", conn);
      rdr = cmd.ExecuteReader();
      while(rdr.Read())
      {
        int bandId = rdr.GetInt32(0);
        int venueId = rdr.GetInt32(1);
        // if ( bandId == queryBandId )
        // {
        everyVenueForThisBand.Add(Venue.FindById(venueId));
        // }
      }
      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
      Console.WriteLine("hello");
      return everyVenueForThisBand;
    }

  }
}
