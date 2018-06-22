use Engl
go

create table PartsOfSpeech
(Id int identity not null primary key,
  PartOfSpeech varchar(20)
)
go 

 --drop  table PartsOfSpeech
-- ���������� ����� ����
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
      (1,1, '�����������'),
      (1,2,   '����������'),
      (1,3,  '������'),
      (2,1, '������'),
      (3,1,  '�����'),
      (3,2,'�����'),
      (3,3,'�������'),
      (3,4,  '����'),
      (3,5,  '������'),
      (3,6, '����������'),
      (3,7, '������'),
	  (4,1, '������'),
      (4,2, '��������������'),
      (4,3, '����������'),
      (4,4, '������������'),
      (4,5, '��������������'),
     
      (4,7, '������'),
	  (5,1, '�����������'),
      (5,2, '�����'),
      (5,3, '�����'),
      (5,4, '������'),
	  (6,1, '�������'),
      (6,2, '��������������'),
      (6,3, '��������'),
      (6,4, '�������������������'),
      (6,5, '������'),
	  (7,1, '����������'),
      (7,2, '������������'),
      (7,3, '��������'),
      (7,4, '������'),
	  (8,1, '����������'),
      (8,2, '��������������'),
      (8,3, '������')
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