#!/bin/bash
YAZ=$(curl -s http://127.0.0.1:26657/status | jq '.result.validator_info.voting_power' | xargs)
echo $YAZ
#if [[ $YAZ -lt 1 ]]; then
#	echo | celestia-appd tx slashing unjail --from celestia1qajhdnkyw95y0suln0ls0xvvyzvfepvadzhgx2 --chain-id mamaki
#		sleep 15s
#fi
