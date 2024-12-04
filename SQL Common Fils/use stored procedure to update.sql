use mvcdb

create proc uspGetProduct
@ProductId int
as
begin
	select * from SubProduct  where Product_Id=@ProductId
end