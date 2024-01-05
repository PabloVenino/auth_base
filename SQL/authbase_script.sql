CREATE TABLE [users] (
  [id] integer PRIMARY KEY,
  [user_credential_id] integer,
  [user_infos_id] integer,
  [created_at] datetime,
  [update_at] datetime
)
GO

CREATE TABLE [users_credentials] (
  [id] integer PRIMARY KEY,
  [user_login] nvarchar(32),
  [password] nvarchar(64),
  [created_at] datetime,
  [update_at] datetime
)
GO

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

CREATE TABLE [roles] (
  [role] nvarchar(20) PRIMARY KEY
)
GO

CREATE TABLE [user_roles] (
  [id] integer PRIMARY KEY,
  [user_id] integer,
  [role] nvarchar(20),
  [created_at] datetime
)
GO

ALTER TABLE [users] ADD FOREIGN KEY ([user_credential_id]) REFERENCES [users_credentials] ([id])
GO

ALTER TABLE [users] ADD FOREIGN KEY ([user_infos_id]) REFERENCES [user_infos] ([id])
GO

ALTER TABLE [user_roles] ADD FOREIGN KEY ([user_id]) REFERENCES [users] ([id])
GO

ALTER TABLE [user_roles] ADD FOREIGN KEY ([role]) REFERENCES [roles] ([role])
GO
