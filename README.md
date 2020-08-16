# Police Data API 
Use the Police Data API to return information on Street Level Crimes

## How to Run
1. Ensure .NET Core is [downloaded](https://dotnet.microsoft.com/download/dotnet-core)
2. Clone repo locally
3. Open console, navigate to project and enter the command: `dotnet run`
4. Open Postman and run the below endpoints OR hit F5 and enter the endpoints in the browser

## Brief
### At present the following data is returned:

**Return all Street Level Crimes for a specific location**

When running locally, hit the endpoint - http://localhost:5000/api/streetcrime

###### status: complete

**Return a specific Street Crime by Id**

When running locally, hit the endpoint - http://localhost:5000/api/streetcrime/GetStreetCrimeById/{id}

_Example Id to use for testing purposes: 84551281_


###### status: complete

**Return a list of Street Level Crimes by Category**

When running locally, hit the endpoint - http://localhost:5000/api/streetcrime/GetStreetCrimesByCategory/{category}

_Example Category to use for testing purposes: 'burglary'_

###### status: complete

**Return a list of Street Level Crimes by Date**

When running locally, hit the endpoint - http://localhost:5000/api/streetcrime/GetStreetCrimeByLocationAndDate/{date}

_Example Date to use for testing purposes: 2019-01 (format needs to be YYYY-MM)_

###### status: complete

**Return a list of Street Level Crimes by Date and Category**

When running locally, hit the endpoint - http://localhost:5000/api/streetcrime/GetStreetCrimesByLocationAndCategoryAndTime/{category}/{date}

_Example Category and Date to use for testing purposes: 'burglary' & 2019-01_

###### status: complete

## Example Street Level Crime JSON object:

`    {
        "category": "burglary",
        "location_type": "Force",
        "location": {
            "latitude": "52.635598",
            "street": {
                "id": 883314,
                "name": "On or near Yeoman Lane"
            },
            "longitude": "-1.129330"
        },
        "context": "",
        "outcome_status": {
            "category": "Under investigation",
            "date": "2020-06"
        },
        "persistent_id": "13ca4a2848698805d31004363aad26dd7515a7208a143ea9f8d9bd9fe0b6f89c",
        "id": 84552314,
        "location_subtype": "",
        "month": "2020-06"
    }`

## Possibilities with the data
- Each JSON Object has an `'outcome_status'`, so we can quickly work out how many crimes have been resolved
- We can also use this to see how long, on average, a certain type of crime takes to solve

## Next Steps
- Use the [Crime Categories API](https://data.police.uk/docs/method/crime-categories/) to return a full list of Categories (this will allow a drop-down list of options)
- Use the [Street Level Outcomes API](https://data.police.uk/docs/method/outcomes-at-location/) to garner more details on a Street Level Crime's resolution by matching the Ids
