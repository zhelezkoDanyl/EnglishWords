use Engl
go

create table PartsOfSpeech
(Id int identity not null primary key,
  PartOfSpeech varchar(20)
)
go 

 --drop  table PartsOfSpeech
-- Записываем части речи
 --DELETE PartsOfSpeech
 --WHERE Id > 8;  
 --

insert PartsOfSpeech
values
('Noun'),
('Adjective'),
('Adverb'),
('Pronoun'),
('Preposition'),
('Conjunction'),
('Verb'),
('Numeral')
go

select * from PartsOfSpeech

create table TypesOfFunctions
(Id int identity not null,
  PartiD INT NOT NULL,
  IDofID INT NOT NULL,
  TypeOf Varchar(20)

)
go 

--drop table TypesOfFunctions

alter table TypesOfFunctions
Add constraint Fk_TypePartId
foreign key (PartiD) REFERENCES PartsOfSpeech(Id),
UNIQUE (PartiD, IDofID) 

alter table TypesOfFunctions
Add constraint FIrstKeyId
PRIMARY KEY (id)

ALTER TABLE TypesOfFunctions
DROP CONSTRAINT FIrstKeyId
GO

insert TypesOfFunctions
values
      (1,1, 'Абстрактные'),
      (1,2,   'Конкретные'),
      (1,3,  'Другое'),
      (2,1, 'Другое'),
      (3,1,  'Место'),
      (3,2,'Время'),
      (3,3,'Причина'),
      (3,4,  'Цель'),
      (3,5,  'Способ'),
      (3,6, 'Количество'),
      (3,7, 'Другое'),
	  (4,1, 'Личные'),
      (4,2, 'Притяжательные'),
      (4,3, 'Возвратные'),
      (4,4, 'Указательные'),
      (4,5, 'Вопросительные'),
     
      (4,7, 'Другое'),
	  (5,1, 'Абстрактные'),
      (5,2, 'Место'),
      (5,3, 'Время'),
      (5,4, 'Другое'),
	  (6,1, 'Связные'),
      (6,2, 'Разделительные'),
      (6,3, 'Контраст'),
      (6,4, 'ПричинноСледстинные'),
      (6,5, 'Другое'),
	  (7,1, 'Правильные'),
      (7,2, 'Неправильные'),
      (7,3, 'Фразовые'),
      (7,4, 'Другое'),
	  (8,1, 'Парядковые'),
      (8,2, 'Количественные'),
      (8,3, 'Другое')
	go

	select * from PartsOfSpeech
	select * from TypesOfFunctions
	select * from Topic

	select t.Id,  p.PartOfSpeech, p.Id, t.IDofID, t.TypeOf from PartsOfSpeech as p
	join TypesOfFunctions  as t
	on t.PartiD = p.Id
	
	


	create table Topic
	(id int identity not null
	primary key,
	topics varchar (20)
	)

	insert Topic
	values
	    ( 'None'),
        ('General'),
        ('Business'), 
        ('Technical'),
        ('Sea')
		go