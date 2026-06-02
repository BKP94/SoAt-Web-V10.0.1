CREATE TABLE sc_cls_confirm_not_del (
	confirm_date timestamp NOT NULL
) ;
ALTER TABLE sc_cls_confirm_not_del ADD PRIMARY KEY (confirm_date);
ALTER TABLE sc_cls_confirm_not_del ALTER COLUMN confirm_date SET NOT NULL;


