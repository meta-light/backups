# Celestia Commands
### Celestia App
* Start Node 
```
sudo systemctl start celestia-bridge && sudo journalctl -u  celestia-bridge.service -f
```
* Open App Logs
 ```
journalctl -u celestia-appd.service -f
```
* App Daemon Status
```
systemctl status celestia-appd
```
* Restart App
```
systemctl restart celestia-appd
```
* Kill App
```
sudo pkill -9 celestia-appd
```

### Update Celestia App
```
cd $HOME
rm -rf celestia-app
git clone https://github.com/celestiaorg/celestia-app.git
cd celestia-app`
APP_VERSION=$(curl -s https://api.github.com/repos/celestiaorg/celestia-app/releases/latest | jq -r ".tag_name")
git checkout tags/$APP_VERSION -b $APP_VERSION
make install
```
### Celestia Bridge 
* Init Bridge
```
celestia bridge init --core.remote tcp://localhost:26657 --core.grpc tcp://localhost:9090
```
* Bridge Logs
```
celestia-bridge.service -f`
```
### Celestia Validator
* Unjail Validator
```
celestia-appd tx slashing unjail --from=WALLET --chain-id mamaki
```
* Delegate Stake 
```
celestia-appd tx staking delegate \
<CelesValoper Address> 1000000utia \
    --from=<Wallet Address> --chain-id=mamaki
```
* Add Wallet 
```
celestia-appd keys add <wallet name>
```
* Check Sync Status 
```
curl -s localhost:26657/status | jq .result | jq .sync_info
```
* Check Peers 
```
curl -s http://localhost:26657/net_info | jq -r '.result.n_peers'
```
* Additional Peers - https://polkachu.com/testnets/celestia/peers
