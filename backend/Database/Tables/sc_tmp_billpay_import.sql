CREATE TABLE sc_tmp_billpay_import (
	bank_fin varchar(6) NOT NULL,
	seq_no double precision NOT NULL,
	billpay_data varchar(300)
) ;
ALTER TABLE sc_tmp_billpay_import ADD PRIMARY KEY (bank_fin,seq_no);
ALTER TABLE sc_tmp_billpay_import ALTER COLUMN bank_fin SET NOT NULL;
ALTER TABLE sc_tmp_billpay_import ALTER COLUMN seq_no SET NOT NULL;


