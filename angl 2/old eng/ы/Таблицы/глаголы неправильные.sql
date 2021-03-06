
create database Engl2
on
(
name = 'Engl2',
filename = 'D:\DB\Engl2DB.mdf',
size = 20mb,
maxsize = 200mb,
filegrowth = 20mb
)
log on
(
name = 'Logverb',
filename = 'D:\DB\Engl2DB.ldf',
size = 10mb,
maxsize = 100mb,
filegrowth = 10mb
)
COLLATE Cyrillic_General_CI_AS
go

use Engl2
go

create table Verb
(Id int identity not null,
Infinitive varchar(20),
PastSimple	varchar(20),
PastPart varchar(20),
translete varchar(30),
Sinonim varchar(100),
IDTYPE int Not null,
TopId int null,
numberPart int not null,
numberKind int not null
)
go 

 drop table Verb

alter table Verb
add constraint fk_verb_type
Foreign key (IDTYPE) references TypesOfFunctions(Id)

insert verb
(numberPart, numberKind, Infinitive,translete,Sinonim,IDTYPE)
values
(7,1,'laugh'      , '��������',       '��������',                                                          27),
(7,1,'manage'     , '���������',      '����������, �����������, ���������, ������, ����������',            27),
(7,1,'wear'       , '���� ������',    '������',                                                            27),
(7,1,'decide'     , '������',         '��������� �������, ������ �����',                                   27),
(7,1,'recognize'  , '����������',     '��������, ������������, ����������, ����������',                    27),
(7,1,'doubt'      , '�����������',    '�������� ��������,���� �����������, ����������',                    27),
(7,1,'include'    , '��������',       '���������, ����������,����� � ����� �������, ���������',            27),
(7,1,'avoid'      , '��������',       '�����������, ����������. ���������, �������������',                 27),
(7,1,'agree'      , '�����������',    '��������������, �������������, ����������, ��������� �� �������',   27),
(7,1,'achieve'    , '���������',      '����������, ������� ���������',                                     27)
go

