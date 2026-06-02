CREATE TABLE sc_mem_m_app_member_refer (
	application_form_no varchar(15),
	seq_no numeric(38) DEFAULT 0,
	membership_no varchar(15),
	concern_code varchar(6),
	member_name varchar(100)
) ;
COMMENT ON TABLE sc_mem_m_app_member_refer IS E'!N?????????????N!';
COMMENT ON COLUMN sc_mem_m_app_member_refer.application_form_no IS E'!N?????????????N!!MM!';
COMMENT ON COLUMN sc_mem_m_app_member_refer.concern_code IS E'!N????????????N!!MM!';
COMMENT ON COLUMN sc_mem_m_app_member_refer.membership_no IS E'!N???????N!!MM!';
COMMENT ON COLUMN sc_mem_m_app_member_refer.seq_no IS E'!N?????N!!MM!';
CREATE INDEX idx_mem_app_mem_refer ON sc_mem_m_app_member_refer (application_form_no);
CREATE INDEX idx_mem_app_mem_refer_memno ON sc_mem_m_app_member_refer (membership_no);


