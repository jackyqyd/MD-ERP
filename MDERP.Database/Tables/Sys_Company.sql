CREATE TABLE [dbo].[Sys_Company]
(
	[C_Id] NVARCHAR(32) NOT NULL, 
    [C_Name] NVARCHAR(200) NOT NULL, 
    [C_Description] NVARCHAR(200) NOT NULL, 
    [C_ParentId] NVARCHAR(32) NOT NULL, 
    [C_IsSubCompany] INT NOT NULL, 
    [C_CompanyIcon] NVARCHAR(200) NOT NULL, 
    [C_CreateTime] DATETIME NOT NULL, 
    [C_IsDel] INT NOT NULL
)
