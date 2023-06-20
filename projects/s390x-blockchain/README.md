# s390x-blockchain
Exploration into the application of running blockchain nodes on IBM s390x Z Mainframe architecture

## Syscoin
* [docker](https://github.com/syscoin/docker-syscoin-core)
* [guide](https://support.syscoin.org/t/syscoin-lux-masternode-install-guide/463)
* [deps](https://github.com/syscoin/syscoin/blob/master/doc/dependencies.md)
* [main repo](https://github.com/syscoin/syscoin)
* [unix](https://github.com/syscoin/syscoin/blob/master/doc/build-unix.md)

## Guides
* [Ethereum](https://github.com/meta-lite/s390x-blockchain/blob/main/ethereum/ethereum.md)
* [Polygon](https://github.com/meta-lite/s390x-blockchain/blob/main/polygon/polygon-s390.md)

## Resources 
### s390x and Blockchain
* [s390 Wiki](https://en.wikipedia.org/wiki/IBM_System/390)
* [s390x Ubuntu](https://wiki.ubuntu.com/S390X)
* [s390 Linux Kernel](https://docs.kernel.org/s390/index.html)

### Need to Read
* https://developer.ibm.com/tutorials/build-teku-and-web3signer-on-s390x-architecture/
* https://github.com/ethereum/go-ethereum/blob/master/common/bitutil/bitutil.go
* https://pkgs.alpinelinux.org/package/edge/community/s390x/geth

### IBM Mainframes and Blockchain 
* [Blockchain for IBM Z](https://community.ibm.com/community/user/ibmz-and-linuxone/blogs/destination-z1/2019/12/23/blockchain-for-ibm-z)
* [Blockchain And The IBM zMainframe](https://planetmainframe.com/2021/08/blockchain-and-the-ibm-zmainframe-a-match-made-in-heaven/)
* [IBM Crypto Custody](https://www.coindesk.com/business/2022/02/18/inside-ibms-fast-growing-crypto-custody-play/)

### Ethereum Installation
* [Geth Client](https://geth.ethereum.org/docs)
* [Ethereum Node Video](https://www.youtube.com/watch?v=3H-KmO7Ce4I&ab_channel=EatTheBlocks)
* [Serum Ethereum Node Setup](https://stereum.net/ethereum-node-setup/)
* [Geth Guide](https://www.quicknode.com/guides/infrastructure/how-to-install-and-run-a-geth-node)
* [Polygon Docker](https://wiki.polygon.technology/docs/develop/network-details/full-node-docker)
* [Ethereum Node](https://ethereum.org/en/developers/docs/nodes-and-clients/run-a-node/)

## Compatible Dependencies for s390X
* Makefile - ```sudo apt install make```
* Git - ```sudo apt install git```
* Rust - ```curl --proto '=https' --tlsv1.2 -sSf https://sh.rustup.rs | sh```
* Golang - ```sudo apt install golang-go```
* Snapd - ```sudo apt install snapd```
* Nodejs - ```sudo snap install node```
* NVM - ```curl -o- https://raw.githubusercontent.com/nvm-sh/nvm/v0.39.3/install.sh | bash```
* NPM - ```sudo snap install npm```
* Python - ```sudo apt install python```
* Pip - ```sudo apt install python-pip```
* Pip3 - ```sudo apt install python-pip3```
* s390 Tools - ```s390-tools```
* Ansible - ```sudo apt install ansible``` - needed for polygon
* Build Tools - ```sudo apt-get install build-essential```
* Java - ```sudo apt install default-jre```
* Curl - ```sudo apt install curl```
* Docker - ```sudo apt install docker.io```
