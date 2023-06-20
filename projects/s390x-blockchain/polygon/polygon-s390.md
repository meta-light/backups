### Polygon Dependancies 
* make
* go
* ansible?

```
sudo apt-get update
sudo apt-get install build-essential
sudo apt install golang-go
```

### Polygon Installation
* https://wiki.polygon.technology/docs/develop/network-details/full-node-binaries
* https://wiki.polygon.technology/docs/develop/network-details/full-node/ - does not work
#### Heimdall
```
cd
```
```
git clone https://github.com/maticnetwork/heimdall
```
```
cd heimdall
```
```
make install
```
```
source ~/.profile
```
```
heimdalld version --long
```
#### Bor
```
cd
```
```
git clone https://github.com/maticnetwork/bor
```
```
cd bor
```
```
make bor
```
```
sudo ln -nfs ~/bor/build/bin/bor /usr/bin/bor
```
```
sudo ln -nfs ~/bor/build/bin/bor /usr/bin/bor
```
```
bor version
```

#### Configure
```
git clone https://github.com/maticnetwork/launch
```
```
cd
```
```
mkdir -p node
```
```
cp -rf launch/mainnet-v1/sentry/sentry/* ~/node
```
Errors past this point
