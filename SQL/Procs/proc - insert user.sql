alter procedure proc_insert_normal_user_with_credentials
	@user_login nvarchar(32),
	@password nvarchar(64),

	@fullname nvarchar(64),
	@email nvarchar(64),
	@phone nvarchar(16),
	@cpf nvarchar(16),
	@rg nvarchar(16),
	@birthdate datetime

/*

	exec proc_insert_normal_user_with_credentials
		@user_login = 'pablovenino3',
		@password = '123',

		@fullname = 'Pablo Venino3',
		@email = 'teste@teste.com3',
		@phone = '123123123',
		@cpf = '123123',
		@rg = '1231423',
		@birthdate = '2000-10-09 00:15:00.000'

*/

as
begin
	
	declare @user_credential_id uniqueidentifier;
    declare @user_infos_id int;

    -- Insert user credentials and capture the generated identity value
    exec proc_insert_user_credentials
        @user_login = @user_login,
        @password = @password,
        @user_credential_id = @user_credential_id OUTPUT;


	exec proc_insert_user_infos
		@fullname = @fullname,
		@email = @email,
		@phone = @phone,
		@cpf = @cpf,
		@rg = @rg,
		@birthdate = @birthdate,
		@user_infos_id = @user_infos_id output


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
		@user_credential_id,
		@user_infos_id,
		GETUTCDATE(),
		null
	)
end
