using System.Collections.Generic;
using System;
using Nancy;
using Nancy.ViewEngines.Razor;

namespace BandTracker
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => {
        return View["index.cshtml"];
      };
      Get["/bands"] = _ => {
        List<Band> bandModel = Band.GetAll();
        return View["bands.cshtml", bandModel];
      };
      Get["/venues"] = _ => {
        List<Venue> venueModel = Venue.GetAll();
        return View["venues.cshtml", venueModel];
      };
      Get["/bands/add"] = _ => {
        return View["addBand.cshtml"];
      };
      Get["/venues/add"] = _ => {
        return View["addVenue.cshtml"];
      };
      Post["/bands/add"] = _ => {
        Band newBand = new Band(Request.Form["band-name"]);
        newBand.Save();
        List<Band> bandModel = Band.GetAll();
        return View["bands.cshtml", bandModel];
      };
      Post["/venues/add"] = _ => {
        Venue newVenue = new Venue(Request.Form["venue-name"]);
        newVenue.Save();
        List<Venue> venueModel = Venue.GetAll();
        return View["venues.cshtml", venueModel];
      };
      Get["/bands/venues/{id}"] = parameters => {
        Band bandModel = Band.Find(parameters.id);
        List<Venue> allVenues = Venue.GetAll();
        List<Venue> filteredVenues = new List<Venue> {};
        foreach (var venue in allVenues)
        {
          if (!bandModel.GetVenuesPlayed().Contains(venue))
          {
            filteredVenues.Add(venue);
          }
        }
        Dictionary<string, object> model = new Dictionary<string, object> {};
        model.Add("band", bandModel);
        model.Add("venues", filteredVenues);
        return View["bandsVenues.cshtml", model];
      };
      Get["/venues/bands/{id}"] = parameters => {
        Venue venueModel = Venue.FindById(parameters.id);
        List<Band> allBands = Band.GetAll();
        List<Band> filteredBands = new List<Band> {};
        foreach (var band in allBands)
        {
          if (!venueModel.GetBandsPlayed().Contains(band))
          {
            filteredBands.Add(band);
          }
        }
        Dictionary<string, object> model = new Dictionary<string, object> {};
        model.Add("venue", venueModel);
        model.Add("bands", filteredBands);
        return View["venuesBands.cshtml", model];
      };
      Post["/bands/venues/add/{id}"] = parameters => {
        Band bandToAddTo = Band.Find(parameters.id);
        string venuePlayed = Request.Form["venue"];
        bandToAddTo.AddVenueToHistory(venuePlayed);
        List<Venue> allVenues = Venue.GetAll();
        List<Venue> filteredVenues = new List<Venue> {};
        foreach (var venue in allVenues)
        {
          if (!bandToAddTo.GetVenuesPlayed().Contains(venue))
          {
            filteredVenues.Add(venue);
          }
        }
        Dictionary<string, object> model = new Dictionary<string, object> {};
        model.Add("band", bandToAddTo);
        model.Add("venues", filteredVenues);
        return View["bandsVenues.cshtml", model];
      };
      Post["/venues/bands/add/{id}"] = parameters => {
        Venue venueToAddTo = Venue.FindById(parameters.id);
        string bandPlayed = Request.Form["band"];
        venueToAddTo.AddBandToHistory(bandPlayed);
        List<Band> allBands = Band.GetAll();
        List<Band> filteredBands = new List<Band> {};
        foreach (var band in allBands)
        {
          if (!venueToAddTo.GetBandsPlayed().Contains(band))
          {
            filteredBands.Add(band);
          }
        }
        Dictionary<string, object> model = new Dictionary<string, object> {};
        model.Add("venue", venueToAddTo);
        model.Add("bands", filteredBands);
        return View["venuesBands.cshtml", model];
      };
      Get["bands/delete/{id}"] = parameters => {
        Band bandToDelete = Band.Find(parameters.id);
        return View["deleteBand.cshtml", bandToDelete];
      };
      Delete["bands/delete/{id}"] = parameters => {
        Band bandToDelete = Band.Find(parameters.id);
        bandToDelete.DeleteThis();
        List<Band> bandModel = Band.GetAll();
        return View["bands.cshtml", bandModel];
      };
      Get["venues/delete/{id}"] = parameters => {
        Venue venueToDelete = Venue.FindById(parameters.id);
        return View["deleteVenue.cshtml", venueToDelete];
      };
      Delete["venues/delete/{id}"] = parameters => {
        Venue venueToDelete = Venue.FindById(parameters.id);
        venueToDelete.DeleteThis();
        List<Venue> venueModel = Venue.GetAll();
        return View["venues.cshtml", venueModel];
      };
      Get["bands/edit/{id}"] = parameters => {
        Band bandToUpdate = Band.Find(parameters.id);
        return View["updateBand.cshtml", bandToUpdate];
      };
      Patch["bands/edit/{id}"] = parameters => {
        Band bandToUpdate = Band.Find(parameters.id);
        bandToUpdate.UpdateBandName(Request.Form["band-name"]);
        List<Band> bandModel = Band.GetAll();
        return View["bands.cshtml", bandModel];
      };
      Get["venues/edit/{id}"] = parameters => {
        Venue venueToUpdate = Venue.FindById(parameters.id);
        return View["updateVenue.cshtml", venueToUpdate];
      };
      Patch["venues/edit/{id}"] = parameters => {
        Venue venueToUpdate = Venue.FindById(parameters.id);
        venueToUpdate.UpdateVenueName(Request.Form["venue-name"]);
        List<Venue> venueModel = Venue.GetAll();
        return View["venues.cshtml", venueModel];
      };
    }
  }
}
