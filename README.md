
# Insagranny Dashboard

Dashboard created as an extension for the Instagranny platform, for network usage display and 
admin manging tasks.




## Features

Open for public: 
- Live open network statistics (number of Instagranny registered/active users, newest/oldest users, total of posts, comments etc.)
- User list 
- User details page with additional information
- Posts list 

"Staff only" features:
- Log in, Log out system
- Register additional staff account
- Edit Profile details (username, bio)
- Delete Instagranny users 
- Delete Instagranny posts


## Technologies used:

- ASP.NET Core w Razor Pages
- ASP.NET Core Identity
- Entity Framework Core
- SQLite
- HTML
- CSS / Bootstrap

## Usage

Project comes with a cloned SQLite database structure, for testing purposes. Please make sure 
to update the connection string for the SQLite database that runs in the Instagranny project for consistent data synchronization.

appsettings.json
```c#
"ConnectionStrings": {
    "DefaultConnection": "Data Source=db.sqlite3",        <- change path here
    "ApplicationDbContextConnection": "Data Source=db.sqlite3"  <- and here
  },

```