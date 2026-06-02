CREATE TABLE sc_msg_code_det (
	status_code varchar(50) NOT NULL,
	order_no double precision NOT NULL DEFAULT 0,
	text_before varchar(250),
	text_after varchar(250),
	code_desc varchar(250),
	visible_status char(1) DEFAULT '0',
	code_meaning varchar(200)
) ;
ALTER TABLE sc_msg_code_det ADD PRIMARY KEY (status_code,order_no);


