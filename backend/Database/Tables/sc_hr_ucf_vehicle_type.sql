CREATE TABLE sc_hr_ucf_vehicle_type (
	vehicle_type varchar(6) NOT NULL DEFAULT '00',
	vehicle_desc varchar(100)
) ;
ALTER TABLE sc_hr_ucf_vehicle_type ADD PRIMARY KEY (vehicle_type);
ALTER TABLE sc_hr_ucf_vehicle_type ALTER COLUMN vehicle_type SET NOT NULL;


