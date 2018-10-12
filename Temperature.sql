create table dbo.Temperature(
	Id int not null Identity(1,1),
	Temperature decimal(9,2) null,
	Humidity decimal(9,2)  null,
	Date Datetime null,
	constraint PK_dbo_Temperature primary key (Id)
);