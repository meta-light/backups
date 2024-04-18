const fs = require('fs');
const url = "https://mainnet.helius-rpc.com/?api-key=<API KEY>";

const dewicats = "E7PkwfKj6fyFNV2AooxwezM4gzPsLKstjG6KQ7e3CMzR";
const mcdegens = "ACy3ZVXcch8mZXUtRVqsJfa2DhFHxnUJpBb4oeN9tZsX";
const pixel = "3gE6oipJ6AqtNkRRqF4iPUQR7aqHPi6cDAC167pJrPi1";

const getAssetsByGroup = async () => {
    const response = await fetch(url, {method: 'POST', headers: {'Content-Type': 'application/json'},
      body: JSON.stringify({jsonrpc: '2.0', id: 'my-id', method: 'getAssetsByGroup', params: {groupKey: 'collection', groupValue: dewicats, page: 1, limit: 1000}}),
    });
    const { result } = await response.json();
    const owners = result.items.map(item => item.ownership.owner);
    const hashes = result.items.map(item => item.id);
    fs.writeFile('owners.json', JSON.stringify(owners, null, 2), (err) => {if (err) throw err; console.log('Owners have been saved to owners.json!');});
    fs.writeFile('hashes.json', JSON.stringify(hashes, null, 2), (err) => {if (err) throw err; console.log('Hashes have been saved to hashes.json!');});
};
getAssetsByGroup();