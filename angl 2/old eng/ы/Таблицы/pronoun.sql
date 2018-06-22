
use Engl
go

drop table Pronoun

	create table Pronoun
(Id int identity not null,
Infinitive varchar(20),
translete varchar(30),
Sinonim varchar(100),
IDTYPE int Not null,
numberPart int not null,
numberKind int not null
)
go 

alter table Pronoun
add constraint fk_p_type
foreign key (id) REFERENCES TypesOfFunctions(Id),

alter table Pronoun
add constraint Unik_word_Pronoun
Unique (Infinitive,translete)
   


insert Pronoun

   Values
     ('I'	        ,'Я'	        , null   ,12,4,1 ),
     ('You'	        ,'вы'			, null   ,12,4,1 ),
     ('We'	        ,'Мы'			, null   ,12,4,1 ),
     ('They'        ,'Они'	    	, null   ,12,4,1 ),
     ('He'	        ,'Он'			, null   ,12,4,1 ),
     ('She'	        ,'Она'			, null   ,12,4,1 ),
     ('It'	        ,'оно'			, null   ,12,4,1 ),
	  											
	  		       								
     ('me'	        ,'меня'       ,'мне'	 ,12,4,1 ),
     ('you'	        ,'вас'         ,'вам'	 ,12,4,1 ),    
     ('us'	        ,'нас'        ,'нас'	 ,12,4,1 ),    
     ('them'        ,'их'          ,'им'	 ,12,4,1 ),    	
     ('him'	        ,'его'         ,'ему' 	 ,12,4,1 ),
     ('her'	        ,'ей'          ,'её'     ,12,4,1 ),
     ('it'	        ,'его'         ,'Это' 	 ,12,4,1 ),
											


     ('my' 	        ,'мой'         ,null	,13,4,2  ),
     ('your'         ,'твой'	   ,null	,13,4,2  ),
     ('our'	        ,'наше'		   ,null	,13,4,2  ),
     ('their'        ,'их'	   	   ,null	,13,4,2  ),
     ('his'	        ,'его'	       ,null	,13,4,2  ),
     ('her'	        ,'её'	       ,null	,13,4,2  ),
     ('its'	        ,'его'         ,'Этого'	,13,4,2  ),
	

	 ('something',        'что-нибудь',  'что-то'        ,17,4,6 ),
     ('somebody ',        'кто-нибудь',  'кто-то'		 ,17,4,6 ),
     ('somewhere',        'где-нибудь',  'где-то'		 ,17,4,6 ),
	 ('anything',         'что-либо',    'всякое'		 ,17,4,6 ),
	 ('anybody',          'кто-либо',    'всякий'		 ,17,4,6 ),
     ('anywhere',         'где-нибудь',  'где угодно'	 ,17,4,6 ),
     ('nothing',          'ничего',	      null			 ,17,4,6 ),
	 ('nobody',           'никто',	      null			 ,17,4,6 ),
 	 ('nowhere',          'нигде',        null			 ,17,4,6 ),
     ('everything',       'всё',	      null 		     ,17,4,6 ),
	 ('everybody',        'все',         'каждый'		 ,17,4,6 ),
     ('everywhere',       'везде',       'всюду'		 ,17,4,6 ),


     ('myself',           'я сам',	     null           ,14,4,3  ),
     ('yourself',         'ты сам',	     null			,14,4,3  ),
     ('yourselves',       'вы сами',	 null			,14,4,3  ),
     ('ourselves',        'мы сами',	 null			,14,4,3  ),
     ('themselves',       'они сами',	 null			,14,4,3  ),
     ('himself',          'он сам',	     null			,14,4,3  ),
     ('herself',          'она сама',	 null			,14,4,3  ),
     ('itself',           'оно само',	 null			,14,4,3  ),


    ('for each other'       ,   'друг для друга',        null    ,17,4,6  ),
    ('whith each other'       ,   'друг c другом', 	    null	 ,17,4,6  ),
    ('whithout each other'       ,   'друг без друга', 	 null	 ,17,4,6  ),
    ('about each other' ,   'о друг друге', 	         null	 ,17,4,6  ),
					   	   						 

    ('this'             ,   'этот'	,			 null    ,15,4,4  ),
    ('that'             ,   'тот'	,			 null	 ,15,4,4  ),
    ('these'            ,   'эти',				 null	 ,15,4,4  ),
    ('those'            ,   'те'	,			 null	 ,15,4,4  ),


   ('Who',     'Кто',       null,     16,4,5),
   ('What',    'Что',      'Какой',	  16,4,5),
   ('Where',   'Где',       null,	  16,4,5),
   ('When',    'Когда',		null,	  16,4,5),
   ('Why',     'Почему',	null,	  16,4,5),
   ('How',     'Как',		null,	  16,4,5),
   ('whom',    'кого',     'кому',	  16,4,5),
   ('which',   'который',   null,	  16,4,5),
   ('whose',   'чей',      	null,	  16,4,5),

    ('many',      'много',        '(исчесляемое)',      17,4,6), 
    ('much',      'много',        '(неисчисляемое)',	17,4,6), 
    ('few',       'мало',		  '(исчесляемое)',		17,4,6), 
    ('little',    'немного',	  '(неисчисляемое)',	17,4,6), 
    ('several',   'несколько',	  'некоторые(several)',	17,4,6), 
	('some',      'некоторое',	  'несколько(Some)',	17,4,6)


	select * from	Pronoun