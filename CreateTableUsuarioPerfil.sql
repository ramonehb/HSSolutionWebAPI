Create DataBase HSSolutionDB;

Go

Create Table Perfil 
(
	ID_Perfil Int Primary Key Identity,
	NM_Descricao Varchar(150)
)

Go

Create Table Usuario 
(
	ID_Usuario			Int Primary Key Identity
   ,ID_Perfil			Int Constraint FK_Perfil_Usuario Foreign Key References Perfil(ID_Perfil)
   ,Nome				Varchar(100) Not Null
   ,CPF					Varchar(14)  Not Null
   ,Email				Varchar(100) Not Null
   ,Telefone			Varchar(13)
   ,Login				Varchar(30)  Not Null
   ,Senha				Varchar(64)
   ,FL_Habilitado		Bit
   ,DT_Nascimento		DateTime
   ,NR_UltimoAcesso		Int
   ,DT_UltimoAcesso		DateTime
   ,DT_Cadastro			DateTime
   ,DT_Expiracao		DateTime
   ,NR_Tentativa		Int
   ,DT_UltimaTentativa	DateTime

   ,Index IX_Usuario_001 (ID_Perfil)
)
