Migraciones  para vscode
DEntro de CleanArchitectureTemplate.Infrastructure 

Estas migraciones ya se habian hecho en un entorno distinto con visualstudio 2026, con su BBDD distinta, al
abrir el proyecto en otro entorno distinto vscode y mssql en container se tiene que hacer las migraciones, pero
como se descargaron de github ya solo hacemos los database update

La primera vez se hizo la migracion inicial
dotnet ef database update CreateIdentitySchema   --startup-project ../CleanArchitectureTemplate.PresentationWeb

cuando se añadio la clase producto se 
dotnet ef database update add-product-entitie   --startup-project ../CleanArchitectureTemplate.PresentationWeb