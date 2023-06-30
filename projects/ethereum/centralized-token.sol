// SPDX-License-Identifier: GPL-3.0
// Original - https://docs.soliditylang.org/en/v0.8.7/introduction-to-smart-contracts.html#subcurrency-example
pragma solidity ^0.8.4;

contract Homework1DD {
    address public minter;
    mapping (address => uint) public balances;
    mapping (address => uint) public SocialScore;
    mapping (address => bool) public WhiteList; 
	//(address => mapping(address => bool)??
		event Sent(address from, address to, uint amount); 
	// Only runs on contract creation
    constructor() { 
        minter = msg.sender; 
    }

		function CreateNewAccount(address CreateNewUser) public {
					balances[CreateNewUser] = 0;
					SocialScore[CreateNewUser] = 5;
					WhiteList[CreateNewUser] = true;
		}

    function mint(address receiver, uint amount) public {
	// Sends  newly created coins to an address, only called by contract creator
        require(msg.sender == minter);
        balances[receiver] += amount;
    }

	// Errors allow you to rovide information about why an operation failed. 
	// They are returned to the caller of the function.
    error InsufficientBalance(uint requested, uint available);
		error NotWhiteListed(bool listed);
		error nonSender(uint score);
		error nonReceiver(uint score);

	// Sends an amount of existing coins from any caller to an address
    function send(address receiver, uint amount) public {
        
					if (amount > balances[msg.sender])
            revert InsufficientBalance({
                requested: amount,
                available: balances[msg.sender]
           });
					if (WhiteList[receiver] == false)
            revert NotWhiteListed({
                listed: WhiteList[receiver]
           });
          if (SocialScore[msg.sender] <= 1)
            revert nonSender({
                score: SocialScore[msg.sender]
           });
          if (SocialScore[receiver] <= 1)
            revert nonReceiver({
                score: SocialScore[receiver]
           });

		// require receiver is on whitelist of sender
        balances[msg.sender] -= amount;
        balances[receiver] += amount;
        emit Sent(msg.sender, receiver, amount);
    }

	// clear acct function
    function CleanAcct(address account) public {
        require(msg.sender == minter);
        balances[account] = 0;
    }
}
