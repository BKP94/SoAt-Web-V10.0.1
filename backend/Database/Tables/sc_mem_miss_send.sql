CREATE TABLE sc_mem_miss_send (
	membership_no char(7) NOT NULL,
	seq_no double precision NOT NULL,
	miss_month double precision NOT NULL,
	miss_year double precision NOT NULL,
	miss_type char(3) NOT NULL,
	description char(50),
	entry_id char(10),
	client_name char(15),
	entry_date timestamp,
	amount decimal(15,2),
	interest decimal(15,2),
	status char(1)
) ;
CREATE UNIQUE INDEX sc_mem_miss_send_x ON sc_mem_miss_send (membership_no, seq_no, miss_month, miss_year);
ALTER TABLE sc_mem_miss_send ALTER COLUMN membership_no SET NOT NULL;
ALTER TABLE sc_mem_miss_send ALTER COLUMN seq_no SET NOT NULL;
ALTER TABLE sc_mem_miss_send ALTER COLUMN miss_month SET NOT NULL;
ALTER TABLE sc_mem_miss_send ALTER COLUMN miss_year SET NOT NULL;
ALTER TABLE sc_mem_miss_send ALTER COLUMN miss_type SET NOT NULL;


