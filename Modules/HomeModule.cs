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
        return View["index.cshtml"];
      };
      Post["/venues/add"] = _ => {
        Venue newVenue = new Venue(Request.Form["venue-name"]);
        newVenue.Save();
        return View["index.cshtml"];
      };
      Get["/bands/venues/{id}"] = parameters => {
        Band bandModel = Band.Find(parameters.id);
        List<Venue> allVenues = Venue.GetAll();
        Dictionary<string, object> model = new Dictionary<string, object> {};
        model.Add("band", bandModel);
        model.Add("venues", allVenues);
        return View["bandsVenues.cshtml", model];
      };
      Get["/venues/bands/{id}"] = parameters => {
        Venue venueModel = Venue.FindById(parameters.id);
        List<Band> allBands = Band.GetAll();
        Dictionary<string, object> model = new Dictionary<string, object> {};
        model.Add("venue", venueModel);
        model.Add("bands", allBands);
        return View["venuesBands.cshtml", model];
      };
      Post["/bands/venues/add/{id}"] = parameters => {
        Band bandToAddTo = Band.Find(parameters.id);
        string venuePlayed = Request.Form["venue"];
        bandToAddTo.AddVenueToHistory(venuePlayed);
        List<Venue> allVenues = Venue.GetAll();
        Dictionary<string, object> model = new Dictionary<string, object> {};
        model.Add("band", bandToAddTo);
        model.Add("venues", allVenues);
        return View["bandsVenues.cshtml", model];
      };
      Post["/venues/bands/add/{id}"] = parameters => {
        Venue venueToAddTo = Venue.FindById(parameters.id);
        string bandPlayed = Request.Form["band"];
        venueToAddTo.AddBandToHistory(bandPlayed);
        List<Band> allBands = Band.GetAll();
        Dictionary<string, object> model = new Dictionary<string, object> {};
        model.Add("venue", venueToAddTo);
        model.Add("bands", allBands);
        return View["venuesBands.cshtml", model];
      };
    }
  }
}
