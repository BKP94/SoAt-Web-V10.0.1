CREATE TABLE sc_tmp_dep_import (
	time_id varchar(16) NOT NULL,
	seq_no double precision NOT NULL,
	line_string varchar(4000)
) ;
ALTER TABLE sc_tmp_dep_import ADD PRIMARY KEY (time_id,seq_no);
ALTER TABLE sc_tmp_dep_import ALTER COLUMN time_id SET NOT NULL;
ALTER TABLE sc_tmp_dep_import ALTER COLUMN seq_no SET NOT NULL;


