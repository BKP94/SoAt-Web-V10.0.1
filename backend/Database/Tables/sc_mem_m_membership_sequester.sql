CREATE TABLE sc_mem_m_membership_sequester (
	membership_no varchar(15) NOT NULL,
	seq_no integer NOT NULL DEFAULT 0,
	sqter_status char(1) DEFAULT '0',
	sqter_share char(1) DEFAULT '0',
	sqter_div char(1) DEFAULT '0',
	sqter_aver char(1) DEFAULT '0',
	sqter_other char(1) DEFAULT '0',
	begin_date timestamp,
	end_date timestamp,
	department varchar(50),
	number_of_case varchar(50),
	plaintiff varchar(50),
	defendant varchar(200),
	condition varchar(200),
	remark varchar(200),
	address_desc varchar(200),
	prename_group varchar(200),
	fee_amount decimal(15,2) DEFAULT 0,
	cheque_no varchar(50),
	court varchar(200),
	money_type_id varchar(3),
	deed_status char(1) DEFAULT '0'
) ;
ALTER TABLE sc_mem_m_membership_sequester ADD PRIMARY KEY (membership_no,seq_no);
ALTER TABLE sc_mem_m_membership_sequester ALTER COLUMN membership_no SET NOT NULL;
ALTER TABLE sc_mem_m_membership_sequester ALTER COLUMN seq_no SET NOT NULL;


