use Engl2
go


	create table Adverb
(Id int identity not null,
Infinitive varchar(20),
translete varchar(30),
Sinonim varchar(100),
IDTYPE int null,
numberPart int not null,
numberKind int not null

)
go 

drop table adverb

alter table Adverb
add constraint Unik_word_Adverb
Unique (Infinitive,translete)

insert Adverb
(Infinitive, translete,Sinonim,numberPart,numberKind)
vALUES
('at once',           '�����',             '����������',                3, 1),
('graphically',       '����������',        '��������',                  3, 5),
('exept',             '�����',                null,                   3, 7),
('directly',          '���������������',   '�����, ����������',         3, 5),
('instead',           '������',            '������',                    3, 7),
('suddenly',          '�����',             '��������, ����������',      3, 2),
('tonight',           '������� �������',   '(�����)',                   3, 2),
('exactly',           '�����',             '������, ��� ���',           3, 5),
('usually',           '������',            '�����������',               3, 5),
('certainly',         '�������',           '����������, ����������',    3, 7)
