USE [AuhBase]
GO
/****** Object:  StoredProcedure [dbo].[proc_insert_user_credentials]    Script Date: 06/01/2024 00:20:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[proc_insert_user_credentials]
	@user_login nvarchar(32),
	@password nvarchar(64),
	@user_credential_id uniqueidentifier output

/*
	EXEC [proc_insert_user_credentials]
		@user_login = 'pablo3',
		@password = '123',

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