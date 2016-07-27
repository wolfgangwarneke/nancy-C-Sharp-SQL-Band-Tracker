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
    // [Fact]
    //   public void Test_GetAll_DatabaseEmptyAtFirst()
    //   {
    //     List<Band> emptyList = new List<Band> {};
    //     Assert.Equal(emptyList, Band.GetAll());
    //   }
    public void Dispose()
    {
      // Band.DeleteAll();
    }
  }
}
