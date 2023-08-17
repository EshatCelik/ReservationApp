# ReservationApp

* Reservasyon sistemi  girilen tarih , masa numarası, kullanıcı bilgileriyle rezervasyon eklenmektedir.
*Masalar eklenebilmektedir ve tüm masalar çekilebilmektedir
*Rezervasyon eklendiği durumda kullanıcıya mail gönderilmektedir (mail servisi eklenmiş olup gerçek bir smtp client oluşturulmamıştır sadece metodlar oluşturulmuştur)

--Validasyon
Dto ların validasyonu FluentValidation kütüphanesi kullanılmaktadır

--Mapping 
Entitylerden dto dönüşümlerine IMapper kullanılmıştır

-- Response mesajı
Response mesajları ResponseDto dan türetilen sınıflardan dönüş sağlar

--DesignPattern
Projede RepositoryDesing Pattern kullanılmıştır, EntityFramework ve InMemory database kullanılmıştır
Kullanıcı eklemek istediği DBContext sınıfını hangi frameworkten kullanmak istediğinde kolayca değiştirmektedir

-Unit Test
Projede xUnit kütüphanesi sayesinde unit testler yazılmıştır


Reservasyon Ekleme 
1-Rezervasyon eklendiğinde fluentValidation modellerin validasyonlarını kontrol etmektedir, herhangi bir uyarıya uymayan propertyler hata olarak kullanıcıya gösterilmektedir
2-Validasyonlar isvalid olunca rezerve edilmek istenen masanın bilgisinin başka bir rezervasyonda kullanılmağı kontrol edilmektedir
3- Bu işlem de başarılı olursa Rezervasyonu kaydeder
4- Rezervasyon ekleme işlemi başarılı olursa MailServisine istek atarak mail atma işlemi yapılır
5- Eğer rezervasyon ekleme işlemi başarısız olursa da kullanıcıya uyarı mesajı atarak bilgilendirme yapılır


Masa Silme

1-Bir masa silinmek istediğinde herhangi bir rezervasyonda kullanılıyorsa kullanıcıya hata verir ve silme işlemi yapılmaz



