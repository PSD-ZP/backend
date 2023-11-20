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


[URI] : **/Playground/GetPlaygroundsByCity?location={city}
city - f.e. Kosice, Bratislava

[Method] : **GET**
