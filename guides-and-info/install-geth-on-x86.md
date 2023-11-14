### x86 Ubuntu Geth Dependencies
0. SSH into the server
```
ssh<user>@<ip-address>
```
1. Update your package library - 
```
sudo apt update && sudo apt upgrade
```
2. Install Makefile - 
```
sudo apt install make
```
3a. Add Ethereum repository to Apt
```
sudo add-apt-repository -y ppa:ethereum/ethereum
```
3b. Update package lists to reflect Ethereum repository
```
sudo apt-get update
```
### Geth Installation Guide - Ubuntu x86
1. Install Geth Package
```
sudo apt-get install ethereum
```
2. Check to ensure installation was successful
```
geth version
```

```Output should be similar to the following: 
Geth
Version 1.11.1-stable
Git Commit <git commit here>
Architecture: amd64
Go Version: go1.20.1
Operating System: linux
GOPATH=
GOROOT=
```
