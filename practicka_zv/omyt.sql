create database �������_�����_����
create table ������������
(
Id int primary key,
������� nvarchar(50) not null,
��� nvarchar(50) not null,
������� nvarchar(50) not null,
�����_�������� nvarchar(50) not null,
����� nvarchar(100) not null,
�������� nvarchar(50)
)
create table ������
(
ProductId int primary key,
��������_������ nvarchar(50) not null,
����_������ decimal not null,
����������_������ int not null
)
create table �������
(
Id int,
ProductId int,
���������� int not null
primary key(Id,ProductId)
)


