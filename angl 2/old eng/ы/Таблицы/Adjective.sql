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
  ('important',       '������',        '������������, ������������',                   4,2,1),
  ('clear',           '�����',         '��������, ������, ����������',           	   4,2,1),
  ('similar',         '�������',       '��������, ���������������', 				   4,2,1),
  ('reliable',        '��������',      '�����������',								   4,2,1),
  ('embarrassed',     '���������',     '�����������, ������ � �����, ������������',	   4,2,1),
  ('low',             '������',        '���������',									   4,2,1),
  ('financial',       '����������',     NULL,										   4,2,1),
  ('virtual',         '�����������',   '�����������, ��������������',				   4,2,1),
  ('wide',            '�������',       '�������, ��������, ���������� (�� ������)',	   4,2,1),
  ('surprised',       '����������',    '����������',								   4,2,1),
  ('flashy',          '��������',      '����������� � �����, ��������',				   4,2,1),
  ('beloved',         '�������',       '������������',								   4,2,1),
  ('common',          '�����',         '����������������, �������, ������',			   4,2,1),
  ('compatible',      '�����������',   '����������',								   4,2,1),
  ('late',            '�������',       '����������, ��������, ���������, �������',	   4,2,1),
  ('cheap',           '�������',       '���������',									   4,2,1)