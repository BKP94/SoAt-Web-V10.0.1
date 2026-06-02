CREATE TABLE messages (
	msgid varchar(40) NOT NULL,
	msgtitle varchar(255),
	msgtext varchar(255),
	msgicon varchar(12),
	msgbutton varchar(17),
	msgdefaultbutton double precision,
	msgseverity double precision,
	msgprint char(1) DEFAULT '0',
	msguserinput char(1) DEFAULT '0'
) ;
COMMENT ON TABLE messages IS E'!NN!';
COMMENT ON COLUMN messages.msgbutton IS E'!NmsgbuttonN!!MM!';
COMMENT ON COLUMN messages.msgdefaultbutton IS E'!NmsgdefaultbuttonN!!MM!';
COMMENT ON COLUMN messages.msgicon IS E'!NmsgiconN!!MM!';
COMMENT ON COLUMN messages.msgid IS E'!NmsgidN!!MM!';
COMMENT ON COLUMN messages.msgprint IS E'!NmsgprintN!!MM!';
COMMENT ON COLUMN messages.msgseverity IS E'!NmsgseverityN!!MM!';
COMMENT ON COLUMN messages.msgtext IS E'!NmsgtextN!!MM!';
COMMENT ON COLUMN messages.msgtitle IS E'!NmsgtitleN!!MM!';
COMMENT ON COLUMN messages.msguserinput IS E'!NmsgserinputN!!MM!';
ALTER TABLE messages ADD PRIMARY KEY (msgid);


