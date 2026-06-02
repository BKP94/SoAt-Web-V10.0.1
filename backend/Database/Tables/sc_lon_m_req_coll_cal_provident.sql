CREATE TABLE sc_lon_m_req_coll_cal_provident (
	loan_requestment_no varchar(15) NOT NULL DEFAULT 'cnv',
	seq_no double precision NOT NULL,
	salary decimal(15,2),
	phapa_mon decimal(15,2),
	phapa_year decimal(15,2),
	mem_mon decimal(15,2),
	mem_year decimal(15,2),
	total_cal decimal(15,2),
	mem_age double precision,
	rate_pay decimal(15,2)
) ;
ALTER TABLE sc_lon_m_req_coll_cal_provident ADD PRIMARY KEY (loan_requestment_no,seq_no);
ALTER TABLE sc_lon_m_req_coll_cal_provident ALTER COLUMN loan_requestment_no SET NOT NULL;
ALTER TABLE sc_lon_m_req_coll_cal_provident ALTER COLUMN seq_no SET NOT NULL;


