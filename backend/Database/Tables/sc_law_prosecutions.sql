CREATE TABLE sc_law_prosecutions (
	prosec_no varchar(15) NOT NULL,
	member_main varchar(7) NOT NULL,
	operate_date timestamp NOT NULL,
	entry_id varchar(16),
	entry_date timestamp,
	branch_id varchar(6),
	cancel_status char(1) DEFAULT '0',
	cancel_id varchar(16),
	cancel_br varchar(6),
	cancel_date timestamp,
	all_principal_balance decimal(15,2) DEFAULT 0,
	all_interest_arrear decimal(15,2) DEFAULT 0,
	lawyer varchar(50),
	remark varchar(1000),
	court_name varchar(255),
	prosec_date timestamp
) ;
ALTER TABLE sc_law_prosecutions ADD PRIMARY KEY (prosec_no);
ALTER TABLE sc_law_prosecutions ALTER COLUMN prosec_no SET NOT NULL;
ALTER TABLE sc_law_prosecutions ALTER COLUMN member_main SET NOT NULL;
ALTER TABLE sc_law_prosecutions ALTER COLUMN operate_date SET NOT NULL;


