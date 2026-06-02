CREATE TABLE sc_acc_m_ucf_expire_cut (
	cut_paid_status double precision NOT NULL DEFAULT 0,
	description varchar(100),
	item_type varchar(3) NOT NULL
) ;
ALTER TABLE sc_acc_m_ucf_expire_cut ADD PRIMARY KEY (cut_paid_status);
ALTER TABLE sc_acc_m_ucf_expire_cut ALTER COLUMN cut_paid_status SET NOT NULL;
ALTER TABLE sc_acc_m_ucf_expire_cut ALTER COLUMN item_type SET NOT NULL;


