#OAuth2 Proof of Concept

##References:
*Creating the simplest OAuth2 Authorization Server, Client and API
https://identityserver.github.io/Documentation/docsv2/overview/simplestOAuth.html

*Generating and consuming JSON Web Tokens with .NET
https://vosseburchttechblog.azurewebsites.net/index.php/2015/09/19/generating-and-consuming-json-web-tokens-with-net/


Request Access Token:

POST /connect/token HTTP/1.1
Host: localhost:5000
Content-Type: application/x-www-form-urlencoded
Cache-Control: no-cache
Postman-Token: 857aa65e-d430-1ed1-dce9-3176f889e111

client_id=clientOnly&client_secret=34E2E487-2954-4CFA-AC52-B6D048AA645D&grant_type=client_credentials&scope=api1


Request Resource:

GET /test HTTP/1.1
Host: localhost:5863
Authorization: Bearer 8bce109884b597de72e0fdcaed3bf3cb
Cache-Control: no-cache
Postman-Token: 1eff5cd1-b670-ba6e-1b54-30472515f03b

