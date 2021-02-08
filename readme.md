# DeviceManager

DeviceManager is a web application for managing devices.

## Description

### Front-end
The front-end application is an ASP.NET Core Web application written in C#. It has been implemented with the MVC pattern.
Bootstrap has been used to make UI user-friendly, along with Jquery.\
The front-end:
  - can read entries from the WebAPI and visualise them
  - allows editing existing entries
  - is able to add new entries
  - is able to delete existing entries


### Back-end
.NET Core WebAPI is used as the back-end written in C#. The WebAPI exposes all CRUD operations for the entity 'Device' as GET, POST, PUT, DELETE.\
EF Core has been used as the ORM and the in-memory database has been used to persist the data. A Json file having the intial devices data is read and used to seed the database.


## License
[MIT](https://choosealicense.com/licenses/mit/)