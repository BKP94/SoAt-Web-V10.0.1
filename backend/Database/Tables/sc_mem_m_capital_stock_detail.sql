CREATE TABLE sc_mem_m_capital_stock_detail (
	account_year double precision NOT NULL,
	membership_no varchar(15) NOT NULL,
	member_group_no varchar(15),
	share_begining_balance decimal(15,2),
	share_coll_begin_balance decimal(15,2),
	incr_1st_month decimal(15,2),
	share_coll_1st decimal(15,2),
	share_coll_day1st decimal(15,2),
	share_coll_hold_1st double precision,
	incr_2nd_month decimal(15,2),
	share_coll_2nd decimal(15,2),
	share_coll_day2nd decimal(15,2),
	share_coll_hold_2nd double precision,
	incr_3rd_month decimal(15,2),
	share_coll_3rd decimal(15,2),
	share_coll_day3rd decimal(15,2),
	share_coll_hold_3rd double precision,
	incr_4th_month decimal(15,2),
	share_coll_4th decimal(15,2),
	share_coll_day4th decimal(15,2),
	share_coll_hold_4th double precision,
	incr_5th_month decimal(15,2),
	share_coll_5th decimal(15,2),
	share_coll_day5th decimal(15,2),
	share_coll_hold_5th double precision,
	incr_6th_month decimal(15,2),
	share_coll_6th decimal(15,2),
	share_coll_day6th decimal(15,2),
	share_coll_hold_6th double precision,
	incr_7th_month decimal(15,2),
	share_coll_7th decimal(15,2),
	share_coll_day7th decimal(15,2),
	share_coll_hold_7th double precision,
	incr_8th_month decimal(15,2),
	share_coll_8th decimal(15,2),
	share_coll_day8th decimal(15,2),
	share_coll_hold_8th double precision,
	incr_9th_month decimal(15,2),
	share_coll_9th decimal(15,2),
	share_coll_day9th decimal(15,2),
	share_coll_hold_9th double precision,
	incr_10th_month decimal(15,2),
	share_coll_10th decimal(15,2),
	share_coll_day10th decimal(15,2),
	share_coll_hold_10th double precision,
	incr_11th_month decimal(15,2),
	share_coll_11th decimal(15,2),
	share_coll_day11th decimal(15,2),
	share_coll_hold_11th double precision,
	incr_12th_month decimal(15,2),
	share_coll_12th decimal(15,2),
	share_coll_day12th decimal(15,2),
	share_coll_hold_12th double precision,
	emer_interest decimal(15,2),
	norm_interest decimal(15,2),
	spec_interest decimal(15,2),
	ending_balance decimal(15,2),
	ending_share_coll_balance decimal(15,2),
	bf_share_dividend decimal(15,2),
	bf_share_coll_dividend decimal(15,2),
	dividend decimal(15,2) NOT NULL DEFAULT 0,
	share_coll_dividend decimal(15,2),
	average_return decimal(15,2) NOT NULL DEFAULT 0,
	group_pay_code varchar(3),
	drop_dividend char(1),
	drop_average char(1),
	member_status char(1),
	entry_date timestamp,
	entry_id varchar(16),
	post_status char(1),
	post_id varchar(20),
	post_date timestamp,
	total_interest decimal(15,2),
	remark varchar(100),
	drop_reson varchar(6),
	emer_loan decimal(15,2),
	balance decimal(15,2),
	total_increment decimal(15,2),
	total_decrement decimal(15,2),
	total_interest_temp decimal(15,2),
	total_intall_temp decimal(15,2),
	total_intnot_temp decimal(15,2),
	total_intold_temp decimal(15,2),
	total_share_reward decimal(15,2) NOT NULL DEFAULT 0,
	yearly_reason varchar(50),
	voucher_no varchar(30),
	receipt_no char(10),
	over_buyshare decimal(15,2),
	comfirm_data char(1),
	total_money_reward decimal(15,2) NOT NULL DEFAULT 0,
	drop_money_reward char(1),
	drop_share_reward char(1),
	dividend_arrear_fw char(1),
	share_notdividen decimal(15,2),
	bank_acc_no varchar(15),
	bank_branch_code char(6),
	bank_code varchar(6),
	full_interest decimal(15,2) DEFAULT 0,
	dividend_payamount decimal(15,2) DEFAULT 0,
	dividend_payment decimal(15,2) DEFAULT 0,
	reduce_bangjag decimal(15,2) DEFAULT 0,
	dividend_arrear decimal(15,2) DEFAULT 0,
	divavr_arrear double precision DEFAULT 0,
	divavr_before double precision NOT NULL DEFAULT 0,
	divavr_byshare char(1) DEFAULT '0',
	divavr_seize char(1) DEFAULT '0',
	method_rec char(1),
	total_reward decimal(15,2),
	c_sum decimal(15,2),
	somtob_memref_post char(1) DEFAULT '0',
	somtob_memref_no varchar(15),
	somtob_amount decimal(15,2) NOT NULL DEFAULT 0,
	amn_501 char(1) DEFAULT '0',
	amn_502 char(1) DEFAULT '0',
	cop_amount decimal(15,2) DEFAULT 0,
	dividend_arrear_bf decimal(15,2),
	seize_dividend char(1),
	seize_average char(1),
	bank_branch char(6),
	cremation_kep_year decimal(15,2),
	cremkepyear_status char(1),
	share_type_code char(2),
	begin_balance decimal(15,2),
	dividend_arrear_next decimal(15,2),
	post_to_fin char(1),
	dividend_payamount_real decimal(15,2),
	temp_reduce_int decimal(15,2),
	temp_bk_total_int decimal(15,2)
) ;
COMMENT ON TABLE sc_mem_m_capital_stock_detail IS E'!N???????????????????N!';
COMMENT ON COLUMN sc_mem_m_capital_stock_detail.account_year IS E'!N??N!';
COMMENT ON COLUMN sc_mem_m_capital_stock_detail.average_return IS E'!N?????????N!';
COMMENT ON COLUMN sc_mem_m_capital_stock_detail.bank_acc_no IS E'!NN!';
COMMENT ON COLUMN sc_mem_m_capital_stock_detail.bank_code IS E'!NN!';
COMMENT ON COLUMN sc_mem_m_capital_stock_detail.dividend IS E'!N????????????N!';
COMMENT ON COLUMN sc_mem_m_capital_stock_detail.drop_average IS E'!N???????????N!';
COMMENT ON COLUMN sc_mem_m_capital_stock_detail.drop_dividend IS E'!N???????N!';
COMMENT ON COLUMN sc_mem_m_capital_stock_detail.emer_interest IS E'!NN!';
COMMENT ON COLUMN sc_mem_m_capital_stock_detail.ending_balance IS E'!NN!';
COMMENT ON COLUMN sc_mem_m_capital_stock_detail.entry_date IS E'!NN!';
COMMENT ON COLUMN sc_mem_m_capital_stock_detail.entry_id IS E'!NN!';
COMMENT ON COLUMN sc_mem_m_capital_stock_detail.group_pay_code IS E'!N???????????N!';
COMMENT ON COLUMN sc_mem_m_capital_stock_detail.incr_10th_month IS E'!NN!';
COMMENT ON COLUMN sc_mem_m_capital_stock_detail.incr_11th_month IS E'!NN!';
COMMENT ON COLUMN sc_mem_m_capital_stock_detail.incr_12th_month IS E'!NN!';
COMMENT ON COLUMN sc_mem_m_capital_stock_detail.incr_1st_month IS E'!NN!';
COMMENT ON COLUMN sc_mem_m_capital_stock_detail.incr_2nd_month IS E'!NN!';
COMMENT ON COLUMN sc_mem_m_capital_stock_detail.incr_3rd_month IS E'!NN!';
COMMENT ON COLUMN sc_mem_m_capital_stock_detail.incr_4th_month IS E'!NN!';
COMMENT ON COLUMN sc_mem_m_capital_stock_detail.incr_5th_month IS E'!NN!';
COMMENT ON COLUMN sc_mem_m_capital_stock_detail.incr_6th_month IS E'!NN!';
COMMENT ON COLUMN sc_mem_m_capital_stock_detail.incr_7th_month IS E'!NN!';
COMMENT ON COLUMN sc_mem_m_capital_stock_detail.incr_8th_month IS E'!NN!';
COMMENT ON COLUMN sc_mem_m_capital_stock_detail.incr_9th_month IS E'!NN!';
COMMENT ON COLUMN sc_mem_m_capital_stock_detail.member_group_no IS E'!NN!';
COMMENT ON COLUMN sc_mem_m_capital_stock_detail.member_status IS E'!NN!';
COMMENT ON COLUMN sc_mem_m_capital_stock_detail.membership_no IS E'!N???????N!';
COMMENT ON COLUMN sc_mem_m_capital_stock_detail.norm_interest IS E'!NN!';
COMMENT ON COLUMN sc_mem_m_capital_stock_detail.remark IS E'!NN!';
COMMENT ON COLUMN sc_mem_m_capital_stock_detail.share_begining_balance IS E'!NN!';
COMMENT ON COLUMN sc_mem_m_capital_stock_detail.share_notdividen IS E'!NN!';
COMMENT ON COLUMN sc_mem_m_capital_stock_detail.spec_interest IS E'!NN!';
COMMENT ON COLUMN sc_mem_m_capital_stock_detail.total_interest IS E'!N???????????N!';
COMMENT ON COLUMN sc_mem_m_capital_stock_detail.total_share_reward IS E'!NN!';
CREATE INDEX idx_ending_balance ON sc_mem_m_capital_stock_detail (ending_balance);
CREATE INDEX idx_mcap_total_interest ON sc_mem_m_capital_stock_detail (total_interest);
CREATE INDEX idx_memgr_cap ON sc_mem_m_capital_stock_detail (member_group_no);
CREATE INDEX idx_mem_capital_accyear ON sc_mem_m_capital_stock_detail (account_year);
CREATE INDEX idx_mem_capital_memno ON sc_mem_m_capital_stock_detail (membership_no);
ALTER TABLE sc_mem_m_capital_stock_detail ADD PRIMARY KEY (account_year,membership_no);
ALTER TABLE sc_mem_m_capital_stock_detail ALTER COLUMN dividend SET NOT NULL;
ALTER TABLE sc_mem_m_capital_stock_detail ALTER COLUMN average_return SET NOT NULL;
ALTER TABLE sc_mem_m_capital_stock_detail ALTER COLUMN total_share_reward SET NOT NULL;
ALTER TABLE sc_mem_m_capital_stock_detail ALTER COLUMN total_money_reward SET NOT NULL;
ALTER TABLE sc_mem_m_capital_stock_detail ALTER COLUMN divavr_before SET NOT NULL;
ALTER TABLE sc_mem_m_capital_stock_detail ALTER COLUMN somtob_amount SET NOT NULL;


