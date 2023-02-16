create database магазин_тихий_омут
create table Пользователи
(
Id int primary key,
Фамилия nvarchar(50) not null,
Имя nvarchar(50) not null,
Никнейм nvarchar(50) not null,
Номер_телефона nvarchar(50) not null,
Адрес nvarchar(100) not null,
Отчество nvarchar(50)
)
create table Товары
(
ProductId int primary key,
Название_товара nvarchar(50) not null,
Цена_товара decimal not null,
Количество_товара int not null
)
create table Корзина
(
Id int,
ProductId int,
Количество int not null
primary key(Id,ProductId)
)


