CREATE TABLE sc_kep_t_monthly_receive_crm (
	membership_no varchar(15) NOT NULL,
	receive_year double precision NOT NULL,
	receive_month double precision NOT NULL,
	crem_code varchar(15) NOT NULL,
	money_amount decimal(15,2)
) ;
ALTER TABLE sc_kep_t_monthly_receive_crm ADD PRIMARY KEY (membership_no,receive_year,receive_month,crem_code);
ALTER TABLE sc_kep_t_monthly_receive_crm ALTER COLUMN membership_no SET NOT NULL;
ALTER TABLE sc_kep_t_monthly_receive_crm ALTER COLUMN receive_year SET NOT NULL;
ALTER TABLE sc_kep_t_monthly_receive_crm ALTER COLUMN receive_month SET NOT NULL;


