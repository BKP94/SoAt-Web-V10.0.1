CREATE TABLE sc_mem_m_app_own_info (
	application_form_no varchar(15) NOT NULL,
	own_work_age double precision DEFAULT 0,
	own_member_age double precision DEFAULT 0,
	own_total_loan decimal(15,2) DEFAULT 0,
	mati_detail varchar(250),
	share_stock decimal(15,2) DEFAULT 0,
	share_period double precision DEFAULT 0,
	own_member_month double precision DEFAULT 0,
	first_date timestamp,
	from_code varchar(6) DEFAULT '00',
	other_saving varchar(6) DEFAULT '00',
	old_member_date timestamp
) ;
COMMENT ON TABLE sc_mem_m_app_own_info IS E'!N????????????N!';
COMMENT ON COLUMN sc_mem_m_app_own_info.application_form_no IS E'!N?????????????N!!MM!';
COMMENT ON COLUMN sc_mem_m_app_own_info.mati_detail IS E'!N????????????N!!MM!';
COMMENT ON COLUMN sc_mem_m_app_own_info.own_member_age IS E'!N????????????????????N!!MM!';
COMMENT ON COLUMN sc_mem_m_app_own_info.own_total_loan IS E'!N?????????????????N!!MM!';
COMMENT ON COLUMN sc_mem_m_app_own_info.own_work_age IS E'!N?????????????????N!!MM!';
ALTER TABLE sc_mem_m_app_own_info ADD PRIMARY KEY (application_form_no);


