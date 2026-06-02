CREATE TABLE si_server_sites (
	app_name varchar(15) NOT NULL,
	site_name varchar(15) NOT NULL,
	site_url varchar(60),
	site_order double precision,
	active_session double precision
) ;
ALTER TABLE si_server_sites ADD PRIMARY KEY (app_name,site_name);
ALTER TABLE si_server_sites ALTER COLUMN app_name SET NOT NULL;
ALTER TABLE si_server_sites ALTER COLUMN site_name SET NOT NULL;


