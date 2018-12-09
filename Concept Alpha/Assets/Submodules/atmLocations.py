import json
import requests
from urllib.parse import urlencode, quote_plus

def atmLocations(theJson):
    latLong = []
    for item in theJson:
        tmp = []
        for k, v in item.items():
            if k == "name":
                tmp.append(v)
            if k == "latitude":
                tmp.append(v)
            if k == "longitude":
                tmp.append(v)
        latLong.append(tmp)
    return latLong

def main():
    url = 'https://api.discover.com/dci/atm/v1/locations'
    queryParams = '?' + urlencode({ quote_plus('radius') : '20' ,quote_plus('longitude') : '-122' ,quote_plus('latitude') : '47'    })
    headers = {  'Accept':'application/json',  'x-dfs-api-plan':'DCI_ATM_SANDBOX',  'Authorization':'Bearer 57e04042-fe68-4ccd-9e8d-4014fe0428bc'}

    request = requests.get(url + queryParams, headers=headers)

    latLong = atmLocations(request.json())
    print(latLong)

if __name__ == "__main__":
    main()
