USE [AuhBase]
GO
/****** Object:  StoredProcedure [dbo].[proc_insert_user_credentials]    Script Date: 05/01/2024 23:33:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[proc_insert_user_credentials]
	@user_login nvarchar(32),
	@password nvarchar(64),
	@user_credential_id uniqueidentifier out

/*
	EXEC [proc_insert_user_credentials]
		@user_login = 'pablo',
		@password = '123',
		@user_credential_id = null
*/

as
begin
	
	declare @id uniqueidentifier = (select newid());

	insert into user_credentials
	(
		id,
		user_login,
		[password],
		created_at,
		update_at
	)
	values 
	(
		@id,
		@user_login,
		@password,
		GETUTCDATE(),
		null
	)

	set @user_credential_id = @id;

end