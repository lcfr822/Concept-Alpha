import requests
from requests.auth import HTTPBasicAuth as BasAuth

scope = 'CITYGUIDES_HEALTHCHECK'
auth_url = 'https://apis.discover.com/auth/oauth/v2/token'
client_application_id = 'l7xxd564500498e44605979d2781162844d3'
client_application_secret = '08044974deb5499ca012c1e63e6847ee'
content_header = {'Content-Type' : 'application/x-www-form-urlencoded'}
payload = {'grant_type' : 'client_credentials', 'scope' : scope}
auth_post = requests.post(auth_url, auth=BasAuth(client_application_id, client_application_secret), headers=content_header, data=payload)
#headers = {  'Accept':'application/json',  'x-dfs-api-plan':'CITYGUIDES_SANDBOX',  'Authorization':'Bearer 5c6712aa-a9b1-455a-a2fe-a114cf503b44'  }
#url = requests.get('https://api.discover.com/cityguides/v2/healthcheck', headers=headers)
print(auth_post.text)
