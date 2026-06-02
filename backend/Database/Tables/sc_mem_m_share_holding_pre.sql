CREATE TABLE sc_mem_m_share_holding_pre (
	account_year double precision NOT NULL DEFAULT 0,
	membership_no varchar(15) NOT NULL,
	seq_no double precision NOT NULL DEFAULT 0,
	operate_date timestamp,
	item_type varchar(6),
	share_value decimal(15,2) DEFAULT 0,
	share_amount decimal(15,2) DEFAULT 0,
	share_stock decimal(15,2) DEFAULT 0,
	day_count double precision DEFAULT 0,
	dividend decimal(15,2) DEFAULT 0,
	effect_date timestamp,
	chg_status char(1) DEFAULT '0',
	member_group_no varchar(6),
	used_status char(1),
	doc_no varchar(15)
) ;
COMMENT ON TABLE sc_mem_m_share_holding_pre IS E'!NN!';
COMMENT ON COLUMN sc_mem_m_share_holding_pre.account_year IS E'!N??N!';
COMMENT ON COLUMN sc_mem_m_share_holding_pre.day_count IS E'!N????????N!';
COMMENT ON COLUMN sc_mem_m_share_holding_pre.dividend IS E'!N?????N!';
COMMENT ON COLUMN sc_mem_m_share_holding_pre.item_type IS E'!N??????N!';
COMMENT ON COLUMN sc_mem_m_share_holding_pre.membership_no IS E'!N?????????????N!';
COMMENT ON COLUMN sc_mem_m_share_holding_pre.operate_date IS E'!N????????????N!';
COMMENT ON COLUMN sc_mem_m_share_holding_pre.seq_no IS E'!N?????N!';
COMMENT ON COLUMN sc_mem_m_share_holding_pre.share_amount IS E'!NN!';
COMMENT ON COLUMN sc_mem_m_share_holding_pre.share_stock IS E'!NN!';
COMMENT ON COLUMN sc_mem_m_share_holding_pre.share_value IS E'!N?????????N!';
ALTER TABLE sc_mem_m_share_holding_pre ADD PRIMARY KEY (account_year,membership_no,seq_no);


