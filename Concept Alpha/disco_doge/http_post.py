import json
from urllib import urlencode, quote_plus
from requests.auth import HTTPBasicAuth as BasAuth
import requests
import io


#This Part Generates the OAuth Token

scopes = 'CITYGUIDES DCIOFFERS DCIOFFERS_POST DCILOUNGES DCILOUNGES_POST DCILOUNGES_PROVIDER_LG DCILOUNGES_PROVIDER_DCIPL DCI_ATM DCI_CURRENCYCONVERSION DCI_CUSTOMERSERVICE DCI_TIP CITYGUIDES_HEALTHCHECK'
auth_url = 'https://apis.discover.com/auth/oauth/v2/token'
client_application_id = 'l7xxd564500498e44605979d2781162844d3'
client_application_secret = '08044974deb5499ca012c1e63e6847ee'
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


    headers = {  'Accept':'application/json',  'x-dfs-api-plan':'CITYGUIDES_SANDBOX',  'Authorization': auth_code  }


    request = requests.get(url, headers=headers)



    jdawg = request.json()


    with open(guide + '.json', 'w') as outfile:
        json.dump(jdawg, outfile, sort_keys = True, indent = 4)



    #with open('data.json') as data_json:
    #    data_loaded = json.load(data_json)


#ok Now We go to do the ATM sandbox



guides = ['healthcheck', 'locations']

for guide in guides:

    url = 'https://api.discover.com/dci/atm/v1/' + guide


    headers = {  'Accept':'application/json',  'x-dfs-api-plan':'DCI_ATM_SANDBOX',  'Authorization': auth_code  }


    request = requests.get(url, headers=headers)



    jdawg = request.json()


    with open('ATM' + guide + '.json', 'w') as outfile:
        json.dump(jdawg, outfile, sort_keys = True, indent = 4)


#Annnd Tip etticut





