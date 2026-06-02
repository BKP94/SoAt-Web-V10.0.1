CREATE TABLE sc_cnt_m_mem_detail_printform (
	user_object varchar(50) NOT NULL,
	seq_no numeric(38) NOT NULL DEFAULT 0,
	print_form varchar(200)
) ;
ALTER TABLE sc_cnt_m_mem_detail_printform ADD PRIMARY KEY (user_object,seq_no);
ALTER TABLE sc_cnt_m_mem_detail_printform ALTER COLUMN user_object SET NOT NULL;
ALTER TABLE sc_cnt_m_mem_detail_printform ALTER COLUMN seq_no SET NOT NULL;


