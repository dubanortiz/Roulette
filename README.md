#  ROULETTE
This project is a REST API for the generation and option of bets in different roulettes, as well as the query of the roulettes and their creation.
## Installation

 1. Clone the repository
```sh
$ git clone https://github.com/dubanortiz/Roulette.git
```
 2. Restore DataBase. found [here](https://github.com/dubanortiz/Roulette/blob/develop/Data/BackupDatos/Roulette.gz)
```sh
$ mongorestore  --host <IpYourHost> -u <UserName> -p <Password>  --authenticationDatabase <NameDatabaseAuthentication> --gzip --archive=<NameArchive.gz>
```
 3. Configure connection to mongodb in [environment](https://github.com/dubanortiz/Roulette/blob/develop/Properties/launchSettings.json)

> "environmentVariables": {        
>       "Host": "localhost",         
>        "Port": "27017",        
>        "UserName": "mongo",           
>        "Password": "12345678910"          
> }       

4. Run the project 
```sh
dotnet run
```
