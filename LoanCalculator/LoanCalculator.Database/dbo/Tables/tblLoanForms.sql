CREATE TABLE [dbo].[tblLoanForms]
(
	[LoanFormId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Title] NVARCHAR(10) NULL, 
    [FirstName] NVARCHAR(50) NOT NULL, 
    [LastName] NVARCHAR(50) NOT NULL, 
    [DateOfBirth] DATETIME NOT NULL, 
    [Mobile] NVARCHAR(13) NULL, 
    [Email] NVARCHAR(80) NULL, 
    [GeneratedLink] NVARCHAR(100) NOT NULL,
    [ProductId] INT NOT NULL DEFAULT 0,
    [EstablishmentFee] DECIMAL(18, 2) NOT NULL DEFAULT 0,
    [TotalMonthTerms] INT NOT NULL DEFAULT 0,
    [PrincipalAmount] DECIMAL(18, 2) NOT NULL DEFAULT 0, 
    [MonthlyRepayment] DECIMAL(18, 2) NOT NULL DEFAULT 0, 
    [TotalRepayment] DECIMAL(18, 2) NOT NULL DEFAULT 0,
    [TotalInterest] DECIMAL(18, 2) NOT NULL DEFAULT 0
)
