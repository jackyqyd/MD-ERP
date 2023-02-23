CREATE TABLE [dbo].[Sys_Menus]
(
	[M_MenuId] BIGINT NOT NULL IDENTITY(1,1), 
    [M_MenuParentId] BIGINT NOT NULL, 
    [M_MenuCode] NVARCHAR(50) NOT NULL, 
    [M_MenuName] NVARCHAR(50) NOT NULL, 
    [M_MenuRemark] NVARCHAR(50) NULL, 
    [M_MenuOrder] INT NOT NULL, 
    [D_CreateDate] DATETIME NOT NULL, 
    [D_IsEnabled] BIT NOT NULL, 
    [D_IsDel] BIT NOT NULL
)
