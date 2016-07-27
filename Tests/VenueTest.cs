using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Xunit;

namespace BandTracker
{
  public class VenueTest : IDisposable
  {
    public VenueTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=band_tracker_test;Integrated Security=SSPI;";
    }
    [Fact]
      public void Test_GetAll_DatabaseEmptyAtFirst()
      {
        List<Venue> emptyList = new List<Venue> {};
        Assert.Equal(emptyList, Venue.GetAll());
      }
    [Fact]
      public void Test_Equals_VenuesWithSameNameAndIdAreEqual()
      {
        Venue firstVenue = new Venue("Catty Shack", 4);
        Venue firstVenueReplicant = new Venue("Catty Shack", 4);
        Assert.Equal(firstVenue, firstVenueReplicant);
      }
    [Fact]
      public void Test_Save_SavesVenuesToDatabase()
      {
        Venue saveThisVenue = new Venue("Catty Shack");
        saveThisVenue.Save();
        Venue retrievedVenue = Venue.GetAll()[0];
        Assert.Equal(saveThisVenue.GetName(), retrievedVenue.GetName());
      }
    [Fact]
      public void Test_DeleteAll_DeletesAllVenuesInDatabase()
      {
        Venue saveThisVenue = new Venue("Catty Shack");
        saveThisVenue.Save();
        Venue saveThisVenueToo = new Venue("The Litter Box");
        saveThisVenueToo.Save();
        Venue.DeleteAll();
        Assert.Equal(0, Venue.GetAll().Count);
      }
    [Fact]
      public void Test_DeleteThis_DeletesVenueWhichCallsDeleteThis()
      {
        Venue saveThisVenue = new Venue("Catty Shack");
        saveThisVenue.Save();
        Venue saveThisVenueToo = new Venue("The Litter Box");
        saveThisVenueToo.Save();
        saveThisVenueToo.DeleteThis();
        Assert.Equal(1, Venue.GetAll().Count);
      }
    [Fact]
      public void Test_FindById_FindVenueByDataBaseId()
      {
        Venue saveThisVenue = new Venue("The Lolcats Lounge");
        saveThisVenue.Save();
        Venue expectedVenueToFind = Venue.GetAll()[0];
        int idToFindBy = expectedVenueToFind.GetId();
        Venue foundVenue = Venue.FindById(idToFindBy);
        Assert.Equal(expectedVenueToFind, foundVenue);
      }
    [Fact]
      public void Test_FindByVenueName_FindVenueByName()
      {
        Venue saveThisVenue = new Venue("The Yarn Ballroom");
        saveThisVenue.Save();
        Venue expectedVenueToFind = Venue.GetAll()[0];
        string nameToFindBy = expectedVenueToFind.GetName();
        Venue foundVenue = Venue.FindByVenueName(nameToFindBy);
        Assert.Equal(expectedVenueToFind, foundVenue);
      }
    [Fact]
      public void Test_UpdateVenueName_ChangeNameFrom()
      {
        Venue firstVenue = new Venue("The Yarn Ballroom");
        firstVenue.Save();
        Venue secondVenue = new Venue("The Lolcats Lounge");
        secondVenue.Save();
        firstVenue.UpdateVenueName("Catty Shack");
        Venue firstVenueFromDatabase = Venue.FindById(firstVenue.GetId());
        Assert.Equal("Catty Shack", firstVenueFromDatabase.GetName());
      }
    [Fact]
      public void Test_GetBandsPlayed_ReturnEmptyVenueList()
      {
        Venue saveThisVenue = new Venue("Catty Shack");
        saveThisVenue.Save();
        List<Band> testBandsList = saveThisVenue.GetBandsPlayed();
        Assert.Equal(0, testBandsList.Count);
      }
    [Fact]
      public void Test_AddBandToHistory_SaveVenueIdAndBandIdToDatabase()
      {
        Venue saveThisVenue = new Venue("Meow That's What I Call Music");
        saveThisVenue.Save();
        Band testBand = new Band("Feline Dion");
        testBand.Save();
        saveThisVenue.AddBandToHistory("Feline Dion");
        List<Band> testBandList = saveThisVenue.GetBandsPlayed();
        List<Band> expectedBandList = new List<Band> { testBand };
        Assert.Equal(expectedBandList[0], testBandList[0]);
      }
    [Fact]
      public void Test_Add2VenuesToHistory_SaveBandIdsAndVenueIdToDatabase()
      {
        Venue saveThisVenue = new Venue("Meow That's What I Call Music");
        saveThisVenue.Save();
        Band testBand = new Band("Feline Dion");
        testBand.Save();
        saveThisVenue.AddBandToHistory("Feline Dion");
        Band secondTestBand = new Band("Elvis Pawresly");
        secondTestBand.Save();
        saveThisVenue.AddBandToHistory("Elvis Pawresly");
        List<Band> testBandList = saveThisVenue.GetBandsPlayed();
        List<Band> expectedBandList = new List<Band> { testBand, secondTestBand };
        Assert.Equal(expectedBandList, testBandList);
      }
    public void Dispose()
    {
      Band.DeleteAll();
      Venue.DeleteAll();
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand ("DELETE FROM bands_venues;", conn);
      cmd.ExecuteNonQuery();
      conn.Close();
    }
  }
}
