CREATE TABLE sc_rep_memno (
	rep_type varchar(20) NOT NULL,
	membership_no varchar(15) NOT NULL,
	order_no bigint NOT NULL
) ;
ALTER TABLE sc_rep_memno ADD PRIMARY KEY (rep_type,membership_no);
ALTER TABLE sc_rep_memno ALTER COLUMN rep_type SET NOT NULL;
ALTER TABLE sc_rep_memno ALTER COLUMN membership_no SET NOT NULL;
ALTER TABLE sc_rep_memno ALTER COLUMN order_no SET NOT NULL;


