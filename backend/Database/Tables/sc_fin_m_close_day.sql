CREATE TABLE sc_fin_m_close_day (
	branch_fin varchar(6) NOT NULL,
	journal_date timestamp NOT NULL,
	open_id varchar(16),
	open_time timestamp,
	open_clientid varchar(3),
	close_status char(1),
	close_id varchar(16),
	close_time timestamp,
	close_client varchar(3),
	postto_acc_status char(1),
	postto_acc_id varchar(16),
	postto_acc_time timestamp,
	postto_acc_client varchar(3)
) ;
COMMENT ON TABLE sc_fin_m_close_day IS E'!NN!';
ALTER TABLE sc_fin_m_close_day ADD PRIMARY KEY (branch_fin,journal_date);


