CREATE TABLE si_security_user_pic (
	user_id varchar(16) NOT NULL,
	user_picture bytea
) ;
ALTER TABLE si_security_user_pic ALTER COLUMN user_id SET NOT NULL;


