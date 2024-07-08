#!/bin/bash
# Run commands
echo "Printing System Info..."
echo "ip -br link"
echo "ip -br a s"
echo "dmidecode -t 2"
echo "ip addr show"
# Install packages
echo "Installing packages..."
packages=(
  figlet
  cmatrix
  rig
  telnet
  telehack
)
for package in "${packages[@]}"
do
    echo "Installing $package..."
    # Replace the following line with the appropriate package installation command
    # e.g., sudo apt-get install $package
    echo "sudo apt-get install $package"
done
echo "Script completed."
