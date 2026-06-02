CREATE TABLE sc_amnat_grade_edit (
	membership_no varchar(15) NOT NULL,
	seq_no double precision NOT NULL,
	entry_date timestamp NOT NULL,
	entry_id varchar(16) NOT NULL,
	entry_br varchar(6) NOT NULL,
	operate_date timestamp NOT NULL,
	pre_grade varchar(6) NOT NULL,
	grade varchar(6) NOT NULL,
	chg_code varchar(6) NOT NULL,
	remark varchar(100)
) ;
ALTER TABLE sc_amnat_grade_edit ADD PRIMARY KEY (membership_no,seq_no);
ALTER TABLE sc_amnat_grade_edit ALTER COLUMN membership_no SET NOT NULL;
ALTER TABLE sc_amnat_grade_edit ALTER COLUMN seq_no SET NOT NULL;
ALTER TABLE sc_amnat_grade_edit ALTER COLUMN entry_date SET NOT NULL;
ALTER TABLE sc_amnat_grade_edit ALTER COLUMN entry_id SET NOT NULL;
ALTER TABLE sc_amnat_grade_edit ALTER COLUMN entry_br SET NOT NULL;
ALTER TABLE sc_amnat_grade_edit ALTER COLUMN operate_date SET NOT NULL;
ALTER TABLE sc_amnat_grade_edit ALTER COLUMN pre_grade SET NOT NULL;
ALTER TABLE sc_amnat_grade_edit ALTER COLUMN grade SET NOT NULL;
ALTER TABLE sc_amnat_grade_edit ALTER COLUMN chg_code SET NOT NULL;


