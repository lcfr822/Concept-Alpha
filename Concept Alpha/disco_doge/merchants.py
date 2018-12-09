# Name Lat Long Type
import json
import requests
from urllib.parse import urlencode, quote_plus

def shopInfo(each, name):
    tmp = []
    tmp.append(name)
    tmp.append(each.get('name'))
    tmp.append(each.get('point'))
    return tmp

def merchant(restaurants, retails):
    merchants = []
    for each in restaurants.get('result'):
        merchants.append(shopInfo(each, 'restaurant'))
    for each in retails.get('result'):
        merchants.append(shopInfo(each, 'retail'))

    print(merchants)

def call(category):
    url = 'https://api.discover.com/cityguides/v2/merchants'
    queryParams = '?' + urlencode({ quote_plus('card_network') : 'DCI' ,quote_plus('merchant_city') : 'London' ,                      quote_plus('merchant_category') : category ,quote_plus('has_privileges') : 'false' ,quote_plus('sortby') : 'name' , quote_plus('sortdir') : 'asc'    })
    headers = {  'Accept':'application/json',  'x-dfs-api-plan':'CITYGUIDES_SANDBOX',  'Authorization':'Bearer 5e8378cc-9e39-4710-874b-c61b33031442'    }

    request = requests.get(url + queryParams, headers=headers)
    return request

def main():
    restaurants = call('restaurants')
    retail = call('retail')
    merchant(restaurants.json(), retail.json())

if __name__ == "__main__":
    main()
