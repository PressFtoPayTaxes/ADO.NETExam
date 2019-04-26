create table Countries
(
	Id uniqueidentifier not null primary key,
	Name nvarchar(50) not null,
	Population int not null,
	CreationDate datetime not null,
	DeletedDate datetime
)

go

create table Cities
(
	Id uniqueidentifier not null primary key,
	Name nvarchar(50) not null,
	Population int not null,
	CountryId uniqueidentifier not null foreign key references Countries(Id),
	CreationDate datetime not null,
	DeletedDate datetime
)

go

create table Streets
(
	Id uniqueidentifier not null primary key,
	Name nvarchar(50) not null,
	CityId uniqueidentifier not null foreign key references Cities(Id),
	CreationDate datetime not null,
	DeletedDate datetime
)