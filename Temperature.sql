create table dbo.Temperature(
	Id int not null Identity(1,1),
	Temperature int null,
	Humidity int null,
	Date Datetime null,
	constraint PK_dbo_Temperature primary key (Id)
);