use anchor_lang::prelude::*;
use anchor_spl::token::{self, Token, Mint, TokenAccount, MintTo, Burn};
use anchor_spl::associated_token::AssociatedToken;

declare_id!("DJHgyZpwCGa344hamgo55VmyG2RaKwGKhQm3m9ThMVYF");

#[program]
pub mod brick_house {
    use super::*;

    pub fn mint_brick_house(ctx: Context<MintBrickHouse>) -> Result<()> {
        // Mint a BRICK HOUSE NFT
        token::mint_to(
            CpiContext::new(
                ctx.accounts.token_program.to_account_info(),
                MintTo {
                    mint: ctx.accounts.brick_house_mint.to_account_info(),
                    to: ctx.accounts.user_brick_house_account.to_account_info(),
                    authority: ctx.accounts.user.to_account_info(),
                },
            ),
            1,
        )?;
        Ok(())
    }

    pub fn burn_brick_house(ctx: Context<BurnBrickHouse>) -> Result<()> {
        // Burn BRICK HOUSE NFT
        token::burn(
            CpiContext::new(
                ctx.accounts.token_program.to_account_info(),
                Burn {
                    mint: ctx.accounts.brick_house_mint.to_account_info(),
                    from: ctx.accounts.user_brick_house_account.to_account_info(),
                    authority: ctx.accounts.user.to_account_info(),
                },
            ),
            1,
        )?;

        // Mint 100 BRICKS tokens
        token::mint_to(
            CpiContext::new(
                ctx.accounts.token_program.to_account_info(),
                MintTo {
                    mint: ctx.accounts.bricks_mint.to_account_info(),
                    to: ctx.accounts.user_bricks_account.to_account_info(),
                    authority: ctx.accounts.bricks_mint_authority.to_account_info(),
                },
            ),
            100,
        )?;
        Ok(())
    }

    pub fn exchange_bricks_for_brick_house(ctx: Context<ExchangeBricksForBrickHouse>) -> Result<()> {
        // Burn 100 BRICKS tokens
        token::burn(
            CpiContext::new(
                ctx.accounts.token_program.to_account_info(),
                Burn {
                    mint: ctx.accounts.bricks_mint.to_account_info(),
                    from: ctx.accounts.user_bricks_account.to_account_info(),
                    authority: ctx.accounts.user.to_account_info(),
                },
            ),
            100,
        )?;

        // Mint BRICK HOUSE NFT
        token::mint_to(
            CpiContext::new(
                ctx.accounts.token_program.to_account_info(),
                MintTo {
                    mint: ctx.accounts.brick_house_mint.to_account_info(),
                    to: ctx.accounts.user_brick_house_account.to_account_info(),
                    authority: ctx.accounts.user.to_account_info(),
                },
            ),
            1,
        )?;
        Ok(())
    }
}

#[derive(Accounts)]
pub struct MintBrickHouse<'info> {
    #[account(mut)]
    pub user: Signer<'info>,
    #[account(
        init,
        payer = user,
        mint::decimals = 0,
        mint::authority = user
    )]
    pub brick_house_mint: Box<Account<'info, Mint>>,
    #[account(
        init,
        payer = user,
        associated_token::mint = brick_house_mint,
        associated_token::authority = user
    )]
    pub user_brick_house_account: Box<Account<'info, TokenAccount>>,
    pub token_program: Program<'info, Token>,
    pub system_program: Program<'info, System>,
    pub rent: Sysvar<'info, Rent>,
    pub associated_token_program: Program<'info, AssociatedToken>,
}

#[derive(Accounts)]
pub struct BurnBrickHouse<'info> {
    #[account(mut)]
    pub user: Signer<'info>,
    #[account(mut)]
    pub brick_house_mint: Box<Account<'info, Mint>>,
    #[account(mut)]
    pub user_brick_house_account: Box<Account<'info, TokenAccount>>,
    #[account(mut)]
    pub bricks_mint: Box<Account<'info, Mint>>,
    /// CHECK: This is the authority for the BRICKS token mint
    pub bricks_mint_authority: UncheckedAccount<'info>,
    #[account(mut)]
    pub user_bricks_account: Box<Account<'info, TokenAccount>>,
    pub token_program: Program<'info, Token>,
}

#[derive(Accounts)]
pub struct ExchangeBricksForBrickHouse<'info> {
    #[account(mut)]
    pub user: Signer<'info>,
    #[account(mut)]
    pub bricks_mint: Box<Account<'info, Mint>>,
    #[account(mut)]
    pub user_bricks_account: Box<Account<'info, TokenAccount>>,
    #[account(
        init,
        payer = user,
        mint::decimals = 0,
        mint::authority = user
    )]
    pub brick_house_mint: Box<Account<'info, Mint>>,
    #[account(
        init,
        payer = user,
        associated_token::mint = brick_house_mint,
        associated_token::authority = user
    )]
    pub user_brick_house_account: Box<Account<'info, TokenAccount>>,
    pub token_program: Program<'info, Token>,
    pub system_program: Program<'info, System>,
    pub rent: Sysvar<'info, Rent>,
    pub associated_token_program: Program<'info, AssociatedToken>,
}