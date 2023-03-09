CREATE TABLE [dbo].[Sys_Menus]
(
	[M_MenuId] NVARCHAR(32) NOT NULL, 
    [M_MenuParentId] NVARCHAR(32) NOT NULL, 
    [M_MenuCode] NVARCHAR(50) NOT NULL, 
    [M_MenuName] NVARCHAR(50) NOT NULL, 
    [M_MenuRemark] NVARCHAR(50) NULL, 
    [M_MenuOrder] INT NOT NULL, 
    [M_CreateDate] DATETIME NOT NULL, 
    [M_IsEnabled] INT NOT NULL, 
    [M_IsDel] INT NOT NULL
)
