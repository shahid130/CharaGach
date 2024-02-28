CREATE DATABASE CharaGach

USE CharaGach
drop table userInfo

create table userInfo
(
userID int PRIMARY KEY Identity(1,1),
userName varchar(25),
userEmail varchar(30) unique,
userNumber varchar(25) null,
userAdress varchar(30) null,
userPassword varchar(25) check(len(userPassword)>5),
constraint userEmail check(userEmail like '%_@__%.__%'),
)

select * from userInfo


drop table adminInfo
create table adminInfo
(
adminID int PRIMARY KEY Identity(1,1),
adminName varchar(25),
adminNumber varchar(15) unique,
adminEmail varchar(30) unique,
adminPassword varchar(25) check(len(adminPassword)>5),
constraint adminEmail check(adminEmail like '%_@__%.__%'),
)

insert into adminInfo(adminName,adminNumber,adminEmail, adminPassword)
values('Shahid', '01521252236', 'shahidhasan@gmail.com', '12345678')

select * from adminInfo

drop table plants
create table plants
(
plantID int PRIMARY KEY Identity(1,1),
plantName varchar(25),
plantDetails varchar(200) null,
plantType varchar(25) null,
plantPrice decimal(10,2) null,
plantQuantity int null,
plantSize varchar(25) null,
plantImagePath varchar(200) null,
)
select * from plants

drop table orders
create table orders
(
orderID int PRIMARY KEY Identity(1,1),
userID int,
plantID int,
plantAmount int,
)
select * from orders

drop table cart
create table cart
(
cartID int PRIMARY KEY Identity(1,1),
userID int FOREIGN KEY REFERENCES userInfo(userID) ,
plantID int FOREIGN KEY REFERENCES plants(plantID) unique,
plantAmount int ,
)
select * from cart

