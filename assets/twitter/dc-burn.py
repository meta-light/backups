import tweepy
import os
import requests as r
import time
#Meta Light Bot Auth Keys
consumer_key = "" #api key
consumer_secret = "" #api password
key = '' # consumer key
secret = '' # consumer password

# Authentication with Twitter
auth = tweepy.OAuthHandler(consumer_key, consumer_secret)
auth.set_access_token(key, secret)
api = tweepy.API(auth)


def dc_burn():
#Counts Total # Witnesses ever 3 days
    url = "https://api.helium.io/v1/dc_burns/sum?min_time=-1%20day&bucket=hour"
    headers = {'User-Agent': 'a1projects/1.0',}
    # request = urllib.request.Request(url, headers=headers)
    response = r.get(url, headers=headers)#.json()
    if str(response) == "<Response [200]>":
        time.sleep(.6)
        response = response.json()
        # response = urllib.request.urlopen(request)
        # assets = json.loads(response.read())
        dc = response["data"][0]["total"]
        yo = dc/100000
        print(f"DC: {dc}. ${yo}")
        print(f"A total of {dc:,.0f} HNT Data Credits have been burned in the last hourly period, worth a total of ${yo:,.2f}!")
        api.update_status(f"A total of {dc:,.0f} HNT Data Credits have been burned in the last hourly period, worth a total of ${yo:,.2f}!")
dc_burn()
