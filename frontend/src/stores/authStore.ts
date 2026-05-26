import { create } from 'zustand'
import { persist } from 'zustand/middleware'

interface AuthState {
  token: string | null
  userId: string | null
  branchId: string | null
  displayName: string | null
  login: (token: string, userId: string, branchId: string, displayName: string) => void
  logout: () => void
}

export const useAuthStore = create<AuthState>()(
  persist(
    (set) => ({
      token: null,
      userId: null,
      branchId: null,
      displayName: null,
      login: (token, userId, branchId, displayName) =>
        set({ token, userId, branchId, displayName }),
      logout: () =>
        set({ token: null, userId: null, branchId: null, displayName: null }),
    }),
    { name: 'soat-auth' }
  )
)
