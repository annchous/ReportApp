# Report App

This project was carried out as part of the laboratory work on object-oriented programming No. 6 at ITMO University.

Task description: [reports.pdf](https://github.com/annchous/ReportApp/blob/master/reports.pdf)

The application is designed in accordance with a multi-layer (three-layer) architecture:
* [Data Access Layer (DAL)](https://github.com/annchous/ReportApp/tree/master/ReportApp.DAL)
* [Business Logic Layer (BLL)](https://github.com/annchous/ReportApp/tree/master/ReportApp.Core)
* [Presentation Layer aka UI](https://github.com/annchous/ReportApp/tree/master/ReportApp)


### Data Access Layer (DAL)

![dal](https://github.com/annchous/ReportApp/blob/master/staff/dal.png)


This layer provides access to data stored in the database. Technology **Entity Framework** and **Repository** pattern are used to interact with objects.

Contains:
* [Context](https://github.com/annchous/ReportApp/tree/master/ReportApp.DAL/Context)
* [Entities](https://github.com/annchous/ReportApp/tree/master/ReportApp.DAL/Entities)
* [Interfaces for Repository pattern](https://github.com/annchous/ReportApp/tree/master/ReportApp.DAL/Interfaces)
* [Repositories realisations](https://github.com/annchous/ReportApp/tree/master/ReportApp.DAL/Repositories) for each entity
* [Tools](https://github.com/annchous/ReportApp/tree/master/ReportApp.DAL/Tools) : enums to reflect the state of some entities


### Business Logic Layer (BLL)

![bll](https://github.com/annchous/ReportApp/blob/master/staff/bll.png)


The presentation layer works with the data stored in the database not directly, but through the **Business Logic Layer**.

Here, through the **services**, the database entities are converted to **Data Transfer Object (DTO)** and provided for further interaction with the user to the **Presentation Layer** layer.

Contains:
* [DTO]()
* [Interfaces for Services]()
* [Services realisations]()
* [Mappers]() for mapping using `AutoMapper` libary


### Presentation Layer (aka UI)

![pl](https://github.com/annchous/ReportApp/blob/master/staff/pl.png)


Direct user interaction layer. Made with technology Blazor WebAssembly (hosted on ASP.NET Core).

The **Server** side of the application contains [API Controllers](https://github.com/annchous/ReportApp/tree/master/ReportApp/Server/Controllers). The **Client** part contains [page layout](https://github.com/annchous/ReportApp/tree/master/ReportApp/Client/Pages).
