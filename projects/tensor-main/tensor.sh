#!/bin/bash

if [ ! -f "tensor.txt" ]; then
  echo "Error: The 'tensor.txt' file does not exist in the current directory."
  exit 1
fi

cat "gm.txt"

sleep .5

cat "react.txt"

sleep .5

cat "tensor.txt"

