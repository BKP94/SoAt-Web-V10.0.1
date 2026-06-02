CREATE TABLE sc_dep_m_co_deposit (
	deposit_account_no varchar(15) NOT NULL,
	seq_no double precision NOT NULL,
	membership_no varchar(15),
	name varchar(50),
	surname varchar(50),
	authority char(1),
	signature_path varchar(50),
	id_card varchar(13),
	member_status char(1),
	member_type char(1),
	prename_code varchar(3)
) ;
COMMENT ON TABLE sc_dep_m_co_deposit IS E'!NN!';
ALTER TABLE sc_dep_m_co_deposit ADD PRIMARY KEY (deposit_account_no,seq_no);


