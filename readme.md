# DeviceManager

DeviceManager is an web application for managing various devices 

## Description

### Front-end
The front-end application is a ASP.NET Core Web application written in C#. It has been implemented with the MVC pattern.
Bootstrap has been used to make user-friendly UI, along with Jquery.
The front-end:
  - can read entries from the WebAPI and visualises them
  - allows editing existing entries
  - is able to add new entries
  - is able to delete existing entries


### Back-end
.NET Core WebAPI is used as the back-end written in C#. The WebAPI exposes CRUD operations for the entity 'Device'. 
EF Core has been used as the ORM and the in-memory database has been used to persist the data. A Json file having the intial devices data is read to seed the database.


## License
[MIT](https://choosealicense.com/licenses/mit/)