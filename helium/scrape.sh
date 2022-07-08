#! /bin/bash
HELIUM_API_URL=https://api.helium.io
HELIUM_WALLET=<path-to-wallet>/helium-wallet

declare -A wallets=( ["<ACCT1>"]="<ADDR1>" ["<ACCT2>"]="<ADDR2>" ["<ACCT3>"]="<ADDR3>" )

TREASURY="<TREASURY_WALLET_ADDRESS>"

for key in "${!wallets[@]}"; do
  URL="$HELIUM_API_URL/v1/accounts/${wallets[$key]}"
  BALANCE=$(curl -s $URL | jq -r .data.balance)
  CLEAR_BALANCE=$((($BALANCE / 100000000) - 1))
  echo $HELIUM_WALLET -f "$key.key" pay one $TREASURY $CLEAR_BALANCE --commit
  echo $HELIUM_WALLET -f "$key.key" pay one $TREASURY 1 --commit
  echo "... sleeping for 15 seconds"
  sleep 15
done

#https://www.fairspot.host/hnt-export-mining-tax
