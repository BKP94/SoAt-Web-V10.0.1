CREATE TABLE sc_hr_ucf_souvenir_type (
	souvenir_type varchar(6) NOT NULL DEFAULT '00',
	souvenir_desc varchar(100)
) ;
ALTER TABLE sc_hr_ucf_souvenir_type ADD PRIMARY KEY (souvenir_type);
ALTER TABLE sc_hr_ucf_souvenir_type ALTER COLUMN souvenir_type SET NOT NULL;


