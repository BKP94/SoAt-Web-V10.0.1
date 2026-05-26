import { useRef, useState, useEffect } from 'react'
import { useNavigate } from 'react-router-dom'
import { api } from '@/services/api'
import { useAuthStore } from '@/stores/authStore'

interface Props {
  module: { id: string; label: string; nameTh: string; path: string; iconSrc: string }
  onClose: () => void
}

interface LoginResponse {
  token: string
  userId: string
  branchId: string
  displayName: string
}

interface Branch {
  branchId:   string
  branchName: string
}

export default function ModuleLoginModal({ module, onClose }: Props) {
  const navigate   = useNavigate()
  const login      = useAuthStore((s) => s.login)

  const [userId,      setUserId]      = useState('')
  const [password,    setPassword]    = useState('')
  const [branchId,    setBranchId]    = useState('')
  const [branches,    setBranches]    = useState<Branch[]>([])
  const [showPass,    setShowPass]    = useState(false)
  const [error,       setError]       = useState('')
  const [loading,     setLoading]     = useState(false)
  const [loadingBr,   setLoadingBr]   = useState(true)
  const [showForgot,  setShowForgot]  = useState(false)
  const backdropRef = useRef<HTMLDivElement>(null)

  // โหลดสาขาจาก sc_com_m_branch
  useEffect(() => {
    fetch('/api/sc/branches')
      .then(r => r.json())
      .then((data: Branch[]) => {
        setBranches(data)
        if (data.length > 0) setBranchId(data[0].branchId)
      })
      .catch(() => {})
      .finally(() => setLoadingBr(false))
  }, [])

  async function handleSubmit(e: React.FormEvent) {
    e.preventDefault()
    setError('')
    setLoading(true)
    try {
      const { data } = await api.post<LoginResponse>('/auth/login', {
        userId,
        password,
        branchId: branchId || undefined,
      })
      login(data.token, data.userId, data.branchId, data.displayName)
      onClose()
      navigate(module.path)
    } catch {
      setError('ชื่อผู้ใช้หรือรหัสผ่านไม่ถูกต้อง')
    } finally {
      setLoading(false)
    }
  }

  function handleBackdropClick(e: React.MouseEvent) {
    if (e.target === backdropRef.current) onClose()
  }

  // ── shared input style ──────────────────────────────────────────────────────
  const inputStyle: React.CSSProperties = {
    width: '100%', border: 'none', borderBottom: '2px solid #e2e8f0',
    padding: '10px 0', fontSize: 14, outline: 'none', background: 'transparent',
    fontFamily: 'inherit', boxSizing: 'border-box', color: '#1e293b',
  }

  const selectStyle: React.CSSProperties = {
    width: '100%', border: 'none', borderBottom: '2px solid #e2e8f0',
    padding: '10px 0', fontSize: 14, outline: 'none', background: 'transparent',
    fontFamily: 'inherit', boxSizing: 'border-box', color: '#1e293b',
    cursor: 'pointer', appearance: 'none',
  }

  return (
    <div
      ref={backdropRef}
      onClick={handleBackdropClick}
      style={{
        position: 'fixed', inset: 0, zIndex: 50,
        display: 'flex', alignItems: 'center', justifyContent: 'center',
        background: 'rgba(15,23,42,0.55)',
        backdropFilter: 'blur(3px)',
      }}
    >
      <div style={{
        background: '#fff',
        borderRadius: 16,
        boxShadow: '0 24px 64px rgba(0,0,0,0.25)',
        width: '100%', maxWidth: 420,
        margin: '0 16px',
        overflow: 'hidden',
      }}>

        {/* ── Header ─────────────────────────────────────────────────────── */}
        <div style={{
          background: 'linear-gradient(135deg, #1a3760 0%, #1d4ed8 100%)',
          padding: '18px 24px',
          display: 'flex', alignItems: 'center', justifyContent: 'space-between',
        }}>
          <div>
            <div style={{ fontSize: 10, color: 'rgba(255,255,255,0.6)', letterSpacing: 3, fontWeight: 600 }}>
              WELCOME TO
            </div>
            <div style={{ fontSize: 14, color: '#fff', marginTop: 3, fontWeight: 500 }}>
              ยินดีต้อนรับเข้าสู่ระบบ
            </div>
          </div>
          <button
            type="button"
            onClick={onClose}
            style={{
              background: 'rgba(255,255,255,0.15)', border: 'none',
              color: '#fff', width: 30, height: 30, borderRadius: '50%',
              cursor: 'pointer', fontSize: 13, display: 'flex',
              alignItems: 'center', justifyContent: 'center', flexShrink: 0,
            }}
          >✕</button>
        </div>

        {/* ── Module Info ─────────────────────────────────────────────────── */}
        <div style={{
          padding: '16px 24px',
          display: 'flex', alignItems: 'center', gap: 16,
          background: '#f8fafc',
          borderBottom: '1px solid #e2e8f0',
        }}>
          <div style={{
            width: 60, height: 60, borderRadius: 14,
            background: '#fff', border: '1px solid #e2e8f0',
            display: 'flex', alignItems: 'center', justifyContent: 'center',
            boxShadow: '0 2px 8px rgba(0,0,0,0.06)', flexShrink: 0,
          }}>
            {module.iconSrc
              ? <img src={module.iconSrc} alt={module.label} style={{ width: 44, height: 44, objectFit: 'contain' }} />
              : <div style={{ width: 44, height: 44, borderRadius: '50%', background: '#e2e8f0' }} />
            }
          </div>
          <div>
            <div style={{ fontSize: 17, fontWeight: 700, color: '#1e3a5f', lineHeight: 1.2 }}>
              {module.label}
            </div>
            <div style={{ fontSize: 12, color: '#64748b', marginTop: 4 }}>
              {module.nameTh}
            </div>
          </div>
        </div>

        {/* ── Form ────────────────────────────────────────────────────────── */}
        <form onSubmit={handleSubmit} style={{ padding: '20px 24px 24px' }}>

          <p style={{ margin: '0 0 18px', fontSize: 12, textAlign: 'center', lineHeight: 1.8 }}>
            <span style={{ color: '#94a3b8' }}>Please enter your username and password</span><br />
            <span style={{ color: '#64748b' }}>กรุณาระบุชื่อผู้ใช้และรหัสผ่าน</span>
          </p>

          {/* Branch selector */}
          <div style={{ marginBottom: 14, position: 'relative' }}>
            <label style={{ fontSize: 10, color: '#94a3b8', fontWeight: 600, letterSpacing: 1, display: 'block', marginBottom: 2 }}>
              สาขา / Branch
            </label>
            <div style={{ position: 'relative' }}>
              <select
                value={branchId}
                onChange={(e) => setBranchId(e.target.value)}
                disabled={loadingBr}
                required
                style={selectStyle}
                onFocus={(e)  => (e.currentTarget.style.borderBottomColor = '#1d4ed8')}
                onBlur={(e)   => (e.currentTarget.style.borderBottomColor = '#e2e8f0')}
              >
                {loadingBr ? (
                  <option>กำลังโหลด...</option>
                ) : branches.length === 0 ? (
                  <option value="">ไม่พบข้อมูลสาขา</option>
                ) : (
                  branches.map(b => (
                    <option key={b.branchId} value={b.branchId}>
                      [{b.branchId}] {b.branchName}
                    </option>
                  ))
                )}
              </select>
              {/* custom dropdown arrow */}
              <span style={{
                position: 'absolute', right: 4, top: '50%', transform: 'translateY(-50%)',
                color: '#94a3b8', fontSize: 11, pointerEvents: 'none',
              }}>▾</span>
            </div>
          </div>

          {/* Username */}
          <div style={{ marginBottom: 14 }}>
            <label style={{ fontSize: 10, color: '#94a3b8', fontWeight: 600, letterSpacing: 1, display: 'block', marginBottom: 2 }}>
              ผู้ใช้งาน / Username
            </label>
            <input
              type="text"
              value={userId}
              onChange={(e) => setUserId(e.target.value)}
              placeholder="ชื่อผู้ใช้"
              required
              autoFocus
              style={inputStyle}
              onFocus={(e)  => (e.currentTarget.style.borderBottomColor = '#1d4ed8')}
              onBlur={(e)   => (e.currentTarget.style.borderBottomColor = '#e2e8f0')}
            />
          </div>

          {/* Password */}
          <div style={{ marginBottom: 4, position: 'relative' }}>
            <label style={{ fontSize: 10, color: '#94a3b8', fontWeight: 600, letterSpacing: 1, display: 'block', marginBottom: 2 }}>
              รหัสผ่าน / Password
            </label>
            <input
              type={showPass ? 'text' : 'password'}
              value={password}
              onChange={(e) => setPassword(e.target.value)}
              placeholder="รหัสผ่าน"
              required
              style={{ ...inputStyle, paddingRight: 36 }}
              onFocus={(e)  => (e.currentTarget.style.borderBottomColor = '#1d4ed8')}
              onBlur={(e)   => (e.currentTarget.style.borderBottomColor = '#e2e8f0')}
            />
            <button
              type="button"
              onClick={() => setShowPass(!showPass)}
              style={{
                position: 'absolute', right: 2, bottom: 10,
                background: 'none', border: 'none', cursor: 'pointer',
                color: '#94a3b8', fontSize: 17, lineHeight: 1, padding: 2,
              }}
              tabIndex={-1}
            >
              {showPass ? '🙈' : '👁'}
            </button>
          </div>

          {/* Forgot password link */}
          <div style={{ textAlign: 'right', marginBottom: 16 }}>
            <button
              type="button"
              onClick={() => setShowForgot(true)}
              style={{
                background: 'none', border: 'none', padding: 0,
                color: '#2563eb', fontSize: 12, cursor: 'pointer',
                fontFamily: 'inherit', textDecoration: 'underline',
                textDecorationStyle: 'dotted', textUnderlineOffset: 3,
              }}
              onMouseEnter={(e) => (e.currentTarget.style.color = '#1d4ed8')}
              onMouseLeave={(e) => (e.currentTarget.style.color = '#2563eb')}
            >
              ลืมรหัสผ่าน ?
            </button>
          </div>

          {/* Forgot password panel */}
          {showForgot && (
            <div style={{
              background: '#f0f9ff',
              border: '1px solid #bae6fd',
              borderRadius: 10,
              padding: '14px 16px',
              marginBottom: 16,
              position: 'relative',
            }}>
              <button
                type="button"
                onClick={() => setShowForgot(false)}
                style={{
                  position: 'absolute', top: 8, right: 10,
                  background: 'none', border: 'none', cursor: 'pointer',
                  color: '#94a3b8', fontSize: 13, lineHeight: 1, padding: 2,
                }}
              >✕</button>
              <div style={{ display: 'flex', alignItems: 'flex-start', gap: 10 }}>
                <span style={{ fontSize: 20, lineHeight: 1.2 }}>🔑</span>
                <div>
                  <div style={{ fontSize: 13, fontWeight: 600, color: '#0369a1', marginBottom: 4 }}>
                    ลืมรหัสผ่าน?
                  </div>
                  <div style={{ fontSize: 12, color: '#0369a1', lineHeight: 1.7 }}>
                    กรุณาติดต่อผู้ดูแลระบบ<br />
                    เพื่อรีเซ็ตรหัสผ่านของท่าน
                  </div>
                </div>
              </div>
            </div>
          )}

          {/* Error */}
          {error && (
            <div style={{
              background: '#fef2f2', border: '1px solid #fecaca', borderRadius: 8,
              padding: '9px 12px', marginBottom: 16, fontSize: 12, color: '#dc2626',
              display: 'flex', alignItems: 'center', gap: 6,
            }}>
              ⚠️ {error}
            </div>
          )}

          {/* Buttons */}
          <div style={{ display: 'flex', gap: 10 }}>
            <button
              type="submit"
              disabled={loading || loadingBr}
              style={{
                flex: 1,
                background: (loading || loadingBr) ? '#93c5fd' : '#1a3760',
                color: '#fff', border: 'none', borderRadius: 8,
                padding: '11px 0', fontSize: 14, fontWeight: 600,
                cursor: (loading || loadingBr) ? 'default' : 'pointer',
                fontFamily: 'inherit', transition: 'background 0.15s',
              }}
              onMouseEnter={(e) => { if (!loading && !loadingBr) e.currentTarget.style.background = '#1d4ed8' }}
              onMouseLeave={(e) => { if (!loading && !loadingBr) e.currentTarget.style.background = '#1a3760' }}
            >
              {loading ? 'กำลังตรวจสอบ...' : 'เข้าระบบ'}
            </button>
            <button
              type="button"
              onClick={onClose}
              style={{
                flex: 1, background: '#e0f2fe', color: '#0369a1',
                border: 'none', borderRadius: 8,
                padding: '11px 0', fontSize: 14, fontWeight: 600,
                cursor: 'pointer', fontFamily: 'inherit', transition: 'background 0.15s',
              }}
              onMouseEnter={(e) => (e.currentTarget.style.background = '#bae6fd')}
              onMouseLeave={(e) => (e.currentTarget.style.background = '#e0f2fe')}
            >
              ปิดหน้าจอ
            </button>
          </div>
        </form>
      </div>
    </div>
  )
}
