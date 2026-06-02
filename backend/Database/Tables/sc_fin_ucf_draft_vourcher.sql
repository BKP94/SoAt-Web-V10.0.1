CREATE TABLE sc_fin_ucf_draft_vourcher (
	draft_code char(15) NOT NULL,
	draft_desc varchar(100),
	vourcher_no varchar(30),
	draft_control char(15)
) ;
ALTER TABLE sc_fin_ucf_draft_vourcher ADD PRIMARY KEY (draft_code);
ALTER TABLE sc_fin_ucf_draft_vourcher ALTER COLUMN draft_code SET NOT NULL;


