pragma solidity >=0.4.22 <0.7.0;

contract SimpleAuction {
    address payable public beneficiary;
    uint public auctionEndTime;
    uint public secondHighest;
    address public highestBidder;
    uint public highestBid;
    mapping(address => uint) pendingReturns;
    bool ended;

    event HighestBidIncreased(address bidder, uint amount);
    event AuctionEnded (address winner, uint amount);
    constructor() public {
        
        uint _biddingTime; 
        address payable _beneficiary;
        beneficiary = _beneficiary;
        auctionEndTime = now + _biddingTime;
    }

    function bid() public payable {
        require(
            now <= auctionEndTime,
            "The auction has ended"
            );

        require(
            msg.value > highestBid,
            "There is a higher bidder"
            );

        if (highestBid != 0) {
            pendingReturns[highestBidder] += highestBid;
        }
        highestBidder = msg.sender;
        highestBid = msg.value;
        secondHighest = (highestBid - msg.value);
        emit HighestBidIncreased(msg.sender, msg.value);
    }

 
    function withdraw() public returns (bool) {
        uint amount = pendingReturns[msg.sender];
        if (amount > 0) {
            pendingReturns[msg.sender] = 0;

            if (!msg.sender.send(amount)) {
                pendingReturns[msg.sender] = amount;
                return false;
            }
        }
        return true;
    }

    mapping(address => uint256) public userBalance;
    function transfer(address from, address to, uint256 amountTransfers) public {
        userBalance[to] += amountTransfers;
        userBalance[from] -= amountTransfers;

         if (amountTransfers >= highestBid) {
            transfer(beneficiary, highestBidder, secondHighest);
            secondHighest = highestBid;
            highestBid = amountTransfers;
            highestBidder = msg.sender;
            transfer(highestBidder, beneficiary, secondHighest);
        } else if (amountTransfers > secondHighest) {
            transfer(beneficiary, highestBidder, secondHighest);
            secondHighest = amountTransfers;
            transfer(highestBidder, beneficiary, secondHighest);
       }
        
    }

    function auctionEnded() public {
        require(now >= auctionEndTime, "Auction hasn't ended yet."); 
        require(!ended, "auctionEnd has already been called."); 
        ended = true;
        emit AuctionEnded(highestBidder, highestBid);
        beneficiary.transfer(secondHighest);
    }


}
