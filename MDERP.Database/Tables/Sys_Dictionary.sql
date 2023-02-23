CREATE TABLE [dbo].[Sys_Dictionary]
(
	[D_Id] BIGINT NOT NULL IDENTITY(1,1), 
    [D_Name] NVARCHAR(50) NOT NULL, 
    [D_Type] NVARCHAR(50) NOT NULL, 
    [D_IsDel] BIT NOT NULL
)
