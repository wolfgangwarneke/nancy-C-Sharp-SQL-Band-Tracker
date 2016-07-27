# Band Tracker 6000

#### Keep track of venues the bands that play them, July 22nd, 2016_

#### By Wolfgang Warneke

## Description

This is a project for my C# class at Epicodus. Remember than one show? Me either, so let's check out our database of venues and bands to see if we can jog our collective memory. See all bands that have played a venue and when those shows were. See all venues that a band has played. Oh look now I remember, see, remember when Rumpleteaser played a sweet solo set at the Cat's Cradle on April, 20th, 2015? He was pretty sloppy due to his catnip problem around that time, but we still went out for saucers of milk afterword. Classy.

## Specifications
### General Specifications
| Behavior        | Input           | Outcome  |
| ------------- |:-------------:| -----:|
### Test Specifications
_(names used in actual tests may vary. the more puns = the merrier)_
#### Band Tests
| Test        | Method | Input           | Output (or outcome)  |
| ------------- |:----:|:-------------:| -----:|
| Database is initially empty | GetAll() | n/a | Count of entries is 0. |
| Two identical entries are treated as one entry. | Equals() | First band: "The Paw-lice", second band: "The Paw-lice" | First band is same as second band. |
| Saves new band to database | Save() | New band object | Band is written as new row entry in database |
| Clears all bands from database | DeleteAll() | n/a | all entries for 'bands' database table are removed |
| Removes one band from database | DeleteThis() | any band object | row containing this band's information is removed from database |
| Returns band by band id | Find() | (database of bands contains: "The Paw-Lice" with id of 9 and "Here Kitty Kitty" with id of 4) Band.Find(9) | Band object for "Here Kitty Kitty" |
| Changes band name to a new inputted name | UpdateName() | (band is called "Siamese Dream", gets sued by Billy Corgan from the Smashing Pumpkins for copyright infringement) this.UpdateName("The Bengals") | Band name is changed to The Bengals |
| bands_venues database is initially empty | GetAllPreviousVenues() | n/a | Count of entries list is 0. |
| Adds a band associated with venue called upon to bands_venues | AddVenueToHistory() | (band calling function is "The Fat Cats" with id of 5) venue: "Canary Hall", venue_id: 4 | band_id 5 and venue_id4 are recorded to bands_venues database; GetAllPreviousBands() returns list with count of 1 |
| Returns all venues which band has played | GetAllPreviousVenuesByName() | First venue name: "The Kitten Kaboodle" id: 4; second venue name: "The Feel Line" id: 0 (band "The Technicolor Dream Cats" adds both venues to its history) | returns list of the venue names |

#### Venue Tests
| Test        | Method | Input           | Output (outcome)  |
| ------------- |:----:|:-------------:| -----:|
| Database is initially empty | GetAll() | n/a | Count of entries is 0. |
| Two indentical entries are treated as one entry | Equals() | First venue: "The Milky Way"; Second venue: "Cat Fancy Theater" | First venue is same as second venue. |
| Saves new venue to database | Save() | New venue object | Venue is written as new row entry in database |
| Returns all venues from database | GetAll() | Constructs and saves first "Cat Fancy Theater" then "The Scratching Post" | Returns list containing the objects for "Cat Fancy Theater" and "The Scratching Post" |
| Clears all venues from database | DeleteAll() | n/a | all entries for 'venues' database table are removed |
| Removes one venue from database | DeleteThis() | any venue object | row containing this venue's information is removed from database|
| Returns venue by venue id | Find() | (Venues database table contains: "The Meow" with id of 2 and "The Yarn Ballroom" with id of 3) Venue.Find(2) | Venue object for "The Meow" |
| Changes venue name to a new inputted name | UpdateVenueName() | (venue is called "The Meow") this.UpdateVenueName("The Meow Meow") | Venue name is changed to "The Meow Meow" |
| bands_venues database is initially empty | GetAllPreviousBands() | n/a | Count of entries list is 0. |
| Adds a band associated with venue called upon to bands_venues | AddBandToHistory() | (venue calling function is "The Fat Cat" with id of 5) band: "Meowlissa Etheridge", band_id: 4 | band_id 4 and venue_id 5 are recorded to bands_venues database; GetAllPreviousBands() returns list with count of 1 |
| Returns all bands which have played this venue | GetAllPreviousBandsByName() | First band name: "Insane Cat Posse" id: 4; second band name: "Marilyn Meownson" id: 0 (venue "Kitty Kitty Bang Bang" adds both bands to history) | returns list of the bands' names |


## Setup/Installation Requirements

* Snap Your Fingers
* Do Your Stuff

_I'm going to tell you what to do. Don't worry._

## Known Bugs

_The only good bug is an nonexistent bug._

## Support and contact details

_Twitter: @wolfgangwarneke_

## Technologies Used

_This project uses C#, SQL, and the Nancy framework._

### License

Copyright (c) 2016 **Wolfgang Warneke**
