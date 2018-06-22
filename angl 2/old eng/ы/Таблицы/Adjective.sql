use Engl2
go


	create table Adjective
(Id int identity not null,
Infinitive varchar(20),
translete varchar(30),
Sinonim varchar(100),
IDTYPE int Not null,
numberPart int not null,
numberKind int not null

)
go 

alter table Adjective
add constraint Unik_word_adj
Unique (Infinitive,translete)

insert Adjective
(Infinitive, translete,Sinonim,IDTYPE,numberPart,numberKind)
vALUES
  ('important',       'важный',        'значительный, существенный',                   4,2,1),
  ('clear',           'ясный',         'понятный, чыстый, отчетливый',           	   4,2,1),
  ('similar',         'похожий',       'подобный, соответствующий', 				   4,2,1),
  ('reliable',        'надежный',      'достоверный',								   4,2,1),
  ('embarrassed',     'смущенный',     'растерянный, сбитый с толку, сконфуженный',	   4,2,1),
  ('low',             'низкий',        'невысокий',									   4,2,1),
  ('financial',       'финансовый',     NULL,										   4,2,1),
  ('virtual',         'виртуальный',   'вактический, действительный',				   4,2,1),
  ('wide',            'широкий',       'большой, обширный, просторный (об одежде)',	   4,2,1),
  ('surprised',       'удивленный',    'изумленный',								   4,2,1),
  ('flashy',          'показной',      'бросающийся в глаза, кричащий',				   4,2,1),
  ('beloved',         'любимый',       'возлюбленный',								   4,2,1),
  ('common',          'общий',         'распространенный, обычный, частый',			   4,2,1),
  ('compatible',      'совместимый',   'сочетаемый',								   4,2,1),
  ('late',            'поздний',       'опоздавший, недавний, последний, прежний',	   4,2,1),
  ('cheap',           'дешевый',       'недорогой',									   4,2,1)