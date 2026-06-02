CREATE TABLE temp_up_depno (
	depno varchar(15) NOT NULL,
	bal decimal(15,2),
	accu decimal(15,2),
	lastcal timestamp,
	up_status varchar(15)
) ;
ALTER TABLE temp_up_depno ADD PRIMARY KEY (depno);
ALTER TABLE temp_up_depno ALTER COLUMN depno SET NOT NULL;


