CREATE TABLE sc_inv_ucf_organize_type (
	type_of_org varchar(6) NOT NULL,
	type_org_desc varchar(35)
) ;
ALTER TABLE sc_inv_ucf_organize_type ADD PRIMARY KEY (type_of_org);
ALTER TABLE sc_inv_ucf_organize_type ALTER COLUMN type_of_org SET NOT NULL;


