# TODOList
A simple online todo list built with .net core 3.0 and angular 8

## Architecture

- Opted for a N tier application approach made of UI, Service and Repository.
- Backend uses generic repository and unit of work pattern.
- The data is a persisted in a singleton object (**IDbContext**) which is configured in **Startup.cs**.
- Dependency injection is handled by ASP.NET core.
- All data is kept for as long as the IIS application is up.
- Login is handled by **AuthenticationController.Authenticate** 
- A cookie is created when a user logs in and their information is kept in **HttpContext**.
- Any attempt to reach any endpoint in **UserTasksController** by an unauthorized user will result in a 401 response.
- Frontend handles 401 responses by redirecting users back to the login page.
- Sensitive information such as userID is always securely fetched from HttpContext.

## Testing

A single user exists in the database object

```
username test
password pwd123
```

## TODO

- First of all let user paginate and order results
- Unit test repository
- Unit test angular services
- Consider keeping passwords in db as hash instead of text. Use HMAC to generate and validate them.
- Maybe implement a Jwt token and validate it in every http request.
- Create an angular component to handle http errors. It should show messages on a snackbar and then redirect users to login page when getting a 401
- Let users select/deselect all lines at once by using a header checkbox 
