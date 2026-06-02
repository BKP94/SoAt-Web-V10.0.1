CREATE TABLE sc_fin_ucf_give_report (
	give_rep varchar(6) NOT NULL,
	give_rep_desc varchar(200)
) ;
ALTER TABLE sc_fin_ucf_give_report ADD PRIMARY KEY (give_rep);
ALTER TABLE sc_fin_ucf_give_report ALTER COLUMN give_rep SET NOT NULL;


