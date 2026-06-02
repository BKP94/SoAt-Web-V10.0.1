CREATE TABLE sc_lon_coll_by_group_mem (
	loan_type varchar(6) NOT NULL,
	group_position varchar(2) NOT NULL,
	mem_type varchar(2) NOT NULL,
	coll_count double precision,
	coll_amount decimal(15,2)
) ;
COMMENT ON TABLE sc_lon_coll_by_group_mem IS E'!NN!';
COMMENT ON COLUMN sc_lon_coll_by_group_mem.coll_amount IS E'!N???????????N!!MM!';
COMMENT ON COLUMN sc_lon_coll_by_group_mem.coll_count IS E'!N??????????????????????/??????N!!MM!';
COMMENT ON COLUMN sc_lon_coll_by_group_mem.group_position IS E'!N???????????N!!MM!';
COMMENT ON COLUMN sc_lon_coll_by_group_mem.mem_type IS E'!N??????N!!MM!';
ALTER TABLE sc_lon_coll_by_group_mem ADD PRIMARY KEY (loan_type,group_position,mem_type);


