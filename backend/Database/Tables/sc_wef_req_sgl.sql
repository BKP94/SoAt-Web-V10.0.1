CREATE TABLE sc_wef_req_sgl (
	requestment_no varchar(15) NOT NULL,
	date_of_birth timestamp,
	approve_date timestamp,
	age_life varchar(100),
	age_mem varchar(100),
	remark varchar(200)
) ;
ALTER TABLE sc_wef_req_sgl ADD PRIMARY KEY (requestment_no);
ALTER TABLE sc_wef_req_sgl ALTER COLUMN requestment_no SET NOT NULL;


