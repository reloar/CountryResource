# CountryResource

CountryResource Collection Scheme 

It's broken into three main processes
- Authentication
- CountryResource
- Test

## Authentication
-------------------

1. User Enters details
    - firstname
    - lastname
    - DateOfBirth
    - email
    - username
    -password
2. Server Verifies
    - validate user entry
    -server creates user
3.Login
  - server verifies user entry
  -server verifies user password
  -server assigns user token



## CountryResource
1. Create Country, User enters the details below with authorization header
Header; Authorization : Bearer "tokenString"
    - name
    - continent  
 Server Verifies
    - authorize user with right token
    - verifies and validates entry
    - server creates country
    - server returns status code and object model
    
2.Get countries, User sends request along with the authorization header
Header; Authorization : Bearer "tokenString"
  - authorize user with right token
  - server returns status code and data object with datecreated if exist
  
3.Update countries, user enters the details below with authorization header and query string

Header; Authorization : Bearer "tokenString"
query string : /countries/:id
    - name
    - continent  
 Server Verifies
    - authorize user with right token
    - validates entry
    - server verifies if entry id exist
    - server update country
    - server returns status code and object model
    
 4.Delete countries,user enters the details below with authorization header and query string
Header; Authorization : Bearer "tokenString"
query string : /countries/:id
    - name
    - continent  
 Server Verifies
    - authorize user with right token
    - validates entry
    - server verifies if entry id exist
    - server delete entry
    - server returns status code 

-----------------
# CountryResource Endpoints

## CountryResource Api
Development Url https://localhost:44356   where development url is the port on which the project is running on the server

Response<T> = { succeeded: boolean, message: string, result: T }

| Name                          | Method		| Controller				       | Url
| ----                          | ---			  | ---						           | -----
| Sign Up                       | POST			| Authentication				  | /api/signup
| login 					              | POST			| Authentication					| /api/login
| Create COuntry                | POST			  | Country						      | /api/countries
| Get All Countries             | GET			  | Country						      | /api/countries
| Get Country by ID             | GET			  | Country						      | /api/countries/{id: int}
| Update a Country              | PUT			  | Country						      | /api/countries/{id: int}
| Delete a Country              | DELETE			| Country						    | /api/countries/{id: int}



