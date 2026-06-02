CREATE TABLE sc_adm_wfroff_patientitemtype (
	item_type char(3),
	detail char(100),
	paid_officernotover decimal(15,2),
	paid_relationshipnotover decimal(15,2),
	paid_officer_status char(1),
	paid_relationship_status char(1),
	unit char(20),
	entry_id char(50),
	entry_branch char(2),
	entry_date timestamp
) ;


