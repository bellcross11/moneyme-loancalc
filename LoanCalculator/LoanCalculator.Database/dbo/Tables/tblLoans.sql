CREATE TABLE [dbo].[tblLoans]
(
	[LoanId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [CustomerId] INT NOT NULL, 
    [ProductId] INT NOT NULL DEFAULT 0,
    [TotalMonthTerms] INT NOT NULL DEFAULT 0,
    [PrincipalAmount] DECIMAL(18, 2) NOT NULL DEFAULT 0, 
    [MonthlyRepayment] DECIMAL(18, 2) NOT NULL DEFAULT 0, 
    [TotalInterest] DECIMAL(18, 2) NOT NULL DEFAULT 0, 
    [TotalRepayment] DECIMAL(18, 2) NOT NULL DEFAULT 0,
    [GeneratedLink] UNIQUEIDENTIFIER NOT NULL
)
