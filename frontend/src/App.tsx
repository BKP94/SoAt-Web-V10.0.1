import { lazy, Suspense } from 'react'
import { Routes, Route, Navigate } from 'react-router-dom'
import ProtectedRoute from '@/components/ProtectedRoute'

// Public — no login required
const ScCenter = lazy(() => import('@/pages/scCenter'))

// ── sc* modules ─────────────────────────────────────────────────────────────
const ScAccount     = lazy(() => import('@/pages/scAccount'))
const ScAdmin       = lazy(() => import('@/pages/scAdmin'))
const ScApprove     = lazy(() => import('@/pages/scApprove'))
const ScAtm         = lazy(() => import('@/pages/scAtm'))
const ScBillpayment = lazy(() => import('@/pages/scBillpayment'))
const ScCoordinate  = lazy(() => import('@/pages/scCoordinate'))
const ScCremation   = lazy(() => import('@/pages/scCremation'))
const ScDeposit     = lazy(() => import('@/pages/scDeposit'))
const ScEdocument   = lazy(() => import('@/pages/scEdocument'))
const ScElections   = lazy(() => import('@/pages/scElections'))
const ScEoffice     = lazy(() => import('@/pages/scEoffice'))
const ScEstate      = lazy(() => import('@/pages/scEstate'))
const ScExp         = lazy(() => import('@/pages/scExp'))
const ScFinance     = lazy(() => import('@/pages/scFinance'))
const ScFund        = lazy(() => import('@/pages/scFund'))
const ScHr          = lazy(() => import('@/pages/scHr'))
const ScInsurance   = lazy(() => import('@/pages/scInsurance'))
const ScInvestment  = lazy(() => import('@/pages/scInvestment'))
const ScKeepcoll    = lazy(() => import('@/pages/scKeepcoll'))
const ScKeeping     = lazy(() => import('@/pages/scKeeping'))
const ScLaw         = lazy(() => import('@/pages/scLaw'))
const ScMobile      = lazy(() => import('@/pages/scMobile'))
const ScPermit      = lazy(() => import('@/pages/scPermit'))
const ScProDATA     = lazy(() => import('@/pages/scProDATA'))
const ScReport      = lazy(() => import('@/pages/scReport'))
const ScRing2Me     = lazy(() => import('@/pages/scRing2Me'))
const ScScholarship = lazy(() => import('@/pages/scScholarship'))
const ScStock       = lazy(() => import('@/pages/scStock'))
const ScTeller      = lazy(() => import('@/pages/scTeller'))
const ScTransbank   = lazy(() => import('@/pages/scTransbank'))
const ScWelfare     = lazy(() => import('@/pages/scWelfare'))

// ── rc* report modules ───────────────────────────────────────────────────────
const RcAccount     = lazy(() => import('@/pages/rcAccount'))
const RcAdmin       = lazy(() => import('@/pages/rcAdmin'))
const RcApprove     = lazy(() => import('@/pages/rcApprove'))
const RcAtm         = lazy(() => import('@/pages/rcAtm'))
const RcContract    = lazy(() => import('@/pages/rcContract'))
const RcCoordinate  = lazy(() => import('@/pages/rcCoordinate'))
const RcDeposit     = lazy(() => import('@/pages/rcDeposit'))
const RcEdocument   = lazy(() => import('@/pages/rcEdocument'))
const RcElections   = lazy(() => import('@/pages/rcElections'))
const RcEoffice     = lazy(() => import('@/pages/rcEoffice'))
const RcFinance     = lazy(() => import('@/pages/rcFinance'))
const RcFund        = lazy(() => import('@/pages/rcFund'))
const RcHr          = lazy(() => import('@/pages/rcHr'))
const RcInsurance   = lazy(() => import('@/pages/rcInsurance'))
const RcInvestment  = lazy(() => import('@/pages/rcInvestment'))
const RcKeepColl    = lazy(() => import('@/pages/rcKeepColl'))
const RcKeeping     = lazy(() => import('@/pages/rcKeeping'))
const RcLaw         = lazy(() => import('@/pages/rcLaw'))
const RcProdata     = lazy(() => import('@/pages/rcProdata'))
const RcRing2Me     = lazy(() => import('@/pages/rcRing2Me'))
const RcScholarship = lazy(() => import('@/pages/rcScholarship'))
const RcStock       = lazy(() => import('@/pages/rcStock'))
const RcTeller      = lazy(() => import('@/pages/rcTeller'))
const RcTransbank   = lazy(() => import('@/pages/rcTransbank'))
const RcWelfare     = lazy(() => import('@/pages/rcWelfare'))
const RepQuery      = lazy(() => import('@/pages/repQuery'))
const RxForm        = lazy(() => import('@/pages/rxForm'))

