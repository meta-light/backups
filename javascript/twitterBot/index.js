require("dotenv").config({ path: __dirname + "/.env" });
const { twitterClient } = require("./twitterClient.js")
const CronJob = require("cron").CronJob;
let mobilePrice = 0;
let dimoPrice = 0;
let dimoPriceUSD = 0;
let mobilePriceUSD = 0;
var currentDate = new Date();
var options = { year: 'numeric', month: '2-digit', day: '2-digit' };
var dateFormatter = new Intl.DateTimeFormat('en-US', options);
var formattedDate = dateFormatter.format(currentDate);



async function getMobilePrice() {
    const url = `https://price.jup.ag/v4/price?ids=mb1eu7TzEc71KxDpsmsKoucSSuuoGLv1drys1oP2jh6&vsToken=EPjFWdd5AufqSSqeM2qN1xzybapC8G4wEGGkZwyTDt1v`;
    const response = await fetch(url, { method: 'GET', headers: { 'accept': 'application/json' }});
    const data = await response.json();
    const MOBILEprice = data.data.mb1eu7TzEc71KxDpsmsKoucSSuuoGLv1drys1oP2jh6.price;
    mobilePrice = MOBILEprice;
    mobilePriceUSD = mobilePrice.toLocaleString('en-US', { style: 'currency', currency: 'USD' });
    console.log('MOBILE Price:', MOBILEprice);
}

async function getDimoPrice() {
    const url = 'https://api.portals.fi/v2/tokens?search=DIMO&sortDirection=asc&limit=25&page=0';
    const response = await fetch(url, { method: 'GET',  headers: { 'accept': 'application/json', 'Authorization': 'Bearer 934f72ec1d36cdff614c29dea4ca9bb0b77a72e5a1192564f6a879c01f95c890' }});
    const data = await response.json();
    const DIMOprice = data.tokens[1].price;
    dimoPrice = DIMOprice;
    dimoPriceUSD = dimoPrice.toLocaleString('en-US', { style: 'currency', currency: 'USD' });
    console.log('DIMO Price:', data.tokens[1].price);
}

const tweetContent = 
`${formattedDate} DEPIN Retail Hardware Report:

- A $20/month unlimited @helium_mobile plan earns ~$11.28/day 

- A $250 @helium_mobile indoor wifi hotspot earns ~$6.24/day `;

async function tweet() {
    await getMobilePrice();
    await getDimoPrice();
    console.log(dimoPriceUSD);
    console.log(mobilePriceUSD);
    console.log(tweetContent);
}

tweet();
// const tweet = async () => {
//   await getMobilePrice();
//   try {await twitterClient.v2.tweet(tweetContent);} catch (e) {console.log(e)}
// }

// const cronTweet = new CronJob("0 9 * * * *", async () => {tweet();});
  
// cronTweet.start();