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
<h4>Apartment</h4>

GET /Api/Apartments/GetAllApartment :(Admin) Girdi almadan bütün kayıtlı aprtmanları getirir.

GET /Api/Apartments/GetApartmentBy/{id} :(Admin) Apartmanlar tablosunun id değeri ile eşleşen apartmanın detaylarını getirir.

GET /Api/Apartments/GetApartmentBy/{block}/{floor}/{no} :(Admin) Adres bilgileri girilen apartmanın detaylarınını getirir.

POST /Api/Apartments/AddApartment :(Admin) Girilen bilgiler ile yeni bir apartman dairesi ekler.

PUT /Api/Apartments/ChangeApartmentBy/{id} :(Admin) Kayıtlıu bir apartmanı düzenlemek için kullanılır. Not: Daireye kullanıcı burada tanımlanır.

DELETE /Api/Apartments/DeleteApartmentBy/{block}/{floor}/{no} :(Admin) Id'si girilen bir daireyi siler.


<h4>Debt</h4>

GET /Api/Debts/GetAllDebt/{paidCheck} :(Admin) Bütün borçları döndürür, eğer paidCheck "true" ise ödenmemiş faturaları döndürür.

GET /Api/Debts/GetDebtBy/{id} :(Admin, User) Id'si girilen faturayı döndürür

GET /Api/Debts/GetDebtByUser/{id}/{paidCheck} :(Admin, User) Id'si girilen kullanıcının bütün faturalarını döndürür, eğer paidCheck "true" ise ödenmemiş faturaları döndürür.

GET /Api/Debts/GetDebtBy/{debtMonth}/{debtYear}/{paidCheck} :(Admin, User) Belirtilen dönemin bütün faturalarını getirir, eğer paidCheck "true" ise ödenmemiş faturaları döndürür.

GET /Api/Debts/GetDebtByUser/{id}/With/{debthMonth}/{debtYear}/{paidCheck} :(Admin, User) Bir kullanıcının belirtilen dönemdeki faturayı ödeyip ödemediğini kontrol eder. 

POST /Api/Debts/AddDebt :(Admin) Yöneticinin Aylık borç bilgilerini tek tek girmesini sağlar

POST /Api/Debts/AddDebtToAll :(Admin) Yöneticinin Aylık borç bilgilerini girmesini sağlar. Girilen tutar, dolu dairelerin sayısına bölünerek paylaştırılır.

PUT /Api/Debts/ChangeDebtBy/{id} :(Admin) Tek bir borç bilgisinin düzenlenmesini sağlar.

PUT /Api/Debts/PayDebtBy/{id} :(Admin, User) Girilen Id deki faturayıödenmiş işaretler. (Test amaçlı ve alt komutları normal ödeme yönteminde kullanılıyor)

DELETE /Api/Debts/DeleteDebtBy/{id} :(Admin) Kayıtlı bir faturayı siler.


<h4>Message</h4>

GET /Api/Messages/GetAllMessage :(Admin, User) Bütün mesajları listeler.

GET /Api/Messages/GetMessageBy/{id} :(Admin, User) Girilen Idye sahip  mesajı getirir

GET /Api/Messages/GetMessageByReciver/{id} :(Admin, User) Gelen mesajlarınızı görmek için

GET /Api/Messages/GetMessageBySender/{senderId}/AndReciver/{reciverid} :(Admin, User) Belirli bir kişi ile görüşmelerinizi filtrelemek için

GET /Api/Messages/GetMessageBySender/{id} :(Admin, User)  Giden mesajlarınızı görmek için

POST /Api/Messages/AddMessage :(Admin, User) Yeni bir mesaj göndermek için (Alıcının ve göndericinin Id'si manuel belirtilmeli, yetiştiremedim)

PUT /Api/Messages/ChangeMessagenBy/{id} :(Admin, User) Bir mesaj henüz okunmadı ise düzenleyebilmek için

PUT /Api/Messages/ReadMessage/{id} :(Admin, User) Mesajı okundu olarak işaretlemek için

DELETE /Api/Messages/DeleteMessageBy/{id} :(Admin, User) Mesajı silmek için


<h4>PayDebt</h4>

GET /Api/PayDebts/PayDebt :(Admin, User) Tc kimlik numarası girilen kullanıcının belirtilen dönem borcunu ödemek için ödeme APIsine bağlanır

GET /Api/PayDebts/PayDebtBy/{id}/{cardNumber}/{exYear}/{exMonth}/{ccv} :(Admin, User) IDsi girilen kullanıcının belirtilen dönem borcunu ödemek için ödeme APIsine bağlanır 



<h4>User</h4>

GET /Api/Users/LoginUser/{userName}/{password} :(AllowAnonymous) Oturum açmamış kullanıcının oturum açmasını sağlar 

GET /Api/Users/Seed :(AllowAnonymous) Sistem ilk defa kullanılırken varsayılan admin ve bir kullancı oluşturmak için kullanılır

GET /Api/Users/GetAllUser :(Admin, User) Bütün kullanıcıları listeler

GET /Api/Users/GetUserBy/{id} :(Admin, User) ID'si girilen kullanıcıyı getirir

GET /Api/Users/GetUserByTc/{tc} :(Admin, User) TC'si girilen kullanıcıyı getirir

GET /Api/Users/GetUserByName/{name} :(Admin, User) İsminin bir kısmı eşleşen kullanıcıları listeler

POST /Api/Users/AddUser :(Admin) Yeni kullanıcı oluşturma

PUT /Api/Users/ChangeUserBy/{id} :(Admin, User) Kullanıcı değiştirmek için. (Burada her kullanıcının yalnızca kendisini değiştirmesi için doğrulama yapılmalı)

DELETE /Api/Users/DeleteUserBy/{id} :(Admin) Kullanıcı silmek için. 

<h3>PaymentApi</h3>

<h4>CreditCard</h4>
GET /api/CreditCard : Kredikartlarını listeler.

POST /api/CreditCard : Yeni kredikartı ekler.

GET /api/CreditCard/{id} : Girilen ID'li kredikartını getirir.

PUT /api/CreditCard/{id} : Girilen ID'li kredikartını düzenler.

DELETE /api/CreditCard/{id} : Girilen ID'li kredikartını siler.

GET /api/CreditCard/{cardNumber} : Girilen numara ile eşleşen kredikartını getirir.

PUT /api/CreditCard/{cardNumber} : Girilen numara ile eşleşen kredikartını düzenler.

<h4>Payment</h4>

GET /api/Payment/{cardNumber}/{exYear}/{exMonth}/{ccv}/{debt}  : Kart bilgileri doğru ise ödemeye onay verir ve bakiyeden miktarı düşer.

POST /api/Payment/{cardNumber}/{addBalance} : Karta bakiye yükler.

<h4>PaymentHistory</h4>

GET /api/PaymentHistory : Ödeme geçmişini listeler.

POST /api/PaymentHistory : Ödeme geçmişine kayıt ekler.

GET /api/PaymentHistory/{id} : Belirli bir  ödeme bilgisini getirir.

PUT /api/PaymentHistory/{id} : Belirli bir ödemeyi düzenler.

DELETE /api/PaymentHistory/{id} : Belirli bir ödemeyi siler.

GET /api/PaymentHistory/{cardNumber} : girilen numaralı ödeme bilgisini getirir.
