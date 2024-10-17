import Link from 'next/link'
import { AppHero } from '../components/ui/ui-layout'

export default async function Page() {
  return (
    <AppHero
      title="Solana Spotify Points"
      subtitle="Earn points by connecting your Spotify account and Solana wallet!"
    >
      <Link href="/dapp" className="btn btn-primary">
        Launch dApp
      </Link>
    </AppHero>
  )
}
