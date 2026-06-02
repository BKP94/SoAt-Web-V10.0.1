CREATE TABLE sc_lon_coll_by_obj (
	loan_type varchar(6) NOT NULL,
	seq_no double precision NOT NULL,
	loan_objective_code varchar(6),
	loan_max decimal(15,2),
	mem_coll double precision,
	non_mem_coll double precision
) ;
COMMENT ON TABLE sc_lon_coll_by_obj IS E'!NN!';
COMMENT ON COLUMN sc_lon_coll_by_obj.loan_max IS E'!N???????????N!!MM!';
COMMENT ON COLUMN sc_lon_coll_by_obj.loan_objective_code IS E'!N????????????N!!MM!';
COMMENT ON COLUMN sc_lon_coll_by_obj.mem_coll IS E'!N??????????????????????/??????N!!MM!';
ALTER TABLE sc_lon_coll_by_obj ADD PRIMARY KEY (loan_type,seq_no);


