<h3>Innova .Net Core Patika Bootcamp Bitirme projesi.</h3>

Proje ilk açıldığında  app-migration ile update-database uygulanacağı sırada varsayılan proje SiteManagementApi olmalı, normal çalışma zamanında ise SiteManagementApi, PaymentApi ve SiteManagement Api başlangıç projesi olarak seçili olmalı. 

İlk kullanımda Admin ve User oluşturmak için GET "https://localhost:6001/Api/Users/Seed" requesti çalıştırılmalı.

Frontend bilgim yeterli olmadığı için arayüzde validation uygulamadım ve yanlış değerlerde uygulama çıktı vermek yerine hata veriyor bu sorun Swagger ve Postmande oluşmuyor.
<br><br>
Seed ile üretilen kullanıcılar:

|Kullanıcı adı:  | Şifre:       |
|----------------|--------------|
|Admin           | 123546       |
|----------------|--------------|
|User            | 123546       |
|----------------|--------------|

Tc 11 haneli, telefon 10 haneli olmalı, Şifre 6 karakter yada daha uzun olmalı, ay 0 ile 12 arasında yıl ise en fazla 9999 omalıdır.
