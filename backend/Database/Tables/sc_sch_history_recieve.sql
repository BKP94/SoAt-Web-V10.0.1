CREATE TABLE sc_sch_history_recieve (
	application_form_no varchar(15) NOT NULL,
	seq_no decimal(15,2) NOT NULL,
	receive_year decimal(15,2),
	recieve_amount decimal(15,2),
	receive_from_group_no varchar(100)
) ;
ALTER TABLE sc_sch_history_recieve ADD PRIMARY KEY (application_form_no,seq_no);


