using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Xunit;

namespace BandTracker
{
  public class BandTest : IDisposable
  {
    public BandTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=band_tracker_test;Integrated Security=SSPI;";
    }
    [Fact]
      public void Test_GetAll_DatabaseEmptyAtFirst()
      {
        List<Band> emptyList = new List<Band> {};
        Assert.Equal(emptyList, Band.GetAll());
      }
    [Fact]
      public void Test_Equals_BandsWithSameNameAndIdAreEqual()
      {
        Band firstBand = new Band("Vet Shop Boys", 4);
        Band firstBandReplicant = new Band("Vet Shop Boys", 4);
        Assert.Equal(firstBand, firstBandReplicant);
      }
    [Fact]
      public void Test_Save_SavesBandsToDatabase()
      {
        Band saveThisBand = new Band("Cat Sabbath");
        saveThisBand.Save();
        Band retrievedBand = Band.GetAll()[0];
        Assert.Equal(saveThisBand.GetName(), retrievedBand.GetName());
      }
    [Fact]
      public void Test_DeleteAll_DeletesAllBandsInDatabase()
      {
        Band saveThisBand = new Band("Cat Sabbath");
        saveThisBand.Save();
        Band saveThisBandToo = new Band("Meow Meow Meows");
        saveThisBandToo.Save();
        Band.DeleteAll();
        Assert.Equal(0, Band.GetAll().Count);
      }
    [Fact]
      public void Test_DeleteThis_DeletesBandWhichCallsDeleteThis()
      {
        Band saveThisBand = new Band("DJ Meow Mix");
        saveThisBand.Save();
        Band saveThisBandToo = new Band("Chausie and the Banshees");
        saveThisBandToo.Save();
        saveThisBandToo.DeleteThis();
        Assert.Equal(1, Band.GetAll().Count);
      }
    public void Dispose()
    {
      Band.DeleteAll();
    }
  }
}
