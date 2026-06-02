CREATE TABLE sc_dep_t_deposit_slip_prin (
	deposit_slip_no varchar(15) NOT NULL,
	seq_no double precision NOT NULL DEFAULT 0,
	principal_amount decimal(15,2) DEFAULT 0,
	principal_item double precision DEFAULT 0
) ;
ALTER TABLE sc_dep_t_deposit_slip_prin ADD PRIMARY KEY (deposit_slip_no,seq_no);
ALTER TABLE sc_dep_t_deposit_slip_prin ALTER COLUMN deposit_slip_no SET NOT NULL;
ALTER TABLE sc_dep_t_deposit_slip_prin ALTER COLUMN seq_no SET NOT NULL;


