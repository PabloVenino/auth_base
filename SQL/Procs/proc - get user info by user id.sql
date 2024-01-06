create procedure proc_get_user_by_id
	@id integer not null

as
begin
	
	select 
		ui.fullname,
		ui.email,
		ui.phone,
		ui.cpf,
		ui.rg,
		ui.birthdate,
		ui.created_at as registered_at
	from users u
	inner join user_infos ui on u.user_infos_id = ui.id
	where u.id = @id

end