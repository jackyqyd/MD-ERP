ALTER TABLE [dbo].[Sys_EmployeeInfo]  WITH NOCHECK ADD  CONSTRAINT [FK_SysEmployeeInfo-Country_SysAreaInfo] FOREIGN KEY([E_Country])
REFERENCES [dbo].[Sys_AreaInfo] ([A_Id])
GO
ALTER TABLE [dbo].[Sys_EmployeeInfo] CHECK CONSTRAINT [FK_SysEmployeeInfo-Country_SysAreaInfo]
GO