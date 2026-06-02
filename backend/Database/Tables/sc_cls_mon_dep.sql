CREATE TABLE sc_cls_mon_dep (
	monthly_date timestamp NOT NULL,
	entry_id varchar(16) NOT NULL,
	entry_time timestamp
) ;
ALTER TABLE sc_cls_mon_dep ALTER COLUMN monthly_date SET NOT NULL;
ALTER TABLE sc_cls_mon_dep ALTER COLUMN entry_id SET NOT NULL;


