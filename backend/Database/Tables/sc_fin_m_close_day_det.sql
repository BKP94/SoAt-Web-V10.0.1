CREATE TABLE sc_fin_m_close_day_det (
	journal_date timestamp NOT NULL,
	slip_group varchar(7) NOT NULL,
	postto_acc_status char(1) NOT NULL
) ;
ALTER TABLE sc_fin_m_close_day_det ADD PRIMARY KEY (journal_date,slip_group);
ALTER TABLE sc_fin_m_close_day_det ALTER COLUMN journal_date SET NOT NULL;
ALTER TABLE sc_fin_m_close_day_det ALTER COLUMN slip_group SET NOT NULL;
ALTER TABLE sc_fin_m_close_day_det ALTER COLUMN postto_acc_status SET NOT NULL;


