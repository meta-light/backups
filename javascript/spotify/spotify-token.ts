import type { NextApiRequest, NextApiResponse } from 'next'
import axios from 'axios'
const clientId = process.env.SPOTIFY_CLIENT_ID
const clientSecret = process.env.SPOTIFY_CLIENT_SECRET
const redirectUri = process.env.NEXT_PUBLIC_SPOTIFY_REDIRECT_URI
export default async function handler(req: NextApiRequest, res: NextApiResponse) {
  if (req.method !== 'POST') {
    return res.status(405).json({ error: 'Method not allowed' })
  }

  const { code } = req.body

  if (!code) {
    return res.status(400).json({ error: 'Code is required' })
  }

  try {
    const response = await axios.post(
      'https://accounts.spotify.com/api/token',
      new URLSearchParams({
        grant_type: 'authorization_code',
        code,
        redirect_uri: redirectUri as string,
      }),
      {
        headers: {
          'Content-Type': 'application/x-www-form-urlencoded',
          Authorization: `Basic ${Buffer.from(`${clientId}:${clientSecret}`).toString('base64')}`,
        },
      }
    )

    const { access_token, refresh_token, expires_in } = response.data
    res.status(200).json({ access_token, refresh_token, expires_in })
  } catch (error) {
    console.error('Error exchanging code for token:', error)
    res.status(500).json({ error: 'Failed to exchange code for token' })
  }
}