# CQRSBookingSystem

Example application demonstrating the use of CQRS and Event Sourcing within the domain of a holiday inn bookings.

This project is a sandbox for exploring how CQRS+ES affects the design of a system.

## Running
This is an ASP.NET MVC web application using SQL Server.  SQL Server is used to store Events and current state of the bookings.

The SQL Server table designs and stored procedures are in the HolidayInnDB project.  Update the connectionstring in the web.config to point to the correct database.


