### Description ###

Simple .NET Core API project that demonstrates different methods for API versioning. API in this project is a slightly modified default .NET Core API project - a Weather Forecast example.

### Solution ###

There are several git branches in this solution where code in each git branch demonstrates one method of an API versioning in ASP.NET Core 3.0+.
For testing API in this solution, there is a Postman collection with HTTP requests placed in the **master** branch. Switch between git branches, run the solution, and test with Postman.

### API versioning methods ###

One git branch demonstrates one API versioning method:

- **master** branch:
	- versioning by query string parameter AND/OR by HTTP header

```cs
	services.AddApiVersioning(options => {
		options.DefaultApiVersion = new ApiVersion(1, 1);
		options.AssumeDefaultVersionWhenUnspecified = true;
		options.ReportApiVersions = true;
		options.ApiVersionReader = ApiVersionReader.Combine(
						new QueryStringApiVersionReader("v"),
						new HeaderApiVersionReader("v"));
	});
```	

- **by-query-string** branch:
	- versioning by query string parameter

```cs
	services.AddApiVersioning(options => {
		options.DefaultApiVersion = new ApiVersion(1, 1);
		options.AssumeDefaultVersionWhenUnspecified = true;
		options.ReportApiVersions = true;
		options.ApiVersionReader = new QueryStringApiVersionReader("v");
	});
```	
	
- **by-http-header** branch:
	- versioning by HTTP header

```cs
	services.AddApiVersioning(options => {
		options.DefaultApiVersion = new ApiVersion(1, 1);
		options.AssumeDefaultVersionWhenUnspecified = true;
		options.ReportApiVersions = true;
		options.ApiVersionReader = new HeaderApiVersionReader("v");
	});
```	

- **by-url-segment** branch:
	- versioning by URL path segment

```cs
	services.AddApiVersioning(options => {
		options.DefaultApiVersion = new ApiVersion(1, 1);
		options.AssumeDefaultVersionWhenUnspecified = true;
		options.ReportApiVersions = true;
		options.ApiVersionReader = new UrlSegmentApiVersionReader();
	});
```	
	
- **conventions** branch:
	- code in this branch demonstrates configuring API versioning using API version conventions
	- versioning by query string parameter AND/OR by HTTP header

```cs
	services.AddApiVersioning(options => {
		options.DefaultApiVersion = new ApiVersion(1, 1);
		options.AssumeDefaultVersionWhenUnspecified = true;
		options.ReportApiVersions = true;
		options.ApiVersionReader = ApiVersionReader.Combine(
						new QueryStringApiVersionReader("v"),
						new HeaderApiVersionReader("v"));
		
		options.Conventions.Controller<WeatherForecastController>()
		   .HasDeprecatedApiVersion(1, 0)
		   .HasApiVersion(1, 1)
		   .HasApiVersion(2, 0)
		   .Action(c => c.Get1_0()).MapToApiVersion(1, 0)
		   .Action(c => c.Get1_1()).MapToApiVersion(1, 1)
		   .Action(c => c.Get2_0()).MapToApiVersion(2, 0);
	});
```	
