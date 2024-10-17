'use client'

import { useState, useEffect } from 'react'
import { useWallet } from '@solana/wallet-adapter-react'
import SpotifyWebApi from 'spotify-web-api-js'

const crypto = require('crypto')

const spotifyApi = new SpotifyWebApi()

export function SpotifyAuth() {
  const [isAuthenticated, setIsAuthenticated] = useState(false)
  const { publicKey } = useWallet()

  useEffect(() => {
    const params = new URLSearchParams(window.location.search)
    const code = params.get('code')

    if (code) {
      // Exchange the code for an access token
      exchangeCodeForToken(code)
    }
  }, [])

  const exchangeCodeForToken = async (code: string) => {
    try {
      const response = await fetch('/api/spotify-token', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify({ code }),
      })

      if (!response.ok) {
        throw new Error('Failed to exchange code for token')
      }

      const data = await response.json()
      console.log('Access token:', data.access_token)
      console.log('Refresh token:', data.refresh_token)
      console.log('Expires in:', data.expires_in)

      spotifyApi.setAccessToken(data.access_token)
      setIsAuthenticated(true)
    } catch (error) {
      console.error('Error exchanging code for token:', error)
    }
  }

  const handleLogin = () => {
    const scopes = ['user-read-private', 'user-read-email']
    const state = crypto.randomBytes(16).toString('hex')
    const showDialog = true
    
    const params = new URLSearchParams({
      client_id: process.env.NEXT_PUBLIC_SPOTIFY_CLIENT_ID || '',
      response_type: 'code',
      redirect_uri: process.env.NEXT_PUBLIC_SPOTIFY_REDIRECT_URI || '',
      scope: scopes.join(' '),
      state: state,
      show_dialog: showDialog.toString()
    })

    const authorizeURL = `https://accounts.spotify.com/authorize?${params.toString()}`
    window.location.href = authorizeURL
  }

  return (
    <div>
      {!isAuthenticated ? (
        <button className="btn btn-primary" onClick={handleLogin}>
          Connect Spotify
        </button>
      ) : (
        <span className="text-success">Spotify Connected</span>
      )}
    </div>
  )
}