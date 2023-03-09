
 //Save the address of the contract actually deployed
        const contractAddress = "0x7899091928868f99FfA0Ed273402943f954a7130";
        
//Copy the ABI from the smart contract in Remix
        const abiInfo = [
            {
                "constant": false,
                "inputs": [
                    {
                        "name": "message",
                        "type": "string"
                    }
                ],
                "name": "updateMessage",
                "outputs": [],
                "payable": false,
                "stateMutability": "nonpayable",
                "type": "function"
            },
            {
                "constant": true,
                "inputs": [],
                "name": "theMessage",
                "outputs": [
                    {
                        "name": "",
                        "type": "string"
                    }
                ],
                "payable": false,
                "stateMutability": "view",
                "type": "function"
            },
            {
                "inputs": [],
                "payable": false,
                "stateMutability": "nonpayable",
                "type": "constructor"
            }
        ];