
const web3 = require("@solana/web3.js");
const bs58 = require('bs58');
let secretKey = bs58.decode("<private key here>");
console.log("Hex:", `[${web3.Keypair.fromSecretKey(secretKey).secretKey}]`);

privkey = new Uint8Array(["<private-key-here>"]); // no quotations
console.log("Base 58:", bs58.encode(privkey));

const length = privkey.length;
const halfLength = Math.ceil(length / 2);

const firstHalf = privkey.subarray(0, halfLength);
const secondHalf = privkey.subarray(halfLength);

console.log("First Half:", firstHalf);
console.log("Second Half:", secondHalf);

const fs = require('fs');
j = new Uint8Array(secretKey.buffer, secretKey.byteOffset, secretKey.byteLength / Uint8Array.BYTES_PER_ELEMENT);
fs.writeFileSync('key.json', `[${j}]`);
console.log("JSON:", `[${j}]`);