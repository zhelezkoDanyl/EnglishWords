use Engl2
go


	create table Preposition
(Id int identity not null,
Infinitive varchar(20),
translete varchar(30),
Sinonim varchar(100),

numberPart int not null,
numberKind int not null

)
go 

drop table Preposition

alter table Preposition
add constraint Unik_word_prepos
Unique (Infinitive,translete)


insert Preposition
(Infinitive, translete,Sinonim,numberPart,numberKind)
values
('according to',         '� ������������ �',           '�� ���������, �������� ����-��',    5,4),
('in accordance with',   '� ������������ �',           '�� ���������, �������� ����-��',    5,4),
('because of',           '��-��, �� �������',          '���������, ���������� ����-��',     5,4),
('along with',           '������������ �',             '��� ��, ��� �, ����� ��� �',        5,4),
('abroad',                '�� ��������',                null,                               5,2),
('about',                '�, ��, ���,����',            null,                                5,2),
('above',                '���',                         null,                               5,2),
('across',               '�������',                    '�����, ������',                     5,2),
('after',                '�����',                        null,                              5,3),
('against',              '������',                     '��������',                          5,2)
