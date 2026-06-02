CREATE TABLE sc_wef_rule_hrn (
	seq_no decimal(15,2) NOT NULL,
	hrn_type varchar(6),
	hrn_desc varchar(100),
	paid_rate double precision,
	max_paid decimal(15,2),
	per_paid decimal(15,2),
	class_type varchar(6)
) ;
ALTER TABLE sc_wef_rule_hrn ADD PRIMARY KEY (seq_no);
ALTER TABLE sc_wef_rule_hrn ALTER COLUMN seq_no SET NOT NULL;


