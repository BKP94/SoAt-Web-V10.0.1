CREATE TABLE sc_acc_m_expire_histroy (
	material_id varchar(10) NOT NULL,
	seq_no double precision NOT NULL DEFAULT 0,
	shelf_id varchar(3),
	user_keep varchar(16),
	histroy_remark varchar(200),
	entry_id varchar(16),
	entry_date timestamp,
	entry_client varchar(30),
	operate_date timestamp,
	cut_paid_status double precision NOT NULL DEFAULT 0
) ;
ALTER TABLE sc_acc_m_expire_histroy ADD PRIMARY KEY (material_id,seq_no);
ALTER TABLE sc_acc_m_expire_histroy ALTER COLUMN material_id SET NOT NULL;
ALTER TABLE sc_acc_m_expire_histroy ALTER COLUMN seq_no SET NOT NULL;
ALTER TABLE sc_acc_m_expire_histroy ALTER COLUMN cut_paid_status SET NOT NULL;


