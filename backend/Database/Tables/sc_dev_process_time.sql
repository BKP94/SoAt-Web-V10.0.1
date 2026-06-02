CREATE TABLE sc_dev_process_time (
	p_code varchar(50),
	p_remark varchar(100),
	p_time_total decimal(15,5) DEFAULT 0,
	p_time_count double precision DEFAULT 0
) ;
COMMENT ON TABLE sc_dev_process_time IS E'!NN!';


