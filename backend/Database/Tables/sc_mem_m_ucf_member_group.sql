CREATE TABLE sc_mem_m_ucf_member_group (
	member_group_no varchar(15) NOT NULL,
	member_group_name varchar(200),
	member_group_control varchar(15),
	member_group_type varchar(18),
	member_group_old varchar(50),
	member_group_level double precision,
	member_group_major varchar(6),
	district_code varchar(6),
	member_group_keeping varchar(6),
	province_code varchar(6),
	group_loan varchar(6),
	present_address varchar(200),
	present_road varchar(30),
	present_tambol varchar(50),
	district_group varchar(10),
	keeping_group varchar(6),
	member_group_fin varchar(6),
	group_name_show varchar(100),
	manager_name varchar(100),
	voucher_group char(6),
	voucher_name varchar(100),
	voucher_type char(1),
	voucher_group_name varchar(100),
	member_group_prename varchar(15),
	bank_code varchar(6),
	bank_branch varchar(6),
	mem_type_default varchar(6) DEFAULT '01',
	paid_status char(1) DEFAULT '0',
	age_limit smallint DEFAULT 0,
	branch_id varchar(6),
	keep_dep char(1) DEFAULT '0',
	int_calc_lastprocess char(1) DEFAULT '0',
	position_name varchar(100),
	head_name varchar(100),
	retire_age smallint DEFAULT 0,
	lost_salary char(1) DEFAULT '0',
	member_group_ref varchar(15),
	pre_group_name varchar(30),
	not_month_process char(1) DEFAULT '0',
	changegroup_status char(1) DEFAULT '0',
	group_cal_specpay char(1) DEFAULT '0',
	keeping_fingroup varchar(15) DEFAULT 'KMS',
	bank_acc_no varchar(15),
	cheque_code varchar(6) DEFAULT '00',
	ignor_retire_date char(1) DEFAULT '0',
	control_id smallint DEFAULT 0,
	salary_group varchar(15),
	ingore_dropshr_rule char(1) DEFAULT '0',
	mproc_dep_not char(1) DEFAULT '0',
	group_buy_shr_limit decimal(15,2) DEFAULT 0,
	payint_firstperiod_status char(1) DEFAULT '0',
	not_payint_firstperiod char(1) DEFAULT '0',
	not_collateral char(1) DEFAULT '0',
	ignore_salary_id char(1) DEFAULT '0',
	ignore_share_monthly char(1) DEFAULT '0',
	ignore_salary_amount char(1) DEFAULT '0',
	mem_type varchar(6) DEFAULT '00',
	not_sal char(1) DEFAULT '0',
	group_type char(1) DEFAULT '0',
	div_group varchar(15),
	group_dep char(1),
	group_fullname varchar(100),
	group_section varchar(15),
	region_group varchar(15),
	election_help varchar(15) DEFAULT '00',
	group_position varchar(6) DEFAULT '00',
	kep_method char(3),
	give_group varchar(15),
	election_control varchar(15),
	election_zone varchar(15),
	election_group_define varchar(15) DEFAULT '090000',
	ignor_tranfee char(1),
	ignor_retiredage char(1),
	group_advance char(15),
	not_trans_disk char(1),
	sum_min_loan_all decimal(15,4),
	sum_min_loan_norm decimal(15,4),
	group_not_loan char(1),
	show_salary char(1),
	not_in_bank char(1),
	invest_status char(1) DEFAULT '0',
	district_group_atm char(7),
	represen_control varchar(15),
	represen_zone varchar(15),
	represen_group_define varchar(15),
	group_cnv_old varchar(15)
) ;
COMMENT ON TABLE sc_mem_m_ucf_member_group IS E'!N?????????????? - ????????N!';
COMMENT ON COLUMN sc_mem_m_ucf_member_group.age_limit IS E'!N????????????????????N!';
COMMENT ON COLUMN sc_mem_m_ucf_member_group.bank_acc_no IS E'!N?????????????????N!!M????????????????????????????(??????????????????????????)M!';
COMMENT ON COLUMN sc_mem_m_ucf_member_group.bank_code IS E'!N??????N!!M?????????????????(??????????????????????????)M!';
COMMENT ON COLUMN sc_mem_m_ucf_member_group.branch_id IS E'!N????N!';
COMMENT ON COLUMN sc_mem_m_ucf_member_group.cheque_code IS E'!N???N!';
COMMENT ON COLUMN sc_mem_m_ucf_member_group.control_id IS E'!N??????????????/?????????????N!!M????????????????????????????M!';
COMMENT ON COLUMN sc_mem_m_ucf_member_group.district_code IS E'!N?????N!!MM!';
COMMENT ON COLUMN sc_mem_m_ucf_member_group.group_loan IS E'!N?????????N!';
COMMENT ON COLUMN sc_mem_m_ucf_member_group.ignor_retire_date IS E'!N?????????????????????N!!V1=????????????????,0=?????????????????????V!';
COMMENT ON COLUMN sc_mem_m_ucf_member_group.keeping_fingroup IS E'!N???????????(???????)N!';
COMMENT ON COLUMN sc_mem_m_ucf_member_group.member_group_control IS E'!N????????N!!MM!';
COMMENT ON COLUMN sc_mem_m_ucf_member_group.member_group_level IS E'!N??????????N!';
COMMENT ON COLUMN sc_mem_m_ucf_member_group.member_group_name IS E'!N?????????N!';
COMMENT ON COLUMN sc_mem_m_ucf_member_group.member_group_no IS E'!N?????????N!';
COMMENT ON COLUMN sc_mem_m_ucf_member_group.pre_group_name IS E'!N????????????N!';
COMMENT ON COLUMN sc_mem_m_ucf_member_group.province_code IS E'!N???????N!';
COMMENT ON COLUMN sc_mem_m_ucf_member_group.retire_age IS E'!N??????????N!';
CREATE INDEX idx_group_control ON sc_mem_m_ucf_member_group (member_group_control);
CREATE INDEX idx_group_type ON sc_mem_m_ucf_member_group (member_group_type);
ALTER TABLE sc_mem_m_ucf_member_group ADD PRIMARY KEY (member_group_no);


