# Flipper Zero Solana Wallet - WIP

A Solana hardware wallet implementation for the Flipper Zero device.

## Features
- Create new Solana wallets
- Import existing wallets
- View wallet addresses
- Sign transactions
- Secure key storage

## Building
1. Clone the repository with submodules:

```bash
git clone https://github.com/yourusername/flipper-solana-wallet.git
cd flipper-solana-wallet
```

2. Clone official Flipper Zero firmware:

```bash
git clone https://github.com/flipperdevices/flipperzero-firmware.git
```

3. Build the application:

```bash
cd flipperzero-firmware
./fbt fap_solana_wallet
```

## Installation
Copy the generated `solana_wallet.fap` file to your Flipper Zero's SD card in the `apps` directory.

## Development
The project structure:
- `solana-wallet/` - Main application code
  - `helpers/` - Utility functions (crypto, base58)
  - `views/` - UI views
  - `scenes/` - Scene handlers
  - `storage/` - Storage management
  - `transaction/` - Transaction handling