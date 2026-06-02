CREATE TABLE sc_cls_confirm_letter (
	confirm_date timestamp NOT NULL,
	membership_no varchar(15) NOT NULL
) ;
ALTER TABLE sc_cls_confirm_letter ADD PRIMARY KEY (confirm_date,membership_no);
ALTER TABLE sc_cls_confirm_letter ALTER COLUMN confirm_date SET NOT NULL;
ALTER TABLE sc_cls_confirm_letter ALTER COLUMN membership_no SET NOT NULL;


