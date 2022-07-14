## IF Dependencies

# 0 - Prep Ubuntu
* Minnow Bios - F12
* RAID-> ACHI
* sudo apt update
* sudo apt upgrade

#1 - Install Git
* sudo apt install git
* git --version

#2 - Install Make
* sudo apt install make
* make -v

#3 - Install Build Essential
* sudo apt-get install -y build-essential

#4 - Install Curl
* sudo apt-get install curl zip unzip tar

#5 - Install NodeJS
---- line from digitalspace
* sudo apt install -y nodejs

#6 - Install Rust
---- line from above 
* source $HOME/.cargo/env

#7 - Install NPM
* npm install -g npm@<currentversion>

#8 - Install Global Yarn
* sudo npm install -global yarn

#9 - Install Typescript 
* sudo npm install typescript@latest -g
* tsc --version

#10 - Install Ironfish 

git

# - Configure Testnet 
* yarn ironfish testnet

# - Mine w/ Host Payouts 
yarn ironfish miners:start --pool pool.ironfish.network --address <Public Address> -t -10

## - TV Host
* https://download.teamviewer.com/download/linux/teamviewer-host_amd64.deb

## - Download Discord
* https://discord.com/api/download?platform=linux&format=deb
