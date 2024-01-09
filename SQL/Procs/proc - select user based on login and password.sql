create procedure [dbo].[proc_get_user_log_in]
	@user_login nvarchar(32),
	@password nvarchar(64)

/*
	exec proc_get_user_log_in
		@user_login = 'pablovenino3',
		@password = '123'
*/

as
begin
	select 
		u.id
	from 
		dbo.[users] u
	inner join 
		user_credentials uc on uc.id = u.user_credential_id
	where 
		uc.user_login = @user_login
		and uc.password = @password
end