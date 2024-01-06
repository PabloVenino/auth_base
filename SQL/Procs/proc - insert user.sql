create procedure proc_insert_normal_user_with_credentials
	@user_login nvarchar(32),
	@password nvarchar(64),

	@fullname nvarchar(64),
	@email nvarchar(64),
	@phone nvarchar(16),
	@cpf nvarchar(16),
	@rg nvarchar(16),
	@birthdate datetime

as
begin
	
	--declare @id uniqueidentifier;
	
	exec proc_insert_user_credentials
		@user_login = @user_login,
		@password = @password,
		@user_credential_id = null;


	exec proc_insert_user_infos
		@fullname = @fullname,
		@email = @email,
		@phone = @phone,
		@cpf = @cpf,
		@rg = @rg,
		@birthdate = @birthdate

	insert into users 
	(
		id,
		user_credential_id,
		user_infos_id,
		created_at,
		update_at	
	)
	values 
	(
		newid(),
		,
		,
		GETUTCDATE(),
		null
	)
end
