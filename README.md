<h2>Innova .Net Core Patika Bootcamp Bitirme projesi.</h2>



Proje ilk açıldığında  app-migration ile update-database uygulanacağı sırada varsayılan proje SiteManagementApi olmalı, normal çalışma zamanında ise SiteManagementApi, PaymentApi ve SiteManagement Api başlangıç projesi olarak seçili olmalı. 

İlk kullanımda Admin ve User oluşturmak için GET "https://localhost:6001/Api/Users/Seed" requesti çalıştırılmalı.
Ödeme sistemi(PaymentApi) online sunucudaki MongoDb veritabanına bağlı olduğu için işlem yapılmadan kullanılabilir.

Frontend bilgim yeterli olmadığı için arayüzde validation uygulamadım ve yanlış değerlerde uygulama çıktı vermek yerine hata veriyor bu sorun Swagger ve Postmande oluşmuyor.
<br><br>
Seed ile üretilen kullanıcılar:

|Kullanıcı adı:  | Şifre:       |
|----------------|--------------|
|Admin           | 123546       |
|----------------|--------------|
|User            | 123546       |
|----------------|--------------|

Proje .Net Core ile; Entity Framework Code First yaklaşımı kullanılarak geliştirildi.
<h3>Kullanılan Kütüphaneler:</h3>
AutoMapper
FluentValidation
Microsoft.AspNetCore.Authentication
Microsoft.EntityFrameworkCore
Microsoft.EntityFrameworkCore.SqlServer
Microsoft.Extensions.Identity.
MongoDB.Driver
Newtonsoft.Json


Tc 11 haneli, telefon 10 haneli olmalı, Şifre 6 karakter yada daha uzun olmalı, ay 0 ile 12 arasında yıl ise en fazla 9999 omalıdır.

<h3>Requestler:</h3>

<h4>Site Management Api:</h4>
<h4>Apartment<h4>

GET ​/Api​/Apartments​/GetAllApartment 

GET ​/Api​/Apartments​/GetApartmentBy​/{id}

GET ​/Api​/Apartments​/GetApartmentBy​/{block}​/{floor}​/{no}

POST ​/Api​/Apartments​/AddApartment

PUT ​/Api​/Apartments​/ChangeApartmentBy​/{id}

DELETE 
​/Api​/Apartments​/DeleteApartmentBy​/{block}​/{floor}​/{no}

Debt

GET ​/Api​/Debts​/GetAllDebt​/{paidCheck}

GET ​/Api​/Debts​/GetDebtBy​/{id}

GET ​/Api​/Debts​/GetDebtByUser​/{id}​/{paidCheck}

GET ​/Api​/Debts​/GetDebtBy​/{debtMonth}​/{debtYear}​/{paidCheck}

GET ​/Api​/Debts​/GetDebtByUser​/{id}​/With​/{debthMonth}​/{debtYear}​/{paidCheck}

POST ​/Api​/Debts​/AddDebt

POST ​/Api​/Debts​/AddDebtToAll

PUT ​/Api​/Debts​/ChangeDebtBy​/{id}

PUT ​/Api​/Debts​/PayDebtBy​/{id}

DELETE ​/Api​/Debts​/DeleteDebtBy​/{id}

Message

GET ​/Api​/Messages​/GetAllMessage

GET ​/Api​/Messages​/GetMessageBy​/{id}

GET ​/Api​/Messages​/GetMessageByReciver​/{id}

GET ​/Api​/Messages​/GetMessageBySender​/{senderId}​/AndReciver​/{reciverid}

GET ​/Api​/Messages​/GetMessageBySender​/{id}

POST ​/Api​/Messages​/AddMessage

PUT ​/Api​/Messages​/ChangeMessagenBy​/{id}

PUT ​/Api​/Messages​/ReadMessage​/{id}

DELETE ​/Api​/Messages​/DeleteMessageBy​/{id}

PayDebt

GET ​/Api​/PayDebts​/PayDebt

GET ​/Api​/PayDebts​/PayDebtBy​/{id}​/{cardNumber}​/{exYear}​/{exMonth}​/{ccv}

User

GET ​/Api​/Users​/LoginUser​/{userName}​/{password}

GET ​/Api​/Users​/Seed

GET ​/Api​/Users​/GetAllUser

GET ​/Api​/Users​/GetUserBy​/{id}

GET ​/Api​/Users​/GetUserByTc​/{tc}

GET ​/Api​/Users​/GetUserByName​/{name}

POST ​/Api​/Users​/AddUser

PUT ​/Api​/Users​/ChangeUserBy​/{id}

DELETE ​/Api​/Users​/DeleteUserBy​/{id}
