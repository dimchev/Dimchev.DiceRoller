dotnet ef migrations add InitialCreate -p Dimchev.DiceRoller.Auth.Infrastructure -s Dimchev.DiceRoller.Auth.WebApi
dotnet ef database update -p Dimchev.DiceRoller.Auth.Infrastructure -s Dimchev.DiceRoller.Auth.WebApi
dotnet ef migrations add InitialCreate -p Dimchev.DiceRoller.Operative.Infrastructure -s Dimchev.DiceRoller.Operative.WebApi
dotnet ef database update -p Dimchev.DiceRoller.Operative.Infrastructure -s Dimchev.DiceRoller.Operative.WebApi