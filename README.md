Не остана време за UI, тества се със swagger-а. За Operative service се натиска Authorize бутонът. 
Въвежда се токена върнат от логин в следния формат: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1lIjoiMTIzMTIzIiwiZmFtaWx5X25hbWUiOiIxMjMxMjMiLCJlbWFpbCI6InRlc3RAbWFpbC5jb20iLCJpZCI6ImNlZDI4MjIwLWY3YzItNDAyMi05MzcwLWE1NWQ0YTE5MTMxMCIsImV4cCI6MTcyNzQwNTcyNSwiaXNzIjoiRGltY2hldi5EaWNlUm9sbGVyLkF1dGguV2ViQXBpIiwiYXVkIjoiRGltY2hldi5EaWNlUm9sbGVyLk9wZXJhdGl2ZS5XZWJBcGkifQ.EHiXz6GwAZNYW-QvWscIFDfn9nxO_BGTD_qhTeDhLzA

при липса на sqlite db-та:
dotnet ef migrations add InitialCreate -p Dimchev.DiceRoller.Auth.Infrastructure -s Dimchev.DiceRoller.Auth.WebApi
dotnet ef database update -p Dimchev.DiceRoller.Auth.Infrastructure -s Dimchev.DiceRoller.Auth.WebApi
dotnet ef migrations add InitialCreate -p Dimchev.DiceRoller.Operative.Infrastructure -s Dimchev.DiceRoller.Operative.WebApi
dotnet ef database update -p Dimchev.DiceRoller.Operative.Infrastructure -s Dimchev.DiceRoller.Operative.WebApi