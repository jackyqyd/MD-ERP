CREATE TABLE [dbo].[Sys_Department]
(
	[D_DeptId] BIGINT NOT NULL IDENTITY(1,1), 
    [D_DeptNo] NVARCHAR(50) NOT NULL, 
    [D_DeptName] NVARCHAR(50) NOT NULL, 
    [D_Remark] NVARCHAR(50) NOT NULL, 
    [D_CompanyId] BIGINT NOT NULL, 
    [D_CreateDate] DATETIME NOT NULL, 
    [D_IsEnabled] BIT NOT NULL, 
    [D_IsDel] BIT NOT NULL
)
