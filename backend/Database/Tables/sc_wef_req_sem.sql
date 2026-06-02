CREATE TABLE sc_wef_req_sem (
	requestment_no varchar(15) NOT NULL,
	sem_code varchar(2),
	prename varchar(3),
	name varchar(30),
	surname varchar(30),
	id_card varchar(15),
	sem_date timestamp,
	sem_year varchar(4),
	sem_detail varchar(50),
	receive_name varchar(200),
	money_type_id varchar(6),
	bank_id varchar(6),
	bank_acc_no varchar(15)
) ;
ALTER TABLE sc_wef_req_sem ADD PRIMARY KEY (requestment_no);
ALTER TABLE sc_wef_req_sem ALTER COLUMN requestment_no SET NOT NULL;


