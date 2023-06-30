#!/bin/bash

start_schedule_unjail () {
    PASWD='password'
    DELAY=120
    ACC_NAME=wallet_name
    NODE=http://localhost:26657
    CHAIN=mamaki
    CMD=celestia-appd
    TOKEN_NAME=utia
    for (( ;; )); do
            JAIL=$(${CMD} q staking validator $( echo "${PASWD}" | ${CMD} keys show ${ACC_NAME} --bech val -a) | grep jailed:);
            if [[ ${JAIL} == *"false"* ]]; then
                echo -e "${JAIL} \n"
            else
                echo -e "${JAIL} \n"
                echo -e $( echo "${PASWD}" | ${CMD} tx slashing unjail --chain-id ${CHAIN} --from ${ACC_NAME} --gas=auto --fees=1000${TOKEN_NAME} -y) \n;
                sleep 1
            fi
            for (( timer=${DELAY}; timer>0; timer-- ))
            do
                    printf "* sleep for %02d sec\r" $timer
                    sleep 1
            done
    done
}

start_schedule_unjail
