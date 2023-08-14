CRUD simples em blazor Server/C#.Net

-> Cria a migration
dotnet ef migrations add InitialMigration

-> Atualiza o banco de dados com a migration
dotnet ef database update

para rodar o app rode no terminal em HospitalCrud\HospitalCrud -> dotnet ef database update

Em caso de erro no update migration:

"ConnectionStrings": {
    "DefaultConnection": "Data Source=SEU-COMPUTADOR-NOME\\SQLEXPRESS;Initial Catalog=MyHospitalDB;Integrated Security=True;TrustServerCertificate=True"
},

#Definir como projeto de inicialização HospitalCrud..
