// SPDX-License-Identifier: MIT
pragma solidity ^0.8.7;
import "@chainlink/contracts/src/v0.8/interfaces/AggregatorV3Interface.sol";
contract PriceConsumerV3 {
   AggregatorV3Interface internal priceFeedETHUSD;
   AggregatorV3Interface internal priceFeedBTCUSD;
   AggregatorV3Interface internal priceFeedLINKUSD;
   /**
    * Network: Goerli
    * Aggregator: ETH/USD
    * Address: 0xD4a33860578De61DBAbDc8BFdb98FD742fA7028e
    */
   constructor() {
       priceFeedETHUSD = AggregatorV3Interface(0xD4a33860578De61DBAbDc8BFdb98FD742fA7028e);
       priceFeedBTCUSD = AggregatorV3Interface(0xA39434A63A52E749F02807ae27335515BA4b07F7);
       priceFeedLINKUSD = AggregatorV3Interface(0x48731cF7e84dc94C5f84577882c14Be11a5B7456);
   }
   /**
    * Returns the latest price
    */
   function getLatestPriceETHUSD() public view returns (int) {
       (
           /*uint80 roundID*/,
           int ETHprice,
           /*uint startedAt*/,
           /*uint timeStamp*/,
           /*uint80 answeredInRound*/
       ) = priceFeedETHUSD.latestRoundData();
       return ETHprice;
   }

   function getLatestPriceBTCUSD() public view returns (int) {
       (
           /*uint80 roundID*/,
           int BTCprice,
           /*uint startedAt*/,
           /*uint timeStamp*/,
           /*uint80 answeredInRound*/
       ) = priceFeedBTCUSD.latestRoundData();
       return BTCprice;
   }

   function getLatestPriceLINKUSD() public view returns (int) {
       (
           /*uint80 roundID*/,
           int LINKprice,
           /*uint startedAt*/,
           /*uint timeStamp*/,
           /*uint80 answeredInRound*/
       ) = priceFeedLINKUSD.latestRoundData();
       return LINKprice;
   }


}
