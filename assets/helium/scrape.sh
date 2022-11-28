#! /bin/bash
HELIUM_API_URL=https://api.helium.io
HELIUM_WALLET=<path-to-wallet>/helium-wallet

declare -A wallets=( ["<ACCT1>"]="<ADDR1>" ["<ACCT2>"]="<ADDR2>" ["<ACCT3>"]="<ADDR3>" )

TREASURY="<TREASURY_WALLET_ADDRESS>"

for key in "${!wallets[@]}"; do
  ACCOUNT="${wallets[$key]}"
  URL="$HELIUM_API_URL/v1/accounts/$ACCOUNT"

  BALANCE="${VARIABLE:=0}"
  BALANCE=$(curl -s --fail $URL | jq -r '.data | if has("balance") then .balance else null end')
  
  if [[ $BALANCE == ?(-)+([0-9]) ]]; then
    CLEAR_BALANCE=$(( ($BALANCE / 100000000) - 1 ))
    
    if [[ $CLEAR_BALANCE -gt 0 ]]; then
      echo "Clearing $ACCOUNT with $CLEAR_BALANCE HNT payment..."
      # $HELIUM_WALLET -f "$key.key" pay one $TREASURY $CLEAR_BALANCE --commit
      # $HELIUM_WALLET -f "$key.key" pay one $TREASURY 1 --commit
    fi
  fi
  
sleep 5
done

#https://www.fairspot.host/hnt-export-mining-tax
