#!/bin/bash

## Variables
# Define Addresses
ADDRESSES=()
PAYMENTS=()

# PAYMENT INFO
AMOUNT="0.1"
MEMO=""
AIRDROP_FILE="airdrop_$(date +%F).json"

read -e -i "$AMOUNT" -p "Enter Airdrop Amount: " input_amount
AMOUNT="${input_amount:-$AMOUNT}"

while IFS= read -r -p "Enter an Airdrop Address (total ${#ADDRESSES[@]}): " line; do
    [[ $line ]] || break                  # break if line is empty
    ADDRESSES+=("$line")
    [[ ${#ADDRESSES[@]} -ne 50 ]] || break # break if limit is exceeded
done

## Iterate address array to build payment arrays
for addr in "${ADDRESSES[@]}"; do
  # Helium Input Format
  # [ { "address": $ADDRESS1, "amount": $AMOUNT, "memo": $MEMO } ]
  PAYMENTS+=("{ "address": $addr, "amount": $AMOUNT, "memo": $MEMO }")
done

printf -v joined '%s,' "${PAYMENTS[@]}"
echo "[${joined%,}]" > $AIRDROP_FILE
# TG9yZCBSb3o=
# helium-wallet pay multi ./$AIRDROP_FILE
