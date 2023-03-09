CREATE TABLE [dbo].[Sys_Department]
(
	[D_DeptId] NVARCHAR(32) NOT NULL, 
    [D_DeptNo] NVARCHAR(50) NOT NULL, 
    [D_DeptName] NVARCHAR(50) NOT NULL, 
    [D_Remark] NVARCHAR(50) NOT NULL, 
    [D_CompanyId] NVARCHAR(32) NOT NULL, 
    [D_CreateDate] DATETIME NOT NULL, 
    [D_IsEnabled] INT NOT NULL, 
    [D_IsDel] INT NOT NULL
)
