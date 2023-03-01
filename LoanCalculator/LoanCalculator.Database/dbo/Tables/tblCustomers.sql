CREATE TABLE [dbo].[tblCustomers]
(
	[CustomerId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Title] NVARCHAR(10) NULL, 
    [FirstName] NVARCHAR(50) NOT NULL, 
    [LastName] NVARCHAR(50) NOT NULL, 
    [DateOfBirth] DATETIME NOT NULL, 
    [Mobile] NVARCHAR(13) NULL, 
    [Email] NVARCHAR(80) NULL
)
