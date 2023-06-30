const readline = require('readline');
const fetch = require('node-fetch');

function handleWalletInput() {
  const rl = readline.createInterface({
    input: process.stdin,
    output: process.stdout
  });

  rl.question('Enter a SOL Address:', (userInput) => {
    const walletInput = userInput;
    console.log('Wallet Address:', walletInput);
    chooseApi(walletInput, rl);
  });
}

function chooseApi(walletInput, rl) {
  rl.question('Choose an API:\n1. List Hotspots\n2. Hotspot Rewards\n3. Hotspot Speed\n4. Hotspot Cells\n5. Exit\n', (userChoice) => {
    switch (userChoice) {
      case '1':
        callApi(`https://beta-api.hotspotty.net/api/v1/wallets/${walletInput}/hotspots`, () => {
          chooseApi(walletInput, rl);
        });
        break;
      case '2':
        rl.question('Enter a Hotspot Address:', (hotspotAddressRewards) => {
          callApi(`https://beta-api.hotspotty.net/api/v1/hotspots/${hotspotAddressRewards}/rewards`, () => {
            chooseApi(walletInput, rl);
          });
        });
        break;
      case '3':
        rl.question('Enter a Hotspot Address:', (hotspotAddressSpeed) => {
          callApi(`https://beta-api.hotspotty.net/api/v1/hotspots/${hotspotAddressSpeed}/speedtests`, () => {
            chooseApi(walletInput, rl);
          });
        });
        break;
      case '4':
        rl.question('Enter a Hotspot Address:', (hotspotAddressCells) => {
          callApi(`https://beta-api.hotspotty.net/api/v1/hotspots/${hotspotAddressCells}/cells`, () => {
            chooseApi(walletInput, rl);
          });
        });
        break;
      case '5':
        console.log('Exiting the program.');
        rl.close();
        break;
      default:
        console.log('Invalid choice');
        chooseApi(walletInput, rl);
    }
  });
}

function callApi(apiUrl, callback) {
  const apiKey = ''; //API KEY GOES HERE
  fetch(apiUrl, { headers: { Authorization: `Bearer ${apiKey}` } })
    .then(response => response.json())
    .then(data => {
      console.log(data);
      callback();
    })
    .catch(error => {
      console.error('Error:', error);
      callback();
    });
}

handleWalletInput();