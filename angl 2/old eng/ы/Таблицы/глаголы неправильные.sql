
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
(7,1,'laugh'      , 'смеяться',       'хохотать',                                                          27),
(7,1,'manage'     , 'управлять',      'руководить, справляться, удаваться, суметь, справиться',            27),
(7,1,'wear'       , 'быть одетым',    'носить',                                                            27),
(7,1,'decide'     , 'решать',         'принимать решение, делать выбор',                                   27),
(7,1,'recognize'  , 'признавать',     'узнавать, распознавать, опознавать, осознавать',                    27),
(7,1,'doubt'      , 'сомневаться',    'выражать сомнение,быть неуверенным, усомниться',                    27),
(7,1,'include'    , 'включать',       'содержать, охватывать,иметь в своем составе, учитывать',            27),
(7,1,'avoid'      , 'избегать',       'сторониться, уклоняться. исключать, предотвращать',                 27),
(7,1,'agree'      , 'соглашаться',    'договариваться, согласовывать, утверждать, сходиться во мнениях',   27),
(7,1,'achieve'    , 'достигать',      'добиваться, успешно выполнять',                                     27)
go

insert Verb
(numberPart, numberKind, IDTYPE,Infinitive,PastSimple,PastPart,translete,Sinonim)
values
(7,2,28, 'be',          'was, were' , 'been'        ,'быть' , 'являться') ,                       
(7,2,28, 'beat',        'beat'	    , 'beaten'	    ,'бить' , 'колотить'                               ),
(7,2,28, 'become' ,     'became'	, 'become'	    ,'становиться'			, null						),
(7,2,28, 'begin' ,      'began'	    , 'begun'	    ,'начинать'				, null						),
(7,2,28, 'bend',        'bent'	    , 'bent'        ,'гнуть'				, null						),
(7,2,28, 'bet',         'bet'	    , 'bet'	        ,'держать пари' 		, null						),
(7,2,28, 'bite',        'bit'	    , 'bitten'	    ,'кусать'				, null						),
(7,2,28, 'blow',        'blew'	    , 'blown'	    ,'дуть' , 'выдыхать'								),
(7,2,28, 'break',       'broke'	    , 'broken'	    ,'ломать' , 'разбивать, разрушать'					),
(7,2,28, 'bring',       'brought'   , 'brought'	    ,'приносить' , 'привозить, доставлять'				),
(7,2,28, 'build',       'built'	    , 'built'	    ,'строить' , 'сооружать'							),
(7,2,28, 'buy',         'bought'	, 'bought'	    ,'покупать' , 'приобретать'						),
(7,2,28, 'catch',       'caught'	, 'caught'	    ,'ловить' , 'поймать, схватить'					),
(7,2,28, 'choose',      'chose'	    , 'chosen'	    ,'выбирать' , 'избирать'							),
(7,2,28, 'come'  ,      'came'	    , 'come'        ,'приходить' , 'подходить'							),
(7,2,28, 'cost'  ,      'cost'	    , 'cost'	    ,'стоить' , 'обходиться'							),
(7,2,28, 'cut'   ,      'cut'	    , 'cut'	        ,'резать' , 'разрезать'							),
(7,2,28, 'deal'  ,      'dealt'     , 'dealt'	    ,'иметь дело' , 'распределять'						),
(7,2,28, 'dig'   ,      'dug'	    , 'dug'         ,'копать' , 'рыть'									),
(7,2,28, 'do'    ,      'did'	    , 'done'	    ,'делать' , 'выполнять'							),
(7,2,28, 'draw'  ,      'drew'      , 'drawn'	    ,'рисовать' , 'чертить'							),
(7,2,28, 'drink' ,      'drank'	    , 'drunk'	    ,'пить'					, null						),
(7,2,28, 'drive' ,      'drove'	    , 'driven'	    ,'ездить' , 'подвозить'							),
(7,2,28, 'eat'   ,      'ate'	    , 'eaten'	    ,'есть' , 'поглощать, поедать'						),
(7,2,28, 'fall'  ,      'fell'	    , 'fallen'	    ,'падать'	, null									),
(7,2,28, 'feed'   ,     'fed'	    , 'fed'	        ,'кормить'	, null									),
(7,2,28, 'feel'   ,     'felt'	    , 'felt'	    ,'чувствовать' , 'ощущать'							),
(7,2,28, 'fight'  ,     'fought'    , 'fought'	    ,'драться' , 'сражаться, воевать'					),
(7,2,28, 'find'   ,     'found'	    , 'found'	    ,'находить' , 'обнаруживать'						),
(7,2,28, 'fly'    ,     'flew'	    , 'flown'	    ,'летать'				, null						),
(7,2,28, 'forget' ,     'forgot'	, 'forgotten'   ,'забывать о (чём-либо)', null						),
(7,2,28, 'forgive',     'forgave'   , 'forgiven'    ,'прощать'		, null								),
(7,2,28, 'freeze' ,     'froze'	    , 'frozen'	    ,'замерзать' , 'замирать'							),
(7,2,28, 'get'	  ,     'got'	    , 'got'	        ,'получать' , 'добираться'							),
(7,2,28, 'give'	  ,     'gave'	    , 'given'	    ,'дать' , 'подать, дарить'							),
(7,2,28, 'go'	  ,     'went'	    , 'gone'	    ,'идти' , 'двигаться'								),
(7,2,28, 'grow'	  ,     'grew'	    , 'grown'	    ,'расти' , 'вырастать'								),
(7,2,28, 'hang'	  ,     'hung'	    , 'hung'        ,'вешать' , 'развешивать, висеть'					),
(7,2,28, 'have'	  ,     'had'	    , 'had'	        ,'иметь' , 'обладать'								),
(7,2,28, 'hear'	  ,     'heard'	    , 'heard'	    ,'слышать' , ' услышать'							),
(7,2,28, 'hide'	  ,     'hid'	    , 'hidden'	    ,'прятать' , 'скрывать'							),
(7,2,28, 'hit'	  ,     'hit'	    , 'hit'	        ,'ударять' , 'поражать'							),
(7,2,28, 'hold'	  ,     'held'	    , 'held'	    ,'держать' , 'удерживать, задерживать'				),
(7,2,28, 'hurt'	  ,     'hurt'	    , 'hurt'	    ,'ранить' , 'причинять боль, ушибить'				),
(7,2,28, 'keep'	  ,     'kept'	    , 'kept'	    ,'хранить' , 'сохранять, поддерживать'				),
(7,2,28, 'know'	  ,     'knew'	    , 'known'	    ,'знать' , 'иметь представление'					),
(7,2,28, 'lay'	  ,     'laid'	    , 'laid'	    ,'класть' , 'положить, покрывать'					),
(7,2,28, 'lead'	  ,     'led'       , 'led'	        ,'вести за собой' , 'сопровождать, руководить'		),
(7,2,28, 'leave'  ,     'left'	    , 'left'	    ,'покидать' , 'уходить, уезжать, оставлять'		),
(7,2,28, 'lend'	  ,     'lent'	    , 'lent'	    ,'одалживать' , 'давать взаймы (в долг)'			),
(7,2,28, 'let'	  ,     'let'	    , 'let'	        ,'позволять' , 'разрешать'							),
(7,2,28, 'lie'	  ,     'lay'	    , 'lain'	    ,'лежать'		, null								),
(7,2,28, 'light'  ,     'lit'	    , 'lit'	        ,'зажигать' , 'светиться, освещать'				),
(7,2,28, 'lose'	  ,     'lost'	    , 'lost'	    ,'терять' , 'лишаться, утрачивать'					),
(7,2,28, 'make'	  ,     'made'	    , 'made'	    ,'делать' , 'создавать, изготавливать'				),
(7,2,28, 'mean'	  ,     'meant'	    , 'meant'	    ,'значить' , 'иметь в виду, подразумевать'			),
(7,2,28, 'meet'	  ,     'met'	    , 'met'	        ,'встречать' , 'знакомиться'						),
(7,2,28, 'pay'	  ,     'paid'	    , 'paid'	    ,'платить' , 'оплачивать, рассчитываться'			),
(7,2,28, 'put'	  ,     'put'	    , 'put'	        ,'ставить' , 'помещать, класть'					),
(7,2,28, 'read'	  ,     'read'	    , 'read'	    ,'читать' , 'прочитать'							),
(7,2,28, 'ride'	  ,     'rode'	    , 'ridden'	    ,'ехать верхом' , 'кататься'						),
(7,2,28, 'ring'	  ,     'rang'	    , 'rung'	    ,'звенеть' , 'звонить'								),
(7,2,28, 'rise'	  ,     'rose'	    , 'risen'	    ,'восходить' , 'вставать, подниматься'				),
(7,2,28, 'run'	  ,     'ran'	    , 'run'	        ,'бежать' , 'бегать'								),
(7,2,28, 'say'	  ,     'said'	    , 'said'	    ,'говорить' , 'сказать, произносить'				),
(7,2,28, 'see'	  ,     'saw'	    , 'seen'	    ,'видеть'		, null								),
(7,2,28, 'seek'	  ,     'sought'	, 'sought'	    ,'искать' , 'разыскивать'							),
(7,2,28, 'sell'	  ,     'sold'	    , 'sold'	    ,'продавать' , 'торговать'							),
(7,2,28, 'send'	  ,     'sent'	    , 'sent'	    ,'посылать' , 'отправлять, отсылать'				),
(7,2,28, 'set'	  ,     'set'	    , 'set'	        ,'устанавливать' , 'задавать, назначать'			),
(7,2,28, 'shake'  ,     'shook'	    , 'shaken'	    ,'трясти' , 'встряхивать'							),
(7,2,28, 'shine'	  , 'shone'	    , 'shone'	    ,'светить' , 'сиять, озарять'						),
(7,2,28, 'shoot'	  , 'shot'	    , 'shot'	    ,'стрелять'		, null								),
(7,2,28, 'show'	  ,     'showed'	, 'shown'       ,'показывать'	, null								),
(7,2,28, 'shut'	  ,     'shut'	    , 'shut'	    ,'закрывать' , 'запирать, затворять'				),
(7,2,28, 'sing'	  ,     'sang'	    , 'sung'	    ,'петь' , 'напевать'								),
(7,2,28, 'sink'	  ,     'sank'	    , 'sunk'	    ,'тонуть' , 'погружаться'							),
(7,2,28, 'sit'	  ,     'sat'	    , 'sat'	        ,'сидеть' , 'садиться'								),
(7,2,28, 'sleep'	  , 'slept'	    , 'slept'	    ,'спать'		, null								),
(7,2,28, 'speak'	  , 'spoke'	    , 'spoken'	    ,'говорить' , 'разговаривать, высказываться'		),
(7,2,28, 'spend'	  , 'spent'	    , 'spent'	    ,'тратить' , 'расходовать, проводить (время)'		),
(7,2,28, 'stand'	  , 'stood'	    , 'stood'	    ,'стоять'		, null								),
(7,2,28, 'steal'	  , 'stole'	    , 'stolen'	    ,'воровать' , 'красть'								),
(7,2,28, 'stick'	  , 'stuck'	    , 'stuck'	    ,'втыкать' , 'приклеивать'							),
(7,2,28, 'strike'    ,  'struck'	, 'struck'      ,'ударять' , 'бить, поражать'			),
(7,2,28, 'swear'     ,  'swore'	    , 'sworn'	    ,'клясться' , 'присягать'							),
(7,2,28, 'sweep'	  , 'swept'	    , 'swept'	    ,'мести' , 'подметать, смахивать'					),
(7,2,28, 'swim'	  ,     'swam'	    , 'swum'        ,'плавать' , 'плыть'								),
(7,2,28, 'swing'	  , 'swung'	    , 'swung'	    ,'качаться' , 'вертеться'							),
(7,2,28, 'take'	  ,     'took'	    , 'taken'	    ,'брать' , 'хватать, взять'						),
(7,2,28, 'teach'	  , 'taught'	, 'taught'	    ,'учить' , 'обучать'								),
(7,2,28, 'tear'	  ,     'tore'	    , 'torn'	    ,'рвать' , 'отрывать'								),
(7,2,28, 'tell'	  ,     'told'	    , 'told'	    ,'рассказывать'		, null							),
(7,2,28, 'think'	  , 'thought'   , 'thought'	    ,'думать' , 'мыслить, размышлять'					),
(7,2,28, 'throw'	  , 'threw'	    , 'thrown'	    ,'бросать' , 'кидать, метать'						),
(7,2,28, 'understand',	'understood', 'understood'	,'понимать' , 'постигать'							),
(7,2,28, 'wake',        'woke'	    , 'woken'	    ,'просыпаться' , 'будить'							),
(7,2,28, 'wear',        'wore'	    , 'worn'	    ,'носить (одежду)', null								),
(7,2,28, 'win',         'won'	    , 'won'	        ,'победить' , 'выиграть'							),
(7,2,28, 'write',      'wrote'	    , 'written'	    ,'писать' , 'записывать'                   		);
go


insert verb
(numberPart, numberKind, Infinitive,translete,Sinonim,IDTYPE)
values
(7,3,'take place' , 'случаться',      'происходить, иметь место',                                          29)
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

