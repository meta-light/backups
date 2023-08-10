const { Connection, PublicKey, Keypair } = require('@solana/web3.js');
const { Market } = require('@project-serum/serum');
const { TokenInstructions } = require('@project-serum/serum');
const { TokenSwap } = require('@solana/spl-token-swap');
const { Token } = require('@solana/spl-token');
const { BufferLayout } = require('@solana/buffer-layout');

const solanaNodeUrl = 'https://api.mainnet-beta.solana.com';
const wallet = Keypair.fromSecretKey(Buffer.from([65,6,229,9,193,170,2,195,164,233,160,128,78,89,201,66,160,98,183,44,71,93,73,66,227,50,40,19,203,74,116,20,185,118,2,103,19,23,31,138,182,203,115,10,66,108,223,214,135,117,182,54,61,44,63,210,238,134,145,253,8,166,231,11]))

const tokenAAddressStr = 'iotEVVZLEywoTn1QdwNPddxPWszn3zFhEot3MfL9fns';
const tokenAAddress = new PublicKey(tokenAAddressStr);

const tokenBAddressStr = 'AmgUMQeqW8H74trc8UkKjzZWtxBdpS496wh4GLy2mCpo';
const tokenBAddress = new PublicKey(tokenBAddressStr);

const tokenSwapAddressStr = 'J5U6amNaxzBtXbbgL8c6QsX6x9SMteqYhZgnddxiJ9Lb';
const tokenSwapAddress = new PublicKey(tokenSwapAddressStr);

async function swapTokens() {
  const connection = new Connection(solanaNodeUrl, 'confirmed');

  try {
    // Fetch Token Swap Market
    const tokenSwapMarket = await TokenSwap.loadTokenSwap(connection, tokenSwapAddress, {}, null);

    // Fetch Token Accounts
    const tokenA = new Token(connection, tokenAAddress, null, wallet);
    const tokenB = new Token(connection, tokenBAddress, null, wallet);

    // Amount of token A to swap
    const amountToSwap = 10; // Example: Swap 10 token A for token B

    // Get the swap result
    const swapResult = await tokenSwapMarket.swap(
      tokenA,
      tokenB,
      wallet.publicKey,
      null, // Swap fee payer, null for the wallet
      amountToSwap,
      0, // Minimum amount of token B to receive (optional)
    );

    // Transfer swapped tokens to an external address
    const externalAddressStr = '2wzBg2xGMNR1Nr6cGywo3LJCXhMSntRxuwg15SCP3vL3'; // External address where you want to send the swapped tokens
    const externalAddress = new PublicKey(externalAddressStr);
    const transaction = await tokenB.transfer(
      swapResult,
      wallet.publicKey,
      externalAddress,
      [], // Memo
    );

    // Sign and send the transaction
    const { blockhash } = await connection.getLatestBlockhash();
    transaction.recentBlockhash = blockhash;
    transaction.partialSign(wallet);
    await connection.sendRawTransaction(transaction.serialize());
    console.log('Swap completed and tokens sent to the external address.');
  } catch (error) {
    console.error('Error:', error);
  }

  try {
    // Create a Keypair from the private key hex string
    const privateKeyArray = [
      221, 221, 63, 166, 148, 7, 49, 144, 144, 90, 90, 179, 76, 135, 118, 1,
      124, 194, 253, 52, 45, 199, 112, 1, 216, 195, 70, 122, 153, 0, 247, 155,
      28, 241, 181, 115, 79, 10, 189, 91, 27, 154, 232, 135, 124, 243, 108, 130,
      113, 251, 181, 44, 208, 66, 205, 98, 177, 110, 11, 2, 192, 166, 66, 148
    ];
    const privateKeyBytes = Buffer.from(privateKeyArray, 'hex');
    const wallet = Keypair.fromSecretKey(privateKeyBytes);
    console.log(wallet);
    const walletPublicKey = wallet.publicKey;

    const tokenA = await connection.getTokenAccountBalance(tokenAAddress);
    const tokenB = await connection.getTokenAccountBalance(tokenBAddress);
    const dexMarket = await Market.load(connection, dexMarketAddress, {}, TokenInstructions);

    // Check tokenA and tokenB balances, make sure there are enough tokens for the swap
    await performSwap(connection, wallet, dexMarket, tokenA, tokenB, 10); // Example: Swap 10 token A for token B
  } catch (error) {
    console.error('Error:', error);
  }
}

async function performSwap(connection, wallet, dexMarket, tokenA, tokenB, amount) {
  // Rest of the performSwap function remains the same as in the second file
  // ...
  // ...
}

swapTokens();