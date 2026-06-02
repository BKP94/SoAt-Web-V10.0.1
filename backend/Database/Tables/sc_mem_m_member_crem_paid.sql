CREATE TABLE sc_mem_m_member_crem_paid (
	membership_no varchar(15) NOT NULL,
	crem_paid varchar(6),
	bank_acc_no varchar(15),
	bank_name varchar(200)
) ;
ALTER TABLE sc_mem_m_member_crem_paid ADD PRIMARY KEY (membership_no);
ALTER TABLE sc_mem_m_member_crem_paid ALTER COLUMN membership_no SET NOT NULL;


