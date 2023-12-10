# Backend

FOR EVERY ISSUE CREATE BRANCH AND THAN PR

## Api

### Get weahter from last 4 hours

[URI] : **/Weather/GetWeatherOfLastHours**

[Method] : **POST**

[BODY] : 

```json
{
  "lat": "40.7128",
  "lon": "-74.0060"
}
```
or

```json
{
  "location": "New York"
}
```

### Get clothes

[URI] : **/Clothes/GetClothes**

[Method] : **POST**

[BODY] : 

```json
{
  "temp": 0,
  "wind": 0,
  "clouds": 0,
  "rain": 0,
  "snow": 90
}
```

### Get playgrounds by city/location


[URI] : **/Playground/GetPlaygrounds

[Method] : **POST**

[BODY] : 

```json
{
  "lat": "40.7128",
  "lon": "-74.0060"
}
```
or

```json
{
  "location": "New York"
}
```
[RESPONSE]

```json
[
    {
        "name": "Šmýkalka",
        "material": 1,
        "dryTime": -1.0,
        "description": null
    },
    {
        "name": "Hojdačka",
        "material": 0,
        "dryTime": -1.0,
        "description": null
    },
    {
        "name": "Pieskovisko",
        "material": 3,
        "dryTime": -1.0,
        "description": null
    },
    {
        "name": "Hojdací koník",
        "material": 2,
        "dryTime": -1.0,
        "description": null
    }
]
```

dryTime returns:
- -1 if dry time is more than 4 hours
or
- number of hours drying
