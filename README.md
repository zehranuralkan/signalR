# signalR

Client-Server arasındaki klasik haberleşme yöntemi yapılan request’e karşılık verilen response ilişkisi üzerinden eşzamanlı olarak sağlanmaktadır. Client server’a bir istek gönderir server gelen request neticesinde gerekli sonucu üretir ve bu sonucu client’a gönderir. 
Bu durum hepimizin yıllarca deneyimlediği gibi bir bekleme süreci yahut sayfanın gidip gelmesiyle sonuçlanmakta ve böylece kullanıcı açısından zamansal maliyetle birlikte, deneyim açısından günümüze yakışmayan ilkelliğe alamet etmektedir. 
Real time hizmet verebilecek bir teknolojiye ihtiyaç olduğu ve http’den farklı olarak TCP protokolünü benimseyen WebSocket altyapılı sistemlerin kullanılması gerektiği ortadadır.

#WebSocket Nedir?
TCP bağlantısı Client-Server arasında çift yönlü mesajlaşmayı sağlayan bir protokoldür.
Bi-Directional mesajlaşma (çift yönlü)

#SignalR Nedir?
SignalR, web uygulamalarına, WebSocket teknolojisini kullanarak Real Time fonksiyonellik kazandıran bir open source kütüphanedir.
#Yapısal Olarak SignalR
SignalR altında yatan teknoloji WebSocket’dir.
Özünde RPC (Remote Precedure Call) mekanizmasını benimsemektedir. RPC sayesinde server server, client’ta bulunan herhangi bir metodun tetiklenmesini ve veri transferini sağlayabilmektedir.
Böylece uygulamalar server’dan sayfa yenilemeksizin data transferini sağlamış olacak ve gerçek zamanlı uygulama davranışı sergilemiş olacaktır. Uygulamanın gerçek zamanlı olması client ve server’ın anlık olarak karşılıklı haberleşmesi anlamına gelmektedir.

#SignalR Nasıl Çalışır
SignalR, ‘Hub’ ismi verilen merkezi bir yapı üzerinden şekillenmektedir. ‘Hub özünde bir class’dı ve içeriisnde tanımlanan bir metoda subscribe olan tüm clientlar ilgili hub üzerinden iletilen mesajları alacaktır. 

#OTOMATİK BAĞLANTI KONFİGÜRASYONU 
SignalR vasıtasıyla client ve server arasında eşzamanlı bir etkileşim sağlanmaya çalışırken
1-	Bağlantının kurulamama 
2-	Var olan bağlantının süreç içerisinde kopabilme 
Bu gibi durumlarda bağlantının yeniden kurulmasıdır. Kurulum yapılmadıysa kurulum için talep gönderilmesi gerekir. 
withAutomaticReconnect Fonksiyonuyla Kopan Bağlantıyı Yeniden Denemek: Bu yöntem bağlantı kopar kopmaz reconnect olmayı dener. Yani sıfırıncı saniyede. Ardından eğer bağlantı sağlanmazsa iki saniye, sağlanmazsa on, sağlanmazsa otuz saniye olarak dört periyotta talepleri yapar.

#DURUM EVENTLERİ
1-onreconnecting: Yeniden bağlanma girişimlerini başlatmadan önce tetiklenen event’tir.
2-onreconnected: Yeniden bağlantı gerçekleştiğinde tetiklenen fonksiyondur.
3-onclose: Yeniden bağlantı girişimlerinin sonuçsuz kaldığı durumlarda fırlatılır.

#Clientlar tarafında Hublara Yapılan Bağlantıları Yönetmek:
Bağlantı olayları SignalR kütüphanesinde server kanadında kullandığımız fonksiyonel yapılanmadır. Sisteme herhangi bir client bağlantı sağlandığında sistem tarafından bir event gerçekleştirilir. Bu olay sayesinde bütün client’lara haber verebiliyorsun. Sisteme clientlar tarafından bağlantı sahip olduğunda eventler aracılığıyla sistemi belli amaçlarla çalıştırabiliyoruz.
Sisteme bir client dahil olduğunda tetiklenen olay onConnectedAsync
Sistemden bir client ayrıldığında tetiklenen olay onDisconnectedAsync
*Bağlantı olayları signalR uygulamalarında loglama için oldukça elverişli fonksiyonlardır.
*ConnectionId: Hub’a bağlantı gerçekleştiren client’lara sistem tarafından verilen, unique bir değerdir. Amacı, clientlar’ı birbirinden ayırmadır. 

#BAĞLI OLAN TÜM CLIENT’LARI LİSTELEME
Bağlantı olan tüm clientları koleksiyona atıp, bu koleksiyonu tüm clientlara göndererek. Bağlantısı kopan client’ları ilgili koleksiyondan çıkartıp güncellemesini sağlarız.

#IHUBCONTEXT
1-IHubContext: Çalıştığımız projelerde WebSocket kullanıyorsak business mantığında bazen socket işlemlerine ihtiyacımız olabilir. Bu durumlarda hub sınıflarını iş mantıklarında kullanamayız. İş mantığında, ya da diğer katmanlarda buradaki çalışmayı hub’ın dışına almamız gerekir. Server’a bağlı clientlara ileti göndermeye yönelik çalışmaları hub sınıfından soyutlamamızı sağlayan ve böylece ileti gönderimini hub dışı kontrol haline getirmemizi sağlayan interface’dir. Bu interface sayesinde hub’ı başka bir sınıflarda kullanamıyorsak ya da iş mantığına dahil edemiyorsak IHubContext sayesinde ilgili hub’ın dışa karşı sorumluluğunu verebiliyorsun. Hub’daki çalışmaları, sorumlulukları, hub’daki web socket operasyonlarını normal sınıflara taşıyabilmekte ve operasyonlar gerçekleştirebilmekte.
Artıları
-İş mantığında websocket işlemlerini gerçekleştirmemizi sağlar.
- Controllerlarda gelen requestin neticesinde real time bir şekilde websocket üzerinden client’lara çalışma yapmamız gerektiğinde controllerda direkt tetikleyebilecek özellik sağlar
-Web uygulamalarında design pettern’lar üzerinden de webSocket operasyonlarını kullanılabilir.

#STRONGLY TYPED HUBS
SignalR ve bunun gibi birden fazla sistemin iletişim kurduğu uygulamalarda kullanılan özelliktir. Yazılım uygulamalarında sistemler arası haberleşmeleri yahut ortak tanımlamaları metinsel/statik değerler üzerinden sağlamaya çalışmak, olası hata yapma ihtimallerini arttırmakta ve böylece sisteme ister istemez ekstra bir zorluk kazandırmaktadır. Strong Typed Hubs özelliği ile türü kesin belirlenmiş hublar tanımlanarak, metinsel yapılanmanın yarattığı handikaplardan bir nebze olsun arınabilmeyi ve client’ta tetiklenecek olan metot bildiriminin server’da derleme zamanındaki denetimini etkinleştirmeyi sağlayabiliriz.



