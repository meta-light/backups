# IF Dependencies
### 0 - Prep Ubuntu
* Minnow Bios - F12
* RAID-> ACHI
```
sudo apt update
```
```
sudo apt upgrade
```
### 1 - Install Git
```
sudo apt install git
```
```
git --version
```
### 2 - Install Make
```
sudo apt install make
```
### 3 - Install Build Essential
```
sudo apt-get install -y build-essential
```
### 4 - Install Curl
```
sudo apt-get install curl zip unzip tar
```
### 5 - Install NodeJS
```
curl -fsSL https://deb.nodesource.com/setup_16.x | sudo -E bash -
```
```
sudo apt install -y nodejs
```
### 6 - Install Rust
```
curl — proto ‘=https’ — tlsv1.2 -sSf https://sh.rustup.rs | sh
```
```
source $HOME/.cargo/env
```
### 7 - Install NPM
```
sudo npm install -g npm@latest
```
### 8 - Install Global Yarn
```
sudo npm install -global yarn
```
### 9 - Install Typescript 
```
sudo npm install typescript@latest -g
```
```
tsc --version
```
### 10 - Install Ironfish 
```
git clone https://github.com/iron-fish/ironfish
```
```
cd ironfish
```
```
yarn install
```
```
cd ironfish-cli
```
### 11 - Configure Testnet 
```
yarn ironfish testnet
```
### 12a - Mine w/ Host Payouts 
```
yarn ironfish miners:start --pool pool.ironfish.network --address 9a6b3dd4fbbca8e439518721a27c83cd1c62d63ccec3071fc4c3c647b635a23e61b8b9e9f549a546bb3fdf -t <num-threads>
```
### 12b - Mine w/ Host Payouts 
```
ironfish miners:start --pool 36.189.234.195:60006 --address 9a6b3dd4fbbca8e439518721a27c83cd1c62d63ccec3071fc4c3c647b635a23e61b8b9e9f549a546bb3fdf --worker_name <WN>
```
### 13a - TV Host - [Download](https://download.teamviewer.com/download/linux/teamviewer-host_amd64.deb)
### 13b - Rust Desk - [Download](https://github.com/rustdesk/rustdesk/releases/download/1.1.9/rustdesk-1.1.9.deb)
### 14 - Discord - [Download](https://discord.com/api/download?platform=linux&format=deb)

# Ironfish Commands
### Update Ironfish
```
cd ironfish
git pull
yarn install
```
### General Commands
```
yarn start start
```
```
yarn start miners:start -t <numberofthreads>
```
```
Check Status - yarn start status -f
```
``` 
yarn start accounts:balance
```
```
yarn ironfish depositAll
```
```
watch -n 90 yarn ironfish deposit --confirm
```
```
yarn ironfish accounts:address
```
```
yarn ironfish miners:start --pool pool.ironfish.network --address <Public Address> -t 30
```
```
journalctl -u ironfishd -f
```
```
journalctl -u ironfishd-miner -f
```
