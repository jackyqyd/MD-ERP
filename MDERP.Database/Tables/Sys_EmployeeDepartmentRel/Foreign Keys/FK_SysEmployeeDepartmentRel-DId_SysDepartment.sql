ALTER TABLE [dbo].[Sys_EmployeeDepartmentRel]  WITH NOCHECK ADD  CONSTRAINT [FK_SysEmployeeDepartmentRel-DId_SysDepartment] FOREIGN KEY([D_DeptID])
REFERENCES [dbo].[Sys_Department] ([D_DeptId])
GO
ALTER TABLE [dbo].[Sys_EmployeeDepartmentRel] CHECK CONSTRAINT [FK_SysEmployeeDepartmentRel-DId_SysDepartment]
GO