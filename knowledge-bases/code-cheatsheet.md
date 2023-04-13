# UNIX 
## Unix-Ubuntu-MacOS Commands (ctrl+alt+t)
```
sudo = run as admin
mkdir = make directory, creates a filesystem folder
ls = list files in current directory
cd = change directory
pwd = present working directory
dir = print current directory contents
wget = download from internet
apt-get = download from ubuntu repo
history = self explanatory
man = followed by a command displays the manual 
-br = brief
reboot = reboots system
lsblk = list drives and partitions
```
## Networking
```
ip -br link = network/mac addresses
ip -br addr show = network/mac addresses long form
ip -br a s = network addresses
dmidecode -t 2 = system info
ip addr show = long form IP address
```
## Boot from Linux forced from the BIOS on Linux:
```
sudo grub-install /dev/nvme0n1
sudo update-grub
```
## Add Alias Path
```
cd ~
sudo nano .zshrc
alias <alias name>="<command name>"
source ~/.zshrc
```
## Install linux IPMI to see the event log:
```
$ sudo apt install ipmitool
$ sudo ipmitool sdr >& ipmi-sdr.txt
$ sudo ipmitool sel elist >& ipmi-sel.txt
# IPMI show IP/MAC address:
$ sudo ipmitool lan print 1
```
## MACOS Helium Commands
```
base command = ./helium-wallet
import wallet = ./helium-wallet create basic --seed mobile (make sure verify:true)
```
## BASH COMMANDS 
[Cheatsheet](https://devhints.io/bash)
## CLI TOOLS
```
brew install figlet
```
```
brew install cmatrix
```
```
brew install rig
```
```
brew install telnet
```
```
telnet telehack
```

# Urbit
## Links
* [Alfa](https://uqbarnetwork.medium.com/uqbar-and-urbit-a-perfect-pair-29a0e61b36bd)
* [Hoon Cheatsheet](https://blog.urbit.live/urbit-operators-cheatsheet)
* [Hooniversity](https://hooniversity.org)
* [Users Manual](https://urbit.org/using/os/basics)
* [Point DAO](https://pointdao.notion.site/pointdao/Point-DAO-bc8fc478b67a49ac92358a2a40d77d35)
* [Data](https://dune.com/Dallascat/urbit)
## Groups 
```
~rondev/group-discovery
```
```
~sonwet/cryptocurrency-forum
```
```
~tirrel/the-marketplace
```
```
~pindet-timmut/urbitcoin-cash
```

# Sheets 
* Split Cells - =split(A1,";")
* Merge Cells -  =concatenate(A1," ",2)

# VSCODE
* Format Code: ```Shift + Option + F```

# GITHUB
* Github Commit from CLI: ```git commit -a -m "my commit message"```
