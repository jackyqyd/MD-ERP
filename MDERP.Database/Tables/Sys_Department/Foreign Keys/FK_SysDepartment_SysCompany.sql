ALTER TABLE [dbo].[Sys_Department]  WITH NOCHECK ADD  CONSTRAINT [FK_SysDepartment_SysCompany] FOREIGN KEY([D_CompanyId])
REFERENCES [dbo].[Sys_Company] ([C_Id])
GO
ALTER TABLE [dbo].[Sys_Department] CHECK CONSTRAINT [FK_SysDepartment_SysCompany]
GO

