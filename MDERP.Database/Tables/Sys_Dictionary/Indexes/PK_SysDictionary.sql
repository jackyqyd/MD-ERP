﻿ALTER TABLE [dbo].[Sys_Dictionary] ADD  CONSTRAINT [PK_SysDictionary] PRIMARY KEY CLUSTERED 
(
	[D_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 95) ON [PRIMARY]
GO