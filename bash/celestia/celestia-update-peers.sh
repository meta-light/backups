## BUILD

cd $HOME
rm -rf celestia-app
git clone https://github.com/celestiaorg/celestia-app.git
cd celestia-app
git checkout v0.6.0
make install

# check
celestia-appd version
# OUTPUT
# 0.6.0

## UPDATE SETTINGS

# update bootstrap-peers
BOOTSTRAP_PEERS=$(curl -sL https://raw.githubusercontent.com/celestiaorg/networks/master/mamaki/bootstrap-peers.txt | tr -d '\n')
# check
echo $BOOTSTRAP_PEERS
# set
sed -i.bak -e "s/^bootstrap-peers *=.*/bootstrap-peers = \"$BOOTSTRAP_PEERS\"/" $HOME/.celestia-app/config/config.toml

# set Consensus Configuration Options
sed -i 's/timeout-commit = ".*/timeout-commit = "25s"/g' $HOME/.celestia-app/config/config.toml
sed -i 's/peer-gossip-sleep-duration *=.*/peer-gossip-sleep-duration = "2ms"/g' $HOME/.celestia-app/config/config.toml


# set P2P Configuration Options
max_num_inbound_peers=70
max_num_outbound_peers=20
max_connections=90

sed -i -e "s/^use-legacy *=.*/use-legacy = false/;\
s/^max-num-inbound-peers *=.*/max-num-inbound-peers = $max_num_inbound_peers/;\
s/^max-num-outbound-peers *=.*/max-num-outbound-peers = $max_num_outbound_peers/;\
s/^max-connections *=.*/max-connections = $max_connections/" $HOME/.celestia-app/config/config.toml

## RESTART

sudo systemctl restart celestia-appd && journalctl -u celestia-appd -f -o cat
