CREATE TABLE sc_acc_m_paper_cash_det (
	paper_code varchar(8) NOT NULL,
	seq_no double precision NOT NULL,
	data_type varchar(6),
	data_group double precision,
	data_desc varchar(250),
	description varchar(200),
	begin_balance decimal(15,2),
	dr_amount decimal(15,2),
	cr_amount decimal(15,2),
	forward_balance decimal(6,2),
	dr_desc varchar(5),
	cr_desc varchar(5),
	upperline_status char(1),
	underline_status char(1),
	fontbold_status char(1),
	novisible char(1),
	nature varchar(6),
	od_status char(1) DEFAULT '0',
	profit_status char(1) DEFAULT '0'
) ;
COMMENT ON TABLE sc_acc_m_paper_cash_det IS E'!NN!';
ALTER TABLE sc_acc_m_paper_cash_det ADD PRIMARY KEY (paper_code,seq_no);


