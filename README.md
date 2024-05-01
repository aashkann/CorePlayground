# CorePlayground
 .NETCore Web app API examples with [Supabae](supabase.com) postgreSQL.
 
 Learn more about C# client [here](https://github.com/supabase/postgres) and in the [documentation](https://supabase.com/docs/reference/csharp/initializing)

 Learn how CRUD works in .NETCore in [Milan's Youtube's video](https://www.youtube.com/watch?v=uviVTDtYeeE&t=344s&ab_channel=MilanJovanovi%C4%87)
## Your appsettings.json shoule be like:
```
{
  "ConnectionStrings": {
    "DefaultConnection": "YOUR DEFAULT"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "Supabase": {
    "Url": "YOUR-URL",
    "Key": "YOUR-KEY"
  }
}
```


License
This project is licensed under the Apache License, Version 2.0. See the [LICENSE file for more details](https://github.com/aashkann/CorePlayground/blob/main/LICENSE).
