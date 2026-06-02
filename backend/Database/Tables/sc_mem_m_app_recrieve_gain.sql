CREATE TABLE sc_mem_m_app_recrieve_gain (
	application_form_no varchar(15) NOT NULL,
	seq_no double precision NOT NULL DEFAULT 0,
	prename_code varchar(6) DEFAULT '000',
	gain_name varchar(50),
	gain_surname varchar(50),
	concern_code varchar(6),
	rec_date timestamp,
	book_date timestamp,
	order_number numeric(38),
	gain_percent decimal(15,4) DEFAULT 0,
	gain_id_card varchar(15),
	gain_address varchar(200),
	gain_telephone varchar(50),
	gain_desc varchar(200),
	gain_percent2 decimal(6,4),
	wef_type varchar(3)
) ;
COMMENT ON TABLE sc_mem_m_app_recrieve_gain IS E'!N?????????????????????????N!';
COMMENT ON COLUMN sc_mem_m_app_recrieve_gain.application_form_no IS E'!N?????????????N!!MM!';
COMMENT ON COLUMN sc_mem_m_app_recrieve_gain.book_date IS E'!NN!!MM!';
COMMENT ON COLUMN sc_mem_m_app_recrieve_gain.concern_code IS E'!N????????????N!!MM!';
COMMENT ON COLUMN sc_mem_m_app_recrieve_gain.gain_name IS E'!N????N!!M???????????????????????M!';
COMMENT ON COLUMN sc_mem_m_app_recrieve_gain.gain_surname IS E'!N???????N!!M??????????????????????????M!';
COMMENT ON COLUMN sc_mem_m_app_recrieve_gain.order_number IS E'!NN!!MM!';
COMMENT ON COLUMN sc_mem_m_app_recrieve_gain.prename_code IS E'!N????????N!!MM!';
COMMENT ON COLUMN sc_mem_m_app_recrieve_gain.rec_date IS E'!NN!!MM!';
COMMENT ON COLUMN sc_mem_m_app_recrieve_gain.seq_no IS E'!NN!!MM!';
CREATE INDEX idx_mem_app_recgain ON sc_mem_m_app_recrieve_gain (application_form_no);
CREATE INDEX idx_mem_app_recgain_concorn ON sc_mem_m_app_recrieve_gain (concern_code);
CREATE INDEX idx_mem_app_recgain_prename ON sc_mem_m_app_recrieve_gain (prename_code);
ALTER TABLE sc_mem_m_app_recrieve_gain ADD PRIMARY KEY (application_form_no,seq_no);


