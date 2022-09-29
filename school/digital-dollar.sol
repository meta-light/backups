// SPDX-License-Identifier: GPL-3.0
pragma solidity ^0.8.4;
contract Coin {
    // The keyword "public" makes variables
    // accessible from other contracts
    address public minter;
    mapping (address => uint) public balances;
    mapping (address => uint) public SocialScore; // make this 3=good, 2=bad, 1=ugly
    address[] public WhiteListGood;
    address[] public WhiteListBad;
    address[] public WhiteListUgly;
    // Events allow clients to react to specific
    // contract changes you declare
    event Sent(address from, address to, uint amount);
    // Constructor code is only run when the contract
    // is created
    constructor() 
    {// it is always safe to send to the minter - me!
        minter = msg.sender;
        
        WhiteListUgly.push(minter);
        WhiteListBad.push(minter);
        WhiteListUgly.push(minter);
    }
    // Sends an amount of newly created coins to an address
    // Can only be called by the contract creator
    function mint(address receiver, uint amount) public 
    {
        require(msg.sender == minter);
        balances[receiver] += amount;
    }
    // Errors allow you to provide information about
    // why an operation failed. They are returned
    // to the caller of the function.
    error InsufficientBalance(uint requested, uint available);
    // Sends an amount of existing coins
    // from any caller to an address
    function send(address receiver, uint amount) public 
    {// only folks can receive if they are on the good lists.
        require (msg.sender == minter ||  checkWhiteListGood(receiver) || checkWhiteListBad(receiver) || checkWhiteListUgly(receiver));
        if (amount > balances[msg.sender])
        revert InsufficientBalance({
                requested: amount,
                available: balances[msg.sender]
                });
        if (   (SocialScore[msg.sender] == 3 && checkWhiteListGood(receiver))
            || (SocialScore[msg.sender] == 2 && checkWhiteListBad(receiver))
            || (SocialScore[msg.sender] == 1 && checkWhiteListUgly(receiver))
            )
        { 
            balances[msg.sender] -= amount;
            balances[receiver] += amount;
            emit Sent(msg.sender, receiver, amount);
        }
    }
        
    function checkWhiteListGood(address a) public view returns (bool) 
    {
        for (uint256 i = 0; i < WhiteListGood.length; i++) 
        {
            if (WhiteListGood[i] == a) 
            {
            return true;
            }
        }
        return false;
    }
    function checkWhiteListBad(address a) public view returns (bool) {
        for (uint256 i = 0; i < WhiteListBad.length; i++) 
        {
            if (WhiteListBad[i] == a) 
            {
                return true;
            }
        }
        return false;
    }
    function checkWhiteListUgly(address a) public view returns (bool) {
        for (uint256 i = 0; i < WhiteListUgly.length; i++) 
        {
            if (WhiteListUgly[i] == a) 
            {
                return true;
            }
        }
        return false;
    }
    function setPersonScore(address Person, uint Score) public 
    {
        require(msg.sender == minter);
        SocialScore[Person] = Score;
    }
    function addPersonToList(address Person, uint WL) public 
    {
    require(msg.sender == minter);
    if (WL == 3) 
    {
            WhiteListGood.push(Person);
        } 

        else if (WL == 2) 
        {
            WhiteListBad.push(Person); 
        } 

        else if (WL == 1) 
        {
            WhiteListUgly.push(Person);
        }
    }
}
