CREATE TABLE sc_hr_off_member_committee (
	official_no varchar(15) NOT NULL,
	coop_year integer NOT NULL DEFAULT 0,
	seq_no integer NOT NULL DEFAULT 0,
	committee_position varchar(6),
	coop_date timestamp,
	director char(1) DEFAULT '0',
	academic char(1) DEFAULT '0',
	finance_and_supplies char(1) DEFAULT '0',
	ritual_and_place char(1) DEFAULT '0',
	action char(1) DEFAULT '0',
	loan char(1) DEFAULT '0',
	study char(1) DEFAULT '0',
	other char(1) DEFAULT '0',
	other_desc varchar(50),
	end_date timestamp,
	sub_director char(1) DEFAULT '0',
	c_date_end_commitee timestamp,
	c_sangkaad varchar(250),
	c_commitee_reson_out varchar(250),
	c_status char(1),
	c_seq_of double precision,
	c_commitee_time double precision,
	c_remark varchar(250),
	c_issue_seq varchar(250),
	c_pos_vichakaan varchar(250),
	entry_id varchar(16),
	entry_date timestamp
) ;
ALTER TABLE sc_hr_off_member_committee ADD PRIMARY KEY (seq_no,official_no);
ALTER TABLE sc_hr_off_member_committee ALTER COLUMN official_no SET NOT NULL;
ALTER TABLE sc_hr_off_member_committee ALTER COLUMN coop_year SET NOT NULL;
ALTER TABLE sc_hr_off_member_committee ALTER COLUMN seq_no SET NOT NULL;


