import tweepy
import time


#Meta Light Bot Auth Keys
consumer_key = "" #api key
consumer_secret = "" #api password
key = '' # consumer key
secret = '' #

auth = tweepy.OAuthHandler(consumer_key, consumer_secret)
auth.set_access_token(key, secret)
api = tweepy.API(auth)

hashtag = "#HNT"
tweetNumber = 1

tweets = tweepy.Cursor(api.search_tweets, hashtag).items(tweetNumber)

def searchBot():
    for tweet in tweets:
        try:
            # tweet.retweet()
            print(tweet)
            print("Retweet Done!!")
            time.sleep(3600)
        except tweepy.TweepError as e:
            print(e.reason)
            time.sleep(3600)
searchBot()
