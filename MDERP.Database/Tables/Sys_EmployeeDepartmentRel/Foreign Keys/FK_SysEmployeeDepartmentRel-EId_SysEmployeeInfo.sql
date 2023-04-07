ALTER TABLE [dbo].[Sys_EmployeeDepartmentRel]  WITH NOCHECK ADD  CONSTRAINT [FK_SysEmployeeDepartmentRel-EId_SysEmployeeInfo] FOREIGN KEY([E_Id])
REFERENCES [dbo].[Sys_EmployeeInfo] ([E_Id])
GO
ALTER TABLE [dbo].[Sys_EmployeeDepartmentRel] CHECK CONSTRAINT [FK_SysEmployeeDepartmentRel-EId_SysEmployeeInfo]
GO