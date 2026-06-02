CREATE TABLE sc_mem_m_ucf_othersaving (
	other_saving_member varchar(6) NOT NULL DEFAULT '00',
	saving_name varchar(250),
	sort_order decimal(15,2) DEFAULT (0)
) ;
COMMENT ON TABLE sc_mem_m_ucf_othersaving IS E'!N?????????????? - ??????????????N!';
COMMENT ON COLUMN sc_mem_m_ucf_othersaving.other_saving_member IS E'!N????N!!MM!';
COMMENT ON COLUMN sc_mem_m_ucf_othersaving.saving_name IS E'!N??????????????N!!MM!';
ALTER TABLE sc_mem_m_ucf_othersaving ADD PRIMARY KEY (other_saving_member);
ALTER TABLE sc_mem_m_ucf_othersaving ALTER COLUMN other_saving_member SET NOT NULL;


