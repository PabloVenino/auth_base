USE [AuhBase]
GO
/****** Object:  StoredProcedure [dbo].[proc_insert_user_infos]    Script Date: 06/01/2024 00:20:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[proc_insert_user_infos]
		@fullname nvarchar(64),
		@email nvarchar(64),
		@phone nvarchar(16),
		@cpf nvarchar(16),
		@rg nvarchar(16),
		@birthdate datetime,
		@user_infos_id int output

/*
	exec proc_insert_user_infos
		@fullname = 'Pablo VEnino',
		@email = 'test@teste.com',
		@phone = '12221231212',
		@cpf = '1234112',
		@rg = '1231231',
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

	set @user_infos_id = scope_identity();

end