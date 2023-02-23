CREATE TABLE [dbo].[Sys_Company]
(
	[C_Id] BIGINT NOT NULL IDENTITY(1,1), 
    [C_Name] NVARCHAR(200) NOT NULL, 
    [C_Description] NVARCHAR(200) NOT NULL, 
    [C_ParentId] BIGINT NOT NULL, 
    [C_IsSubCompany] BIT NOT NULL, 
    [C_CompanyIcon] NVARCHAR(200) NOT NULL, 
    [C_CreateTime] DATETIME NOT NULL, 
    [C_IsDel] BIT NOT NULL
)
