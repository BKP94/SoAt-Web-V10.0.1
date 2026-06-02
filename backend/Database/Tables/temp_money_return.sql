CREATE TABLE temp_money_return (
	seq_no double precision NOT NULL,
	memno varchar(15) DEFAULT '000000',
	opdate timestamp,
	amt double precision DEFAULT 0,
	method char(3),
	ref1 varchar(15),
	ref2 varchar(15),
	remark varchar(100),
	paid_date timestamp
) ;
ALTER TABLE temp_money_return ADD PRIMARY KEY (seq_no);
ALTER TABLE temp_money_return ALTER COLUMN seq_no SET NOT NULL;


