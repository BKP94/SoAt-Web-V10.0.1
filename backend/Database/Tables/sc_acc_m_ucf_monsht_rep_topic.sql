CREATE TABLE sc_acc_m_ucf_monsht_rep_topic (
	topic_code varchar(8) NOT NULL,
	topic_name varchar(50)
) ;
COMMENT ON TABLE sc_acc_m_ucf_monsht_rep_topic IS E'!NN!';
ALTER TABLE sc_acc_m_ucf_monsht_rep_topic ADD PRIMARY KEY (topic_code);


