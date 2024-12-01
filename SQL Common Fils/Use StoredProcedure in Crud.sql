use Ajay2024

create table ProductData(
	Id int primary key,
	Name varchar(10),
	Rating int
)

insert into ProductData values(1,'Tv',4),(2,'Mobile',5)

create proc Temp2024
as 
begin
	select * from ProductData
end

execute Temp2024

create proc TempData(@id int)
as 
begin
	select * from ProductData
end

execute TempData 10


alter proc TempData(@id int)
as 
begin
	select * from ProductData where Id = @id
end

execute TempData 2



alter proc TempData(@id int)
as 
begin
	update ProductData set Name ='Laptop' where Id=2 
	select * from ProductData
end


execute TempData 2


use MVCDB

select * from Product
insert into Product  values ('TV',200) ,('Mobile',4000)

create proc UspgetProc
@Search varchar(100) = null
as
begin
	select Id, Name, Price from Product where Name like '%'+@Search+'%' or
	@Search is null
end

drop proc UspgetProc



-- Use Stored Procedure for create

create proc uspCreateCategory
@Name varchar(50), @Price int, @Id int output, @Status bit output
as
begin
	begin try
		begin transaction
			if not exists (select Name from Product where Name = @Name)
				begin
					insert into Product values (@Name, @Price)
					set @Status = 1
					set @Id = SCOPE_IDENTITY()
				end
			else
				begin
					set @Status = 0
					set @Id = -1
				end
		commit
	end try
	begin catch
		rollback
		set @Status = 0
		set @Id = -1
	end catch
end


select * from Product



-- Update


create proc uspUpdateProduct
@Id int, @Name varchar(50), @Price int, @Status bit output
as
begin
	begin try
		begin transaction
			if exists (select Id from Product where Id = @Id)
				begin
					update Product set Name = @Name, Price = @Price where Id = @Id
					set @Status = 1
				end
			else
				begin
					set @Status = 0
				end
		commit
	end try
	begin catch
		rollback
		set @Status = 0
	end catch
end

go


-- delete


create proc uspDeleteProduct
@Id int, @Status bit output
as
begin
	begin try
		begin transaction
			if exists (select Id from Product where Id = @Id)
				begin
					delete from Product where Id = @Id
					set @Status = 1
				end
			else
				begin
					set @Status = 0
				end
		commit
	end try
	begin catch
		rollback
		set @Status = 0
	end catch
end



-- clickable product


create table subProductId(Id int primary key identity,Name varchar(20),Price int)

insert into Product Values('Laptop',5000),('TV',2000),('Grocerry',7000),('Furniture',1000)
alter table Product add subProductId int foreign key references Product(Id) 

select * from subProductId
update subProductId set Name = 'Shirt' where Name = 'Furniture'

insert into subProductId values 
('shirt 1', 599), ('shirt 2', 299), ('kids shirt 1', 599)

select * from Product

update subProductId set subProductId = 4 where Id in (2,3)



