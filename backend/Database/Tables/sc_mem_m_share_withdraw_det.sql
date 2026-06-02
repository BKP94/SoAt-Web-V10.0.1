CREATE TABLE sc_mem_m_share_withdraw_det (
	withdraw_doc_no varchar(10) NOT NULL,
	seq_no double precision NOT NULL,
	share_type varchar(6) DEFAULT '1',
	period double precision,
	share_month decimal(15,2),
	share_stock decimal(15,2),
	share_withdraw decimal(15,2),
	share_status char(1),
	membership_recieve varchar(7)
) ;
COMMENT ON TABLE sc_mem_m_share_withdraw_det IS E'!NN!';
CREATE INDEX idx_sh_withdraw_det_docno ON sc_mem_m_share_withdraw_det (withdraw_doc_no);
ALTER TABLE sc_mem_m_share_withdraw_det ADD PRIMARY KEY (withdraw_doc_no,seq_no);


