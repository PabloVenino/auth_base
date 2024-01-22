CREATE TABLE [users] (
  [id] uniqueidentifier PRIMARY KEY,
  [user_credential_id] uniqueidentifier,
  [user_infos_id] integer,
  [created_at] datetime,
  [update_at] datetime
)
GO

CREATE TABLE [user_credentials] (
  [id] uniqueidentifier primary key,
  [user_login] nvarchar(32),
  [password] nvarchar(64),
  [created_at] datetime,
  [update_at] datetime
)
GO

CREATE UNIQUE INDEX user_unique_login
ON user_credentials (user_login);

CREATE TABLE [user_infos] (
  [id] integer PRIMARY KEY identity(1, 1),
  [fullname] nvarchar(64),
  [email] nvarchar(64),
  [phone] nvarchar(16),
  [cpf] nvarchar(16),
  [rg] nvarchar(16),
  [birthdate] date,
  [created_at] datetime,
  [update_at] datetime
)
GO

CREATE UNIQUE INDEX user_unique_data
ON user_infos (email, cpf, rg);

CREATE TABLE [roles] (
  [role] nvarchar(20) PRIMARY KEY
)
GO

CREATE TABLE [user_roles] (
  [id] integer PRIMARY KEY identity(1, 1),
  [user_id] uniqueidentifier,
  [role] nvarchar(20),
  [created_at] datetime
)
GO

ALTER TABLE [users] ADD FOREIGN KEY ([user_credential_id]) REFERENCES [user_credentials] ([id])
GO

ALTER TABLE [users] ADD FOREIGN KEY ([user_infos_id]) REFERENCES [user_infos] ([id])
GO

ALTER TABLE [user_roles] ADD FOREIGN KEY ([user_id]) REFERENCES [users] ([id])
GO

ALTER TABLE [user_roles] ADD FOREIGN KEY ([role]) REFERENCES [roles] ([role])
GO


-- insert roles padroes
INSERT INTO dbo.roles
VALUES ('ADMIN'), ('ADMINMASTER'), ('USER'), ('VIEWER')

/* 
	insert 1° usuario admin
	na ordem: suas credenciais, suas informacoes, o usuario e por ultimo sua role
*/
INSERT INTO user_credentials 
(
	id,
	user_login,
	[password],
	created_at,
	update_at
)
values 
(
	NEWID(),
	'ADMIN',
	'123',
	GETUTCDATE(),
	NULL
)

INSERT INTO user_infos 
(
	fullname,
	email,
	phone,
	cpf,
	rg,
	birthdate,
	created_at,
	update_at
) values 
(
	'ADMINISTRADOR SISTEMA',
	'admin@aguiatech.com.br',
	'5512996830950',
	'4X9XXXXXXX0',
	'5XXXX6XX6',
	GETUTCDATE(),
	GETUTCDATE(),
	NULL
)

INSERT INTO users 
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
	(select top 1 id from user_credentials order by id asc),
	(select top 1 id from user_infos order by id asc),
	GETUTCDATE(),
	null
)

insert into user_roles
(
	[user_id],
	[role],
	created_at
)
values 
(
	(select top 1 id from users order by id asc),
	(select top 1 [role] from roles where [role] = 'ADMINMASTER'),
	GETUTCDATE()	
)