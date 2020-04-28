### Description ###

Simple .NET Core API project that demonstrates different methods for API versioning. API in this project is a slightly modified default .NET Core API project - a Weather Forecast example.

### Solution ###

There are several git branches in this solution where code in each git branch demonstrates one method of an API versioning in ASP.NET Core 3.0+.
For testing API in this solution, there is a Postman collection with HTTP requests provided. Switch between git branches, run the solution, and test with Postman.

### API versioning methods ###

One git branch demonstrates one API versioning method:

- master branch:
	- versioning by query string parameter AND/OR by HTTP header
	
- by-query-string
	- versioning by query string parameter
	
- by-http-header
	- versioning by HTTP header

- by-url-segment
	- versioning by URL path segment
	
- conventions
	- code in this branch demonstrates configuring API versioning using API version conventions
	- versioning by query string parameter AND/OR by HTTP header





