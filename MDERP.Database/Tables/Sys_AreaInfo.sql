﻿CREATE TABLE [dbo].[Sys_AreaInfo]
(
	[A_Id] NVARCHAR(32) NOT NULL, 
    [A_ParentId] NVARCHAR(32) NOT NULL, 
    [A_Path] NVARCHAR(10) NOT NULL, 
    [A_Level] INT NOT NULL, 
    [A_CnName] NVARCHAR(50) NOT NULL, 
    [A_EnName] NVARCHAR(50) NOT NULL, 
    [A_PY] NVARCHAR(50) NOT NULL, 
    [A_Code] NVARCHAR(50) NOT NULL
)
