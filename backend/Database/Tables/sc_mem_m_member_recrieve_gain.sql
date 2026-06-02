CREATE TABLE sc_mem_m_member_recrieve_gain (
	membership_no varchar(15) NOT NULL,
	rec_no double precision NOT NULL,
	application_form_no varchar(15),
	prename_code varchar(6) DEFAULT '000',
	gain_name varchar(50),
	gain_surname varchar(50),
	conceern_code varchar(6),
	district_code varchar(6),
	tambol_code varchar(50),
	province_code varchar(6),
	rec_date timestamp,
	gain_address varchar(200),
	gain_postcode varchar(10),
	gain_percent decimal(15,4),
	book_date timestamp,
	gain_status char(1) DEFAULT '0',
	gain_amount decimal(15,2) DEFAULT 0,
	membership_gain varchar(7),
	order_number double precision DEFAULT 0,
	gain_id_card varchar(15),
	gain_telephone varchar(50),
	gain_desc varchar(200),
	gain_percent2 decimal(6,4) DEFAULT 0,
	change_doc_no varchar(15) NOT NULL,
	wef_type varchar(3)
) ;
COMMENT ON TABLE sc_mem_m_member_recrieve_gain IS E'!N?????????????????????????N!';
COMMENT ON COLUMN sc_mem_m_member_recrieve_gain.book_date IS E'!N???????????????????N!!MM!';
COMMENT ON COLUMN sc_mem_m_member_recrieve_gain.conceern_code IS E'!N????????????N!';
COMMENT ON COLUMN sc_mem_m_member_recrieve_gain.gain_name IS E'!N????N!';
COMMENT ON COLUMN sc_mem_m_member_recrieve_gain.gain_surname IS E'!N???????N!';
COMMENT ON COLUMN sc_mem_m_member_recrieve_gain.order_number IS E'!N??????????????N!!MM!';
COMMENT ON COLUMN sc_mem_m_member_recrieve_gain.prename_code IS E'!N????????????N!';
COMMENT ON COLUMN sc_mem_m_member_recrieve_gain.rec_date IS E'!NN!!MM!';
COMMENT ON COLUMN sc_mem_m_member_recrieve_gain.rec_no IS E'!NN!!MM!';
CREATE INDEX idx_mem_gain_conceern ON sc_mem_m_member_recrieve_gain (conceern_code);
CREATE INDEX idx_mem_gain_prename ON sc_mem_m_member_recrieve_gain (prename_code);
CREATE INDEX idx_recgain_001 ON sc_mem_m_member_recrieve_gain (membership_no);
ALTER TABLE sc_mem_m_member_recrieve_gain ADD PRIMARY KEY (membership_no,rec_no);
ALTER TABLE sc_mem_m_member_recrieve_gain ALTER COLUMN membership_no SET NOT NULL;
ALTER TABLE sc_mem_m_member_recrieve_gain ALTER COLUMN rec_no SET NOT NULL;
ALTER TABLE sc_mem_m_member_recrieve_gain ALTER COLUMN change_doc_no SET NOT NULL;


