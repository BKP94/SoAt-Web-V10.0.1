CREATE TABLE sc_adm_wfroff_officer (
	officer_no char(6),
	officer_prename char(2),
	officer_name char(50),
	officer_surname char(50),
	membership_no char(7),
	officer_status char(1),
	office_sex char(1),
	officer_spouse_status char(1),
	office_spouse_no char(6),
	officer_amountson double precision,
	id_card char(13),
	salary decimal(15,2),
	birth_day timestamp,
	startworkdate timestamp,
	entry_id char(50),
	entry_branch char(2),
	entry_date timestamp,
	spous_pay char(1)
) ;


