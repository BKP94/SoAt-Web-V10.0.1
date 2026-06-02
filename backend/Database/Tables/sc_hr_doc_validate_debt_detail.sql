CREATE TABLE sc_hr_doc_validate_debt_detail (
	doc_no varchar(15) NOT NULL,
	seq_no double precision NOT NULL,
	operate_date timestamp,
	id_card varchar(13) NOT NULL,
	membership_no varchar(15),
	prename_code varchar(6),
	member_name varchar(200),
	member_surname varchar(200),
	position varchar(200),
	group_position varchar(200),
	academic varchar(200)
) ;
ALTER TABLE sc_hr_doc_validate_debt_detail ADD PRIMARY KEY (doc_no,seq_no);
ALTER TABLE sc_hr_doc_validate_debt_detail ALTER COLUMN doc_no SET NOT NULL;
ALTER TABLE sc_hr_doc_validate_debt_detail ALTER COLUMN seq_no SET NOT NULL;
ALTER TABLE sc_hr_doc_validate_debt_detail ALTER COLUMN id_card SET NOT NULL;


