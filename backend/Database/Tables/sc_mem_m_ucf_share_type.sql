CREATE TABLE sc_mem_m_ucf_share_type (
	share_type_code varchar(6) NOT NULL DEFAULT '1',
	share_type_desc varchar(100),
	ownership_changable_status char(1),
	share_stop_qty decimal(15,2),
	share_low_qty decimal(15,2),
	share_wid_qty decimal(15,2),
	share_stop_bht decimal(15,2),
	share_low_bht decimal(15,2),
	share_wid_bht decimal(15,2),
	min_share_hol decimal(15,2),
	max_share_hol decimal(15,2),
	share_comefirst varchar(6),
	hold_share_method varchar(6),
	percent_of_hold decimal(15,2),
	calculate_dividend_date timestamp,
	share_devidend_rate decimal(15,2),
	transfer_share_fee decimal(15,2),
	share_value decimal(15,2),
	effective_date timestamp,
	expire_date timestamp,
	payspec_count_period double precision
) ;
COMMENT ON TABLE sc_mem_m_ucf_share_type IS E'!NN!';
ALTER TABLE sc_mem_m_ucf_share_type ADD PRIMARY KEY (share_type_code);


