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
('according to',         'в соответствии с',           'на основании, согласно чему-то',    5,4),
('in accordance with',   'в соответствии с',           'на основании, согласно чему-то',    5,4),
('because of',           'из-за, по причине',          'благодаря, вследствие чего-то',     5,4),
('along with',           'одновременно с',             'так же, как и, равно как и',        5,4),
('abroad',                'за границей',                null,                               5,2),
('about',                'о, об, про,окол',            null,                                5,2),
('above',                'над',                         null,                               5,2),
('across',               'поперек',                    'через, сквозь',                     5,2),
('after',                'после',                        null,                              5,3),
('against',              'против',                     'напротив',                          5,2)
