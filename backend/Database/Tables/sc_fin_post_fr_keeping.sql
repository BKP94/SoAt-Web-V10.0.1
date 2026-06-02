CREATE TABLE sc_fin_post_fr_keeping (
	receive_year double precision NOT NULL DEFAULT 0,
	receive_month double precision NOT NULL DEFAULT 0,
	salary_time double precision NOT NULL DEFAULT 0,
	member_group_keeping varchar(3) NOT NULL,
	post_to_vourcher char(1) DEFAULT '0',
	vourcher_no varchar(30) DEFAULT '[NONE]',
	receipt_date timestamp NOT NULL,
	control_id smallint DEFAULT 0,
	deposit_slip_no varchar(15)
) ;
ALTER TABLE sc_fin_post_fr_keeping ADD PRIMARY KEY (receive_year,receive_month,salary_time,member_group_keeping,receipt_date);


