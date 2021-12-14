Create Table dbo.Student1
(
  Id int identity(1,1) primary key,
  FirstName nvarchar(50),
  LastName varchar(50),
  RollNo int,
  Marks decimal(10,2)
)
Insert Student1
(First_name, Last_name, Roll_number, Marks)
values ('Aheli','Ghosh', 1, 100.00)

select  top 10 * from Student1

Declare @i int=0, @length int,
@fn varchar(50),
@ln varchar (50),
@rollno int,
@marks decimal(10,2);

set @i=1;
set @length=5;

WHILE(@i<=5)
BEGIN

set @fn = null;
set @ln = null;
set @rollno = null; 
set @marks = null;

select @fn = First_name, @ln = Last_name, @rollnno = Roll_number, @marks = Marks from Student1 where ID =@i;

print 'Firstname-' + @fn
print concat('LastName-', @ln)
print @rollno
print 'Roll No -' +convert(varchar(20),@rollno)

set @i=@i+1;
END
GO

--stored procedure--
create procedure dbo.CreateStudent(
@firstname varchar (50),
@lastname varchar (50),
@rollno int,
@marks decimal(18,2))
as
begin

insert Student (FirstName,LastName,RollNo,Marks)
values(@firstname,@lastname,@rollno,@marks);
select SCOPE_IDENTITY() Id;
end