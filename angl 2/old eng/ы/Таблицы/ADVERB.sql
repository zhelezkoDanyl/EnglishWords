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
('at once',           'сразу',             'немедленно',                3, 1),
('graphically',       'графически',        'наглядно',                  3, 5),
('exept',             'кроме',                null,                   3, 7),
('directly',          'непосредственно',   'прямо, откровенно',         3, 5),
('instead',           'вместо',            'взамен',                    3, 7),
('suddenly',          'вдруг',             'внезапно, неожиданно',      3, 2),
('tonight',           'сегодня вечером',   '(ночью)',                   3, 2),
('exactly',           'точно',             'именно, как раз',           3, 5),
('usually',           'обычно',            'обыкновенно',               3, 5),
('certainly',         'конечно',           'непременно, безусловно',    3, 7)
