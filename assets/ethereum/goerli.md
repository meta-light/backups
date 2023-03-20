# Goerli
- Checkpoint Sync URL ```https://goerli.checkpoint-sync.ethpandaops.io/```
- [Staking Launchpad](https://notes.ethereum.org/@launchpad/checkpoint-sync)
- Start Geth - ```geth --goerli --datadir goerli --authrpc.addr localhost --authrpc.port 8551 --authrpc.vhosts localhost --authrpc.jwtsecret goerli/jwtsecret --http --http.api eth,net --signer=goerli/clef/clef.ipc --http``` 
- Start clef - ```clef --keystore goerli/keystore --configdir goerli/clef --chainid 5```
- Start lighthouse - ```lighthouse bn --network goerli  --execution-endpoint http://localhost:8551 --execution-jwt  ~/goerli/jwtsecret --checkpoint-sync-url https://goerli.checkpoint-sync.ethpandaops.io  --http```
- [Connect Lighthouse](https://lighthouse-book.sigmaprime.io/mainnet-validator.html)
