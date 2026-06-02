CREATE TABLE sc_acc_m_ucf_balsheet_group (
	balsheet_group varchar(10) NOT NULL,
	balsheet_name varchar(100)
) ;
ALTER TABLE sc_acc_m_ucf_balsheet_group ADD PRIMARY KEY (balsheet_group);
ALTER TABLE sc_acc_m_ucf_balsheet_group ALTER COLUMN balsheet_group SET NOT NULL;


