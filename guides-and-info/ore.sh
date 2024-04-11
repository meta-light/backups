#!/bin/bash

KEYPAIR_FILE="/home/<user>/.config/solana/id.json"
RPC1=""
RPC2="https://api.mainnet-beta.solana.com"
RPC3=""

MINE="ore --rpc $RPC3 --keypair $KEYPAIR_FILE --priority-fee 10000 mine --threads 10"
CLAIM="ore --rpc $RPC3 --keypair $KEYPAIR_FILE --priority-fee 10000 claim 0.1" $MAIN_WALLET
LOG_FILE="/home/<user>/ore/ore.log"
CLAIM_LOG="/home/<user>/ore/claim.log"
ORE_WALLET=""
MAIN_WALLET=""
while true; do
    echo "restarting loop"
    $MINE >> $LOG_FILE 2>&1
    echo  $MINE
    $CLAIM >> $CLAIM_LOG 2>&1
    echo $CLAIM
    date +"[%Y-%m-%d %H:%M:%S] Command executed" >> $LOG_FILE
    ore rewards $ORE_WALLET
    cargo install ore-cli
    sleep 5
done
