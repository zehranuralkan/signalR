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