insert Verb
(numberPart, numberKind, IDTYPE,Infinitive,PastSimple,PastPart,translete,Sinonim)
values
(7,2,28, 'be',          'was, were' , 'been'        ,'����' , '��������') ,                       
(7,2,28, 'beat',        'beat'	    , 'beaten'	    ,'����' , '��������'                               ),
(7,2,28, 'become' ,     'became'	, 'become'	    ,'�����������'			, null						),
(7,2,28, 'begin' ,      'began'	    , 'begun'	    ,'��������'				, null						),
(7,2,28, 'bend',        'bent'	    , 'bent'        ,'�����'				, null						),
(7,2,28, 'bet',         'bet'	    , 'bet'	        ,'������� ����' 		, null						),
(7,2,28, 'bite',        'bit'	    , 'bitten'	    ,'������'				, null						),
(7,2,28, 'blow',        'blew'	    , 'blown'	    ,'����' , '��������'								),
(7,2,28, 'break',       'broke'	    , 'broken'	    ,'������' , '���������, ���������'					),
(7,2,28, 'bring',       'brought'   , 'brought'	    ,'���������' , '���������, ����������'				),
(7,2,28, 'build',       'built'	    , 'built'	    ,'�������' , '���������'							),
(7,2,28, 'buy',         'bought'	, 'bought'	    ,'��������' , '�����������'						),
(7,2,28, 'catch',       'caught'	, 'caught'	    ,'������' , '�������, ��������'					),
(7,2,28, 'choose',      'chose'	    , 'chosen'	    ,'��������' , '��������'							),
(7,2,28, 'come'  ,      'came'	    , 'come'        ,'���������' , '���������'							),
(7,2,28, 'cost'  ,      'cost'	    , 'cost'	    ,'������' , '����������'							),
(7,2,28, 'cut'   ,      'cut'	    , 'cut'	        ,'������' , '���������'							),
(7,2,28, 'deal'  ,      'dealt'     , 'dealt'	    ,'����� ����' , '������������'						),
(7,2,28, 'dig'   ,      'dug'	    , 'dug'         ,'������' , '����'									),
(7,2,28, 'do'    ,      'did'	    , 'done'	    ,'������' , '���������'							),
(7,2,28, 'draw'  ,      'drew'      , 'drawn'	    ,'��������' , '�������'							),
(7,2,28, 'drink' ,      'drank'	    , 'drunk'	    ,'����'					, null						),
(7,2,28, 'drive' ,      'drove'	    , 'driven'	    ,'������' , '���������'							),
(7,2,28, 'eat'   ,      'ate'	    , 'eaten'	    ,'����' , '���������, �������'						),
(7,2,28, 'fall'  ,      'fell'	    , 'fallen'	    ,'������'	, null									),
(7,2,28, 'feed'   ,     'fed'	    , 'fed'	        ,'�������'	, null									),
(7,2,28, 'feel'   ,     'felt'	    , 'felt'	    ,'�����������' , '�������'							),
(7,2,28, 'fight'  ,     'fought'    , 'fought'	    ,'�������' , '���������, �������'					),
(7,2,28, 'find'   ,     'found'	    , 'found'	    ,'��������' , '������������'						),
(7,2,28, 'fly'    ,     'flew'	    , 'flown'	    ,'������'				, null						),
(7,2,28, 'forget' ,     'forgot'	, 'forgotten'   ,'�������� � (���-����)', null						),
(7,2,28, 'forgive',     'forgave'   , 'forgiven'    ,'�������'		, null								),
(7,2,28, 'freeze' ,     'froze'	    , 'frozen'	    ,'���������' , '��������'							),
(7,2,28, 'get'	  ,     'got'	    , 'got'	        ,'��������' , '����������'							),
(7,2,28, 'give'	  ,     'gave'	    , 'given'	    ,'����' , '������, ������'							),
(7,2,28, 'go'	  ,     'went'	    , 'gone'	    ,'����' , '���������'								),
(7,2,28, 'grow'	  ,     'grew'	    , 'grown'	    ,'�����' , '���������'								),
(7,2,28, 'hang'	  ,     'hung'	    , 'hung'        ,'������' , '�����������, ������'					),
(7,2,28, 'have'	  ,     'had'	    , 'had'	        ,'�����' , '��������'								),
(7,2,28, 'hear'	  ,     'heard'	    , 'heard'	    ,'�������' , ' ��������'							),
(7,2,28, 'hide'	  ,     'hid'	    , 'hidden'	    ,'�������' , '��������'							),
(7,2,28, 'hit'	  ,     'hit'	    , 'hit'	        ,'�������' , '��������'							),
(7,2,28, 'hold'	  ,     'held'	    , 'held'	    ,'�������' , '����������, �����������'				),
(7,2,28, 'hurt'	  ,     'hurt'	    , 'hurt'	    ,'������' , '��������� ����, �������'				),
(7,2,28, 'keep'	  ,     'kept'	    , 'kept'	    ,'�������' , '���������, ������������'				),
(7,2,28, 'know'	  ,     'knew'	    , 'known'	    ,'�����' , '����� �������������'					),
(7,2,28, 'lay'	  ,     'laid'	    , 'laid'	    ,'������' , '��������, ���������'					),
(7,2,28, 'lead'	  ,     'led'       , 'led'	        ,'����� �� �����' , '������������, ����������'		),
(7,2,28, 'leave'  ,     'left'	    , 'left'	    ,'��������' , '�������, �������, ���������'		),
(7,2,28, 'lend'	  ,     'lent'	    , 'lent'	    ,'����������' , '������ ������ (� ����)'			),
(7,2,28, 'let'	  ,     'let'	    , 'let'	        ,'���������' , '���������'							),
(7,2,28, 'lie'	  ,     'lay'	    , 'lain'	    ,'������'		, null								),
(7,2,28, 'light'  ,     'lit'	    , 'lit'	        ,'��������' , '���������, ��������'				),
(7,2,28, 'lose'	  ,     'lost'	    , 'lost'	    ,'������' , '��������, ����������'					),
(7,2,28, 'make'	  ,     'made'	    , 'made'	    ,'������' , '���������, �������������'				),
(7,2,28, 'mean'	  ,     'meant'	    , 'meant'	    ,'�������' , '����� � ����, �������������'			),
(7,2,28, 'meet'	  ,     'met'	    , 'met'	        ,'���������' , '�����������'						),
(7,2,28, 'pay'	  ,     'paid'	    , 'paid'	    ,'�������' , '����������, ��������������'			),
(7,2,28, 'put'	  ,     'put'	    , 'put'	        ,'�������' , '��������, ������'					),
(7,2,28, 'read'	  ,     'read'	    , 'read'	    ,'������' , '���������'							),
(7,2,28, 'ride'	  ,     'rode'	    , 'ridden'	    ,'����� ������' , '��������'						),
(7,2,28, 'ring'	  ,     'rang'	    , 'rung'	    ,'�������' , '�������'								),
(7,2,28, 'rise'	  ,     'rose'	    , 'risen'	    ,'���������' , '��������, �����������'				),
(7,2,28, 'run'	  ,     'ran'	    , 'run'	        ,'������' , '������'								),
(7,2,28, 'say'	  ,     'said'	    , 'said'	    ,'��������' , '�������, �����������'				),
(7,2,28, 'see'	  ,     'saw'	    , 'seen'	    ,'������'		, null								),
(7,2,28, 'seek'	  ,     'sought'	, 'sought'	    ,'������' , '�����������'							),
(7,2,28, 'sell'	  ,     'sold'	    , 'sold'	    ,'���������' , '���������'							),
(7,2,28, 'send'	  ,     'sent'	    , 'sent'	    ,'��������' , '����������, ��������'				),
(7,2,28, 'set'	  ,     'set'	    , 'set'	        ,'�������������' , '��������, ���������'			),
(7,2,28, 'shake'  ,     'shook'	    , 'shaken'	    ,'������' , '�����������'							),
(7,2,28, 'shine'	  , 'shone'	    , 'shone'	    ,'�������' , '�����, �������'						),
(7,2,28, 'shoot'	  , 'shot'	    , 'shot'	    ,'��������'		, null								),
(7,2,28, 'show'	  ,     'showed'	, 'shown'       ,'����������'	, null								),
(7,2,28, 'shut'	  ,     'shut'	    , 'shut'	    ,'���������' , '��������, ���������'				),
(7,2,28, 'sing'	  ,     'sang'	    , 'sung'	    ,'����' , '��������'								),
(7,2,28, 'sink'	  ,     'sank'	    , 'sunk'	    ,'������' , '�����������'							),
(7,2,28, 'sit'	  ,     'sat'	    , 'sat'	        ,'������' , '��������'								),
(7,2,28, 'sleep'	  , 'slept'	    , 'slept'	    ,'�����'		, null								),
(7,2,28, 'speak'	  , 'spoke'	    , 'spoken'	    ,'��������' , '�������������, �������������'		),
(7,2,28, 'spend'	  , 'spent'	    , 'spent'	    ,'�������' , '�����������, ��������� (�����)'		),
(7,2,28, 'stand'	  , 'stood'	    , 'stood'	    ,'������'		, null								),
(7,2,28, 'steal'	  , 'stole'	    , 'stolen'	    ,'��������' , '������'								),
(7,2,28, 'stick'	  , 'stuck'	    , 'stuck'	    ,'�������' , '�����������'							),
(7,2,28, 'strike'    ,  'struck'	, 'struck'      ,'�������' , '����, ��������'			),
(7,2,28, 'swear'     ,  'swore'	    , 'sworn'	    ,'��������' , '���������'							),
(7,2,28, 'sweep'	  , 'swept'	    , 'swept'	    ,'�����' , '���������, ���������'					),
(7,2,28, 'swim'	  ,     'swam'	    , 'swum'        ,'�������' , '�����'								),
(7,2,28, 'swing'	  , 'swung'	    , 'swung'	    ,'��������' , '���������'							),
(7,2,28, 'take'	  ,     'took'	    , 'taken'	    ,'�����' , '�������, �����'						),
(7,2,28, 'teach'	  , 'taught'	, 'taught'	    ,'�����' , '�������'								),
(7,2,28, 'tear'	  ,     'tore'	    , 'torn'	    ,'�����' , '��������'								),
(7,2,28, 'tell'	  ,     'told'	    , 'told'	    ,'������������'		, null							),
(7,2,28, 'think'	  , 'thought'   , 'thought'	    ,'������' , '�������, ����������'					),
(7,2,28, 'throw'	  , 'threw'	    , 'thrown'	    ,'�������' , '������, ������'						),
(7,2,28, 'understand',	'understood', 'understood'	,'��������' , '���������'							),
(7,2,28, 'wake',        'woke'	    , 'woken'	    ,'�����������' , '������'							),
(7,2,28, 'wear',        'wore'	    , 'worn'	    ,'������ (������)', null								),
(7,2,28, 'win',         'won'	    , 'won'	        ,'��������' , '��������'							),
(7,2,28, 'write',      'wrote'	    , 'written'	    ,'������' , '����������'                   		);
go


insert verb
(numberPart, numberKind, Infinitive,translete,Sinonim,IDTYPE)
values
(7,3,'take place' , '���������',      '�����������, ����� �����',                                          29)
go




                 
























drop table Verb

select * from Verb as v
where PastPart like '%en' --22
go

select * from Verb
where PastPart like '%wn' --7
go

select * from Verb
where PastPart like '%ght' --7
go


select * from Verb
where PastPart like '%g' --5
go

select * from Verb
where PastPart = Infinitive and PastSimple = PastPart --10
go

select * from Verb
where PastPart = Infinitive and PastSimple != PastPart --3
go

select * from Verb
where PastPart != Infinitive and PastSimple = PastPart and PastPart like '%k'--46 t (-ght ot) - d -g
go

select * from Verb
where PastPart != Infinitive and PastSimple != PastPart and (PastPart like '%k' or PastPart like '%g'
or PastPart like '%n' ) or PastPart like '%wn'           --41 -en -wn -g
go

