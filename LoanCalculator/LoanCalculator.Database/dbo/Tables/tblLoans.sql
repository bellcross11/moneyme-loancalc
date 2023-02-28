CREATE TABLE [dbo].[tblLoans]
(
	[LoanId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [CustomerId] INT NOT NULL, 
    [TotalMonthTerms] INT NOT NULL , 
    [RepaymentFrom] DECIMAL(18, 2) NOT NULL , 
    [InterestTotal] DECIMAL(18, 2) NOT NULL , 
    [RepaymentTotal] DECIMAL(18, 2) NOT NULL 
)
