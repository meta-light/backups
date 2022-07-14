# IF Dependencies
## 0 - Prep Ubuntu
```
Minnow Bios - F12
```
```
RAID-> ACHI
```
```
sudo apt update
```
```
sudo apt upgrade
```
## 1 - Install Git
* sudo apt install git
* git --version

## 2 - Install Make
* sudo apt install make
* make -v

## 3 - Install Build Essential
* sudo apt-get install -y build-essential

## 4 - Install Curl
* sudo apt-get install curl zip unzip tar

## 5 - Install NodeJS
* curl -fsSL https://deb.nodesource.com/setup_16.x | sudo -E bash -
* sudo apt install -y nodejs

## 6 - Install Rust
```
curl — proto ‘=https’ — tlsv1.2 -sSf https://sh.rustup.rs | sh
```
```
source $HOME/.cargo/env
```
## 7 - Install NPM
```
sudo npm install -g npm@latest
```
## 8 - Install Global Yarn
```
sudo npm install -global yarn
```
## 9 - Install Typescript 
```
sudo npm install typescript@latest -g
```
```
tsc --version
```
## 10 - Install Ironfish 
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
## 11 - Configure Testnet 
```
yarn ironfish testnet
```
## 12 - Mine w/ Host Payouts 
```
yarn ironfish miners:start --pool pool.ironfish.network --address <Public Address> -t -10
```
## 13 - TV Host
```
https://download.teamviewer.com/download/linux/teamviewer-host_amd64.deb
```
## 14 - Download Discord
```
https://discord.com/api/download?platform=linux&format=deb
```
