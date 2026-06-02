CREATE TABLE sc_sto_company_profile (
	id_company varchar(15) NOT NULL,
	name_com varchar(50),
	branch_com varchar(50),
	addr_com varchar(50),
	soi_com varchar(40),
	moo_com varchar(6),
	tumbon_com varchar(20),
	district_com varchar(10),
	province_com varchar(10),
	code_com varchar(6),
	tel_com varchar(40),
	fax_com varchar(20),
	e_mail varchar(30),
	road_com varchar(50),
	tax_com varchar(15),
	name_sell varchar(50),
	address_long varchar(250),
	company_status char(1),
	tax_rate decimal(5,4)
) ;
ALTER TABLE sc_sto_company_profile ADD PRIMARY KEY (id_company);


