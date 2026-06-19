-- ============================================================================
-- step 6 function-first sweep — batch 10 : pkb_mwa (report helpers, Oracle→PG)
-- source: C:\SoAt_PEAN\Admin\Export\PACKAGE_BODY\PKB_MWA.sql
-- schema = pkb_mwa (call site: pkb_mwa.fp_...)
--
-- PORT (1 ตัว):
--   fp_get_resign_loncoll_str(doc) — รายชื่อผู้ค้ำในเอกสารลาออก (memno + ชื่อ, join ',')
-- ============================================================================

CREATE SCHEMA IF NOT EXISTS pkb_mwa;

-- ---- fp_get_resign_loncoll_str : "memno ชื่อ" ของผู้ค้ำในเอกสารลาออก doc (join ',') ----
--   legacy: cursor (contract_mem_name, contract_memno) → loop ||',' ||trim(memno)||' '||trim(name)
--   PG: string_agg แทน loop (เลียน fp_get_memcoll_str)
CREATE OR REPLACE FUNCTION pkb_mwa.fp_get_resign_loncoll_str(as_doc text)
RETURNS text LANGUAGE plpgsql STABLE AS $$
DECLARE ls_collateral text;
BEGIN
  SELECT string_agg(trim(contract_memno) || ' ' || trim(contract_mem_name), ',')
    INTO ls_collateral
    FROM sc_mem_m_resign_loncoll
   WHERE resign_doc_no = as_doc;
  RETURN trim(ls_collateral);
EXCEPTION
  WHEN others THEN RETURN NULL;
END;
$$;
