CREATE TABLE sc_acc_m_account_year (
	account_year double precision NOT NULL,
	beginning_of_account timestamp,
	ending_of_account timestamp,
	close_account_status char(1),
	dividen_percent decimal(15,2) DEFAULT 0,
	average_percent decimal(15,2) DEFAULT 0,
	round_into decimal(15,2) DEFAULT 0,
	round_type char(1) DEFAULT '0',
	close_user varchar(16),
	close_time timestamp
) ;
COMMENT ON TABLE sc_acc_m_account_year IS E'!N???????N!!MM!';
COMMENT ON COLUMN sc_acc_m_account_year.account_year IS E'!N???????N!!MM!';
COMMENT ON COLUMN sc_acc_m_account_year.beginning_of_account IS E'!N???????????N!!MM!';
COMMENT ON COLUMN sc_acc_m_account_year.close_account_status IS E'!N?????????????N!!MM!';
COMMENT ON COLUMN sc_acc_m_account_year.ending_of_account IS E'!N?????????????N!!MM!';
ALTER TABLE sc_acc_m_account_year ADD PRIMARY KEY (account_year);


