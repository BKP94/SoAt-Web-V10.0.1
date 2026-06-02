CREATE TABLE sc_wef_rule_sgl (
	seq_no double precision NOT NULL,
	sgl_desc varchar(20),
	paid_rate decimal(15,2)
) ;
ALTER TABLE sc_wef_rule_sgl ADD PRIMARY KEY (seq_no);
ALTER TABLE sc_wef_rule_sgl ALTER COLUMN seq_no SET NOT NULL;


