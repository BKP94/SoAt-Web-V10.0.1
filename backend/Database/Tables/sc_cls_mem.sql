CREATE TABLE sc_cls_mem (
	monthly_date timestamp NOT NULL,
	mem_type_code varchar(6) NOT NULL,
	mem_bf integer DEFAULT 0,
	mem_new integer DEFAULT 0,
	mem_resign integer DEFAULT 0,
	mem_fired integer DEFAULT 0,
	mem_dead integer DEFAULT 0,
	mem_tran integer DEFAULT 0,
	mem_fw integer DEFAULT 0
) ;
ALTER TABLE sc_cls_mem ADD PRIMARY KEY (monthly_date,mem_type_code);
ALTER TABLE sc_cls_mem ALTER COLUMN monthly_date SET NOT NULL;
ALTER TABLE sc_cls_mem ALTER COLUMN mem_type_code SET NOT NULL;


