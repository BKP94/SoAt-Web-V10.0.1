CREATE TABLE sc_fin_m_give_group (
	give_year bigint NOT NULL,
	give_date timestamp NOT NULL,
	give_group varchar(15) NOT NULL,
	receive_name varchar(200) NOT NULL,
	by_mem char(1) NOT NULL DEFAULT '0',
	per_mem decimal(15,2) DEFAULT 0.00,
	own_mem bigint DEFAULT 0,
	own_amt decimal(15,2) DEFAULT 0.00,
	kep1_mem bigint DEFAULT 0,
	kep1_amt decimal(15,2) DEFAULT 0.00,
	kep2_mem bigint DEFAULT 0,
	kep2_amt decimal(15,2) DEFAULT 0.00,
	kep3_mem bigint DEFAULT 0,
	kep3_amt decimal(15,2) DEFAULT 0.00,
	kep_sum decimal(15,2) DEFAULT 0.00,
	kep_out decimal(15,2) DEFAULT 0.00,
	kep_in decimal(15,2) DEFAULT 0.00,
	kep_paid decimal(15,2) DEFAULT 0.00,
	post_status char(1) NOT NULL,
	keeping_fingroup varchar(15)
) ;
ALTER TABLE sc_fin_m_give_group ADD PRIMARY KEY (give_year,give_group);
ALTER TABLE sc_fin_m_give_group ALTER COLUMN give_year SET NOT NULL;
ALTER TABLE sc_fin_m_give_group ALTER COLUMN give_date SET NOT NULL;
ALTER TABLE sc_fin_m_give_group ALTER COLUMN give_group SET NOT NULL;
ALTER TABLE sc_fin_m_give_group ALTER COLUMN receive_name SET NOT NULL;
ALTER TABLE sc_fin_m_give_group ALTER COLUMN by_mem SET NOT NULL;
ALTER TABLE sc_fin_m_give_group ALTER COLUMN post_status SET NOT NULL;


