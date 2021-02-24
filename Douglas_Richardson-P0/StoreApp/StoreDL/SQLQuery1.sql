drop table batch;
drop table trainers;
drop table associates;

create table associates(
	id int identity primary key,
	associateName nvarchar(100) not null,
	associateLocation varchar(2) not null,
	revaPoints int not null
);
create table trainers(
	id int identity primary key,
	trainerName nvarchar(100) not null,
	campusLocation varchar(3) not null,
	caffeineLevle int not null
);
create table batch(
	id int identity primary key,
	associateID int references associates(id),
	trainerID int references trainers(id),
);