import json
from urllib import urlencode, quote_plus
from requests.auth import HTTPBasicAuth as BasAuth
import requests
import io
import configparser
from configparser import SafeConfigParser as parsedawg

parsedawg = parsedawg()

parsedawg.read('config.ini')

print(parsedawg.sections())

print(parsedawg.get('main','scopes'))


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



#This Part Generates the OAuth Token

scopes = parsedawg.get('main','scopes')
auth_url = 'https://apis.discover.com/auth/oauth/v2/token'
client_application_id = parsedawg.get('main','client_application_id')
client_application_secret = parsedawg.get('main','client_application_secret')
content_header = {'Content-Type' : 'application/x-www-form-urlencoded'}
payload = {'grant_type' : 'client_credentials', 'scope' : scopes}
auth_post = requests.post(auth_url, auth=BasAuth(client_application_id, client_application_secret), headers=content_header, data=payload)

auth_status_json = auth_post.json()


auth_code =  auth_status_json["token_type"] + ' ' + auth_status_json['access_token']

print auth_code


#Here is Where we need to find a way to enumerate all the API calls



#Right Now It only does the Citiguides


plans = ['CITYGUIDES_SANDBOX', 'DCI_ATM_SANDBOX', 'DCI_TIPETIQUETTE_SANDBOX']


guides = ['healthcheck', 'merchants', 'cities', 'catagories']

for guide in guides:

    url = 'https://api.discover.com/cityguides/v2/' + guide

    print(url)



    headers = {  'Accept':'application/json',  'x-dfs-api-plan':'CITYGUIDES_SANDBOX',  'Authorization': auth_code  }


    request = requests.get(url, headers=headers)



    jdawg = request.json()


    print(jdawg)


    with open(guide + '.txt', 'w') as outfile:
        json.dump(jdawg, outfile, sort_keys = True, indent = 4)

    with open(guide + '.json', 'w') as outfile:
        json.dump(jdawg, outfile, sort_keys = True, indent = 4)



    #with open('data.json') as data_json:
    #    data_loaded = json.load(data_json)


#ok Now We go to do the ATM sandbox



# guides_2 = ['locations']

# for guide in guides_2:
#
#     url = 'https://api.discover.com/dci/atm/v1/' + guide
#
#     queryParams = '?' + urlencode(
#         {quote_plus('radius'): '999', quote_plus('longitude'): '-0.118855', quote_plus('latitude'): '51.508061'})
#
#     headers = {  'Accept':'application/json',  'x-dfs-api-plan':'DCI_ATM_SANDBOX',  'Authorization': auth_code  }
#
#
#     request = requests.get(url + queryParams, headers=headers)
#
#
#
#     jdawg = request.json()
#
#     latLong = atmLocations(request.json())
#
#
#
#
#     with open('ATM' + guide + '.txt', 'w') as outfile:
#         json.dump(jdawg, outfile, sort_keys = True, indent = 4)
#
#
#     with open('ATM_Parsed_London' + guide + '.txt', 'w') as outfile:
#         for item in latLong:
#             outfile.write("%s\n" % item)




#Annnd Tip etticut


# guides_3 = ['guide']
#
# for guide in guides_3:
#
#     url = 'https://api.discover.com/dci/tip/v1/guide'
#
#     headers = {'Accept': 'application/json', 'x-dfs-api-plan': 'DCI_TIPETIQUETTE_SANDBOX',
#                'Authorization': auth_code}
#
#     request = requests.get(url, headers=headers)
#
#
#
#     jdawg = request.json()
#
#
#     with open('TIP' + guide + '.txt', 'w') as outfile:
#         json.dump(jdawg, outfile, sort_keys = True, indent = 4)















