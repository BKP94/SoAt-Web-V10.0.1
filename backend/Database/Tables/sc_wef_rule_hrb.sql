CREATE TABLE sc_wef_rule_hrb (
	seq_no decimal(15,2) NOT NULL,
	hrb_type varchar(6),
	hrb_desc varchar(100),
	paid_rate decimal(15,2)
) ;
ALTER TABLE sc_wef_rule_hrb ADD PRIMARY KEY (seq_no);
ALTER TABLE sc_wef_rule_hrb ALTER COLUMN seq_no SET NOT NULL;


