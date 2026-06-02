CREATE TABLE sc_mem_m_app_share (
	application_form_no varchar(15) NOT NULL,
	share_type_code varchar(6),
	share_stock decimal(15,2) DEFAULT 0,
	share_monthly decimal(15,2) DEFAULT 0,
	last_period numeric(38) DEFAULT 0
) ;
COMMENT ON TABLE sc_mem_m_app_share IS E'!N??????????N!';
COMMENT ON COLUMN sc_mem_m_app_share.application_form_no IS E'!N?????????????N!!MM!';
COMMENT ON COLUMN sc_mem_m_app_share.last_period IS E'!N?????????N!!MM!';
COMMENT ON COLUMN sc_mem_m_app_share.share_monthly IS E'!N?????????N!!MM!';
COMMENT ON COLUMN sc_mem_m_app_share.share_stock IS E'!N??????????N!!MM!';
COMMENT ON COLUMN sc_mem_m_app_share.share_type_code IS E'!NN!!MM!';
ALTER TABLE sc_mem_m_app_share ADD PRIMARY KEY (application_form_no);


