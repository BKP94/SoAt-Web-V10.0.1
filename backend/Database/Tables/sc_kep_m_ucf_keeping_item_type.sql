CREATE TABLE sc_kep_m_ucf_keeping_item_type (
	keeping_type_code varchar(5) NOT NULL,
	keeping_type_name varchar(100),
	priority double precision,
	sorting double precision,
	keeping_type_group varchar(3),
	external_item char(1),
	account_id varchar(8),
	int_account_id varchar(8),
	goods_code varchar(8),
	goods_status char(1) DEFAULT '0',
	rep_acc char(1) DEFAULT '0',
	not_return_receipt char(1) DEFAULT '0',
	sing_flag double precision,
	not_ask_staus char(1) DEFAULT '0'
) ;
COMMENT ON TABLE sc_kep_m_ucf_keeping_item_type IS E'!N???????????????????N!!MM!';
COMMENT ON COLUMN sc_kep_m_ucf_keeping_item_type.account_id IS E'!N?????????N!!MM!';
COMMENT ON COLUMN sc_kep_m_ucf_keeping_item_type.external_item IS E'!N????????????(?????????????)N!!MM!';
COMMENT ON COLUMN sc_kep_m_ucf_keeping_item_type.keeping_type_code IS E'!N????N!!MM!';
COMMENT ON COLUMN sc_kep_m_ucf_keeping_item_type.keeping_type_group IS E'!N??????????????N!!MM!';
COMMENT ON COLUMN sc_kep_m_ucf_keeping_item_type.keeping_type_name IS E'!N????????N!!MM!';
COMMENT ON COLUMN sc_kep_m_ucf_keeping_item_type.priority IS E'!N?????N!!MM!';
COMMENT ON COLUMN sc_kep_m_ucf_keeping_item_type.sorting IS E'!N??????????N!!MM!';
CREATE INDEX idx_kep_ucf_keeptype_group ON sc_kep_m_ucf_keeping_item_type (keeping_type_group);
CREATE INDEX idx_kep_ucf_keeptype_sort ON sc_kep_m_ucf_keeping_item_type (sorting);
ALTER TABLE sc_kep_m_ucf_keeping_item_type ADD PRIMARY KEY (keeping_type_code);


