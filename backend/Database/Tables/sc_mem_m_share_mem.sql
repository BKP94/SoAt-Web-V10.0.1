CREATE TABLE sc_mem_m_share_mem (
	membership_no varchar(15) NOT NULL,
	share_qty decimal(15,2),
	recrieve_share decimal(15,2),
	share_amount decimal(15,2),
	period_recrieve decimal(15,2),
	drop_status char(1),
	share_stock decimal(15,2),
	share_amount_old decimal(15,2),
	date_compomise timestamp,
	adj_share_date timestamp,
	old_share_qty decimal(15,2),
	old_share_amount decimal(15,2),
	pending_amt decimal(15,2),
	begin_balance decimal(15,2),
	share_coll_amount decimal(15,2),
	share_type_code varchar(6),
	new_share_amount decimal(15,2),
	new_status char(1),
	keeping_status char(1),
	compomise_count double precision,
	old_status char(1),
	new_share_qty decimal(15,2),
	keep_from_deposit char(1),
	deposit_account_no varchar(15),
	black_list_count bigint,
	maxseq double precision,
	amount_from_deposit decimal(15,2) DEFAULT 0,
	keep_memno varchar(15),
	share_amount_arrear decimal(15,2) DEFAULT 0,
	pending_arrear decimal(15,2) DEFAULT 0,
	active_chgshare_docno varchar(15),
	last_access_time varchar(23) DEFAULT to_char(statement_timestamp(),'DD/MM/YYYY HH:MI:SS.MS'),
	pending_arrear1 decimal(15,2) DEFAULT 0,
	share_stockx decimal(15,2) DEFAULT 0,
	active_restruc_docno varchar(15),
	period_compomise decimal(15,2),
	membership_no_old char(7),
	drop_effactive_status char(1),
	drop_effactive_begin timestamp,
	drop_effactive_end timestamp,
	monthly_method_docno char(15),
	cumulative_pending decimal(15,2),
	own_date timestamp,
	month_arr decimal(15,2)
) ;
COMMENT ON TABLE sc_mem_m_share_mem IS E'!N???????????N!';
COMMENT ON COLUMN sc_mem_m_share_mem.active_chgshare_docno IS E'!N????????????????????????????????? ??????N!!MM!';
COMMENT ON COLUMN sc_mem_m_share_mem.begin_balance IS E'!N?????????????N!!MM!';
COMMENT ON COLUMN sc_mem_m_share_mem.drop_status IS E'!N??????????N!!M?????????? ( ???  active_chgshare_docno )M!';
COMMENT ON COLUMN sc_mem_m_share_mem.keeping_status IS E'!N??????????????N!!MM!';
COMMENT ON COLUMN sc_mem_m_share_mem.membership_no IS E'!N?????????????N!!MM!';
COMMENT ON COLUMN sc_mem_m_share_mem.pending_amt IS E'!N?????????????N!!MM!';
COMMENT ON COLUMN sc_mem_m_share_mem.pending_arrear IS E'!N?????????????????N!!M????????????????????????????? ??????????????????? pending_amt ????M!';
COMMENT ON COLUMN sc_mem_m_share_mem.period_recrieve IS E'!N?????????N!!MM!';
COMMENT ON COLUMN sc_mem_m_share_mem.recrieve_share IS E'!N??????????N!!MM!';
COMMENT ON COLUMN sc_mem_m_share_mem.share_amount IS E'!N????????????N!!MM!';
COMMENT ON COLUMN sc_mem_m_share_mem.share_amount_arrear IS E'!N????????????N!!MM!';
COMMENT ON COLUMN sc_mem_m_share_mem.share_stock IS E'!N????????????N!!MM!';
CREATE INDEX idx_share_mem_share_stock ON sc_mem_m_share_mem (share_stock);
ALTER TABLE sc_mem_m_share_mem ADD PRIMARY KEY (membership_no);