const Loading = () => <div className="p-8 text-slate-400 text-sm">กำลังโหลด...</div>

export default function App() {
  return (
    <Suspense fallback={<Loading />}>
      <Routes>
        <Route path="/" element={<ScCenter />} />

        <Route element={<ProtectedRoute />}>
          {/* sc* — business modules */}
          <Route path="/scAccount/*"     element={<ScAccount />} />
          <Route path="/scAdmin/*"       element={<ScAdmin />} />
          <Route path="/scApprove/*"     element={<ScApprove />} />
          <Route path="/scAtm/*"         element={<ScAtm />} />
          <Route path="/scBillpayment/*" element={<ScBillpayment />} />
          <Route path="/scCoordinate/*"  element={<ScCoordinate />} />
          <Route path="/scCremation/*"   element={<ScCremation />} />
          <Route path="/scDeposit/*"     element={<ScDeposit />} />
          <Route path="/scEdocument/*"   element={<ScEdocument />} />
          <Route path="/scElections/*"   element={<ScElections />} />
          <Route path="/scEoffice/*"     element={<ScEoffice />} />
          <Route path="/scEstate/*"      element={<ScEstate />} />
          <Route path="/scExp/*"         element={<ScExp />} />
          <Route path="/scFinance/*"     element={<ScFinance />} />
          <Route path="/scFund/*"        element={<ScFund />} />
          <Route path="/scHr/*"          element={<ScHr />} />
          <Route path="/scInsurance/*"   element={<ScInsurance />} />
          <Route path="/scInvestment/*"  element={<ScInvestment />} />
          <Route path="/scKeepcoll/*"    element={<ScKeepcoll />} />
          <Route path="/scKeeping/*"     element={<ScKeeping />} />
          <Route path="/scLaw/*"         element={<ScLaw />} />
          <Route path="/scMobile/*"      element={<ScMobile />} />
          <Route path="/scPermit/*"      element={<ScPermit />} />
          <Route path="/scProDATA/*"     element={<ScProDATA />} />
          <Route path="/scReport/*"      element={<ScReport />} />
          <Route path="/scRing2Me/*"     element={<ScRing2Me />} />
          <Route path="/scScholarship/*" element={<ScScholarship />} />
          <Route path="/scStock/*"       element={<ScStock />} />
          <Route path="/scTeller/*"      element={<ScTeller />} />
          <Route path="/scTransbank/*"   element={<ScTransbank />} />
          <Route path="/scWelfare/*"     element={<ScWelfare />} />

          {/* rc* — report modules (navigated from sc* modules) */}
          <Route path="/rcAccount/*"     element={<RcAccount />} />
          <Route path="/rcAdmin/*"       element={<RcAdmin />} />
          <Route path="/rcApprove/*"     element={<RcApprove />} />
          <Route path="/rcAtm/*"         element={<RcAtm />} />
          <Route path="/rcContract/*"    element={<RcContract />} />
          <Route path="/rcCoordinate/*"  element={<RcCoordinate />} />
          <Route path="/rcDeposit/*"     element={<RcDeposit />} />
          <Route path="/rcEdocument/*"   element={<RcEdocument />} />
          <Route path="/rcElections/*"   element={<RcElections />} />
          <Route path="/rcEoffice/*"     element={<RcEoffice />} />
          <Route path="/rcFinance/*"     element={<RcFinance />} />
          <Route path="/rcFund/*"        element={<RcFund />} />
          <Route path="/rcHr/*"          element={<RcHr />} />
          <Route path="/rcInsurance/*"   element={<RcInsurance />} />
          <Route path="/rcInvestment/*"  element={<RcInvestment />} />
          <Route path="/rcKeepColl/*"    element={<RcKeepColl />} />
          <Route path="/rcKeeping/*"     element={<RcKeeping />} />
          <Route path="/rcLaw/*"         element={<RcLaw />} />
          <Route path="/rcProdata/*"     element={<RcProdata />} />
          <Route path="/rcRing2Me/*"     element={<RcRing2Me />} />
          <Route path="/rcScholarship/*" element={<RcScholarship />} />
          <Route path="/rcStock/*"       element={<RcStock />} />
          <Route path="/rcTeller/*"      element={<RcTeller />} />
          <Route path="/rcTransbank/*"   element={<RcTransbank />} />
          <Route path="/rcWelfare/*"     element={<RcWelfare />} />
          <Route path="/repQuery/*"      element={<RepQuery />} />
          <Route path="/rxForm/*"        element={<RxForm />} />
        </Route>

        <Route path="*" element={<Navigate to="/" replace />} />
      </Routes>
    </Suspense>
  )
}
