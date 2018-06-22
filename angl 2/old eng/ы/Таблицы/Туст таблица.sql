use Engl
go

drop table TestAllWords

	create table TestAllWords
(Id int identity not null,
Engword varchar(20) not null,
RuWord varchar(30)  not null,
SinonimRu varchar(100),
SinonimEn varchar(100),
PastSimple	varchar(20),
PastPart varchar(20),

numberPart int not null,
numberKind int not null
--DateInf date 

)
go 

alter table TestAllWords
add constraint Unik_word_TestAllWords
Unique (Engword,RuWord)


select * from Noun
select * from Verb
select * from Pronoun
select * from adjective
select * from adverb
select * from Preposition

select * from TestAllWords
order by numberPart, numberKind

insert TestAllWords
(Engword,RuWord,SinonimRu,PastSimple, PastPart,numberPart,numberKind)
select vr.Infinitive,vr.translete,vr.Sinonim,vr.PastSimple,vr.PastPart,vr.numberPart,vr.numberKind from Verb as vr

go

insert TestAllWords
(Engword,RuWord,SinonimRu,numberPart,numberKind)
select pr.Infinitive,pr.translete,pr.Sinonim,pr.numberPart,numberKind from Pronoun as pr

go

insert TestAllWords
(Engword,RuWord,SinonimRu,numberPart,numberKind)
select nn.Infinitive,nn.translete,nn.Sinonim,nn.numberPart,nn.numberKind from Noun as nn
go

insert TestAllWords
(Engword,RuWord,SinonimRu,numberPart,numberKind)
select nn.Infinitive,nn.translete,nn.Sinonim,nn.numberPart,nn.numberKind from adverb as nn
go


insert TestAllWords
(Engword,RuWord,SinonimRu,numberPart,numberKind)
select nn.Infinitive,nn.translete,nn.Sinonim,nn.numberPart,nn.numberKind from adjective as nn
go

insert TestAllWords
(Engword,RuWord,SinonimRu,numberPart,numberKind)
select nn.Infinitive,nn.translete,nn.Sinonim,nn.numberPart,nn.numberKind from Preposition as nn
go


