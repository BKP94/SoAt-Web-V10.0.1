CREATE TABLE sc_mem_m_chg_method_div (
	membership_no varchar(15) NOT NULL,
	document_no varchar(15) NOT NULL,
	method_old varchar(3),
	bank_old varchar(6),
	bank_acc_old varchar(15),
	method_new varchar(3),
	bank_new varchar(6),
	bank_acc_new varchar(15),
	remark varchar(100)
) ;
ALTER TABLE sc_mem_m_chg_method_div ADD PRIMARY KEY (membership_no,document_no);
ALTER TABLE sc_mem_m_chg_method_div ALTER COLUMN membership_no SET NOT NULL;
ALTER TABLE sc_mem_m_chg_method_div ALTER COLUMN document_no SET NOT NULL;


