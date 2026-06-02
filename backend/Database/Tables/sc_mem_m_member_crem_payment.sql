CREATE TABLE sc_mem_m_member_crem_payment (
	membership_no varchar(15) NOT NULL,
	crem_type varchar(6) NOT NULL DEFAULT '00',
	seq_no double precision NOT NULL DEFAULT 0,
	crem_year double precision DEFAULT 0,
	payment_date timestamp,
	payment_type varchar(6) DEFAULT '00',
	crem_amount decimal(15,2) DEFAULT 0,
	deposit_slip_no varchar(15),
	officer_id varchar(16),
	cancel_id varchar(16),
	cancel_date timestamp,
	cancel_status char(1) DEFAULT '0',
	cancel_br varchar(6),
	crem_memno varchar(15),
	crem_pay_type varchar(6) DEFAULT '00',
	crem_detail char(6),
	donat_amount decimal(15,2) DEFAULT 0
) ;
ALTER TABLE sc_mem_m_member_crem_payment ADD PRIMARY KEY (membership_no,crem_type,seq_no);
ALTER TABLE sc_mem_m_member_crem_payment ALTER COLUMN membership_no SET NOT NULL;
ALTER TABLE sc_mem_m_member_crem_payment ALTER COLUMN crem_type SET NOT NULL;
ALTER TABLE sc_mem_m_member_crem_payment ALTER COLUMN seq_no SET NOT NULL;


