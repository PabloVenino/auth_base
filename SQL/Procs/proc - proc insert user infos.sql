alter procedure proc_insert_user_infos
		@fullname nvarchar(64),
		@email nvarchar(64),
		@phone nvarchar(16),
		@cpf nvarchar(16),
		@rg nvarchar(16),
		@birthdate datetime

/*

	exec proc_insert_user_infos
		@fullname = 'Pablo VEnino',
		@email = 'pablo@venino.com',
		@phone = '5512996830952',
		@cpf = '12345678900',
		@rg = '123456789',
		@birthdate = '2000-09-10 00:00:00.000'

*/

as
begin

	insert into user_infos 
	(
		fullname,
		email,
		phone,
		cpf,
		rg,
		birthdate,
		created_at,
		update_at
	)
	OUTPUT Inserted.ID
	values 
	(
		@fullname,
		@email,
		@phone,
		@cpf,
		@rg,
		@birthdate,
		GETUTCDATE(),
		GETUTCDATE()
	)

end