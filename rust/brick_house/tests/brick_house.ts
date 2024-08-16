import * as anchor from "@coral-xyz/anchor";
import { Program } from "@coral-xyz/anchor";
import { BrickHouse } from "../target/types/brick_house";
import { PublicKey, Keypair, SystemProgram, SYSVAR_RENT_PUBKEY } from "@solana/web3.js";
import { TOKEN_PROGRAM_ID, createMint, createAssociatedTokenAccount, getAssociatedTokenAddress } from "@solana/spl-token";

describe("brick_house", () => {
  // Configure the client to use the local cluster.
  anchor.setProvider(anchor.AnchorProvider.env());

  const program = anchor.workspace.BrickHouse as Program<BrickHouse>;
  const provider = anchor.getProvider();

  let brickHouseMint: PublicKey;
  let bricksMint: PublicKey;
  let userBrickHouseAccount: PublicKey;
  let userBricksAccount: PublicKey;
  const user = Keypair.generate();

  before(async () => {
    // Airdrop SOL to the user
    await provider.connection.requestAirdrop(user.publicKey, 2 * anchor.web3.LAMPORTS_PER_SOL);

    // Create BRICKS token mint
    bricksMint = await createMint(
      provider.connection,
      user,
      user.publicKey,
      null,
      0
    );

    // Create user's BRICKS token account
    userBricksAccount = await createAssociatedTokenAccount(
      provider.connection,
      user,
      bricksMint,
      user.publicKey
    );
  });

  it("Mints a BRICK HOUSE NFT", async () => {
    const brickHouseMintKeypair = Keypair.generate();
    brickHouseMint = brickHouseMintKeypair.publicKey;

    userBrickHouseAccount = await getAssociatedTokenAddress(
      brickHouseMint,
      user.publicKey
    );

    await program.methods.mintBrickHouse()
      .accounts({
        user: user.publicKey,
        brickHouseMint: brickHouseMint,
        userBrickHouseAccount: userBrickHouseAccount,
        tokenProgram: TOKEN_PROGRAM_ID,
        systemProgram: SystemProgram.programId,
        rent: SYSVAR_RENT_PUBKEY,
      })
      .signers([user, brickHouseMintKeypair])
      .rpc();

    // Add assertions to check if the NFT was minted correctly
  });

  it("Burns a BRICK HOUSE NFT and mints 100 BRICKS tokens", async () => {
    await program.methods.burnBrickHouse()
      .accounts({
        user: user.publicKey,
        brickHouseMint: brickHouseMint,
        userBrickHouseAccount: userBrickHouseAccount,
        bricksMint: bricksMint,
        bricksMintAuthority: user.publicKey,
        userBricksAccount: userBricksAccount,
        tokenProgram: TOKEN_PROGRAM_ID,
      })
      .signers([user])
      .rpc();

    // Add assertions to check if the NFT was burned and BRICKS tokens were minted
  });

  it("Exchanges 100 BRICKS tokens for a BRICK HOUSE NFT", async () => {
    const newBrickHouseMintKeypair = Keypair.generate();
    const newBrickHouseMint = newBrickHouseMintKeypair.publicKey;

    const newUserBrickHouseAccount = await getAssociatedTokenAddress(
      newBrickHouseMint,
      user.publicKey
    );

    await program.methods.exchangeBricksForBrickHouse()
      .accounts({
        user: user.publicKey,
        bricksMint: bricksMint,
        userBricksAccount: userBricksAccount,
        brickHouseMint: newBrickHouseMint,
        userBrickHouseAccount: newUserBrickHouseAccount,
        tokenProgram: TOKEN_PROGRAM_ID,
        systemProgram: SystemProgram.programId,
        rent: SYSVAR_RENT_PUBKEY,
      })
      .signers([user, newBrickHouseMintKeypair])
      .rpc();

    // Add assertions to check if BRICKS tokens were burned and a new NFT was minted
  });
});