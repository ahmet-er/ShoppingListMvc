# Techcareer - TM Backend Bootcamp Bitirme Projesi

Projenin amacı, kullanıcıların alışveriş süreçlerini kolaylaştırmak adına almayı planladıkları ürünlerin listelerini oluşturabilmesi ve bu listelerin takiplerini yapabilmesidir.
Uygulamanın kullanılabilmesi için üye olmak gerekmektedir.
-  Kullanıcılar sisteme kayıtlı oldukları bilgilerle giriş yaptıktan sonra işlevsellikleri kullanabileceklerdir.
- Kullanıcılar sisteme giriş yaptıktan sonra oluşturdukları alışveriş listelerini göreceklerdir. Buradan istedikleri listeyi seçip ürün ekleme ekrana geçebileceklerdir.
- Ürün ekleyebilmeleri için listelenen ürünlerden istediklerine tıklayıp beklenen bilgileri girecek ve ekle diyeceklerdir.
- Ürünlerin içerisinde ismiyle arama yapılabilecektir. İstenirse kategorisine göre de filtrelenecektir.
- Kullanıcılar listeleri sadece ürün ekleyerek değil, ürün kaldırarak da güncelleyebileceklerdir.
- Kullanıcı bir liste için “Alışverişe Çıkıyorum” seçeneğini işaretlediğinde artık o listeye ürün ekleyemeyecektir.
- Kullanıcı ürünleri aldıkça liste üzerinden ilgili ürünü seçip “Aldım” diye işaretleyecektir. Liste için “Alışveriş Tamamlandı” seçeneğini işaretlediğinde liste müdaheleye açık hale gelecektir.
- Sistemde yer alan ürünleri bilgileriyle beraber sistem yöneticisi ekleyecektir.

<h3 align="left">Languages and Tools:</h3>
<p align="left">
  <a href="https://www.w3schools.com/cs/" target="_blank" rel="noreferrer"> <img src="https://raw.githubusercontent.com/devicons/devicon/master/icons/csharp/csharp-original.svg" alt="csharp" width="40" height="40"/> </a> 
  <a href="https://dotnet.microsoft.com/" target="_blank" rel="noreferrer"> <img src="https://raw.githubusercontent.com/devicons/devicon/master/icons/dot-net/dot-net-original-wordmark.svg" alt="dotnet" width="40" height="40"/> </a>
  <a href="https://www.microsoft.com/en-us/sql-server" target="_blank" rel="noreferrer"> <img src="https://www.svgrepo.com/show/303229/microsoft-sql-server-logo.svg" alt="mssql" width="40" height="40"/> </a>
  <a href="https://getbootstrap.com" target="_blank" rel="noreferrer"> <img src="https://raw.githubusercontent.com/devicons/devicon/master/icons/bootstrap/bootstrap-plain-wordmark.svg" alt="bootstrap" width="40" height="40"/> </a> 
  <a href="https://www.w3.org/html/" target="_blank" rel="noreferrer"> <img src="https://raw.githubusercontent.com/devicons/devicon/master/icons/html5/html5-original-wordmark.svg" alt="html5" width="40" height="40"/> </a> 
  <a href="https://www.w3schools.com/css/" target="_blank" rel="noreferrer"> <img src="https://raw.githubusercontent.com/devicons/devicon/master/icons/css3/css3-original-wordmark.svg" alt="css3" width="40" height="40"/> </a>  
  <a href="https://developer.mozilla.org/en-US/docs/Web/JavaScript" target="_blank" rel="noreferrer"> <img src="https://raw.githubusercontent.com/devicons/devicon/master/icons/javascript/javascript-original.svg" alt="javascript" width="40" height="40"/> </a>  
  <a href="https://brand.jquery.org/" target="_blank" rel="noreferrer"> <img src="https://e7.pngegg.com/pngimages/265/442/png-clipart-jquery-ui-javascript-web-browser-pasargad-text-trademark-thumbnail.png" alt="jquery" width="40" height="40"/> </a>
  <a href="#" target="_blank" rel="noreferrer"> <img src="https://upload.wikimedia.org/wikipedia/commons/thumb/a/a1/AJAX_logo_by_gengns.svg/2560px-AJAX_logo_by_gengns.svg.png" alt="ajax" width="40" height="40"/> </a>
</p>

# Kullanım Senaryoları
1. Üye Olma
  - Site açıldığında yer alan Üye Ol linki üzerinden gidilen sayfada ad, soyad, mail adresi, şifre ve şifre tekrar alanları bulunur. Bu alanların hepsi zorunludur. Şifre en az 8 karakter olmalı ve büyük harf, küçük harf ve rakam içermelidir. Kullanıcı bilgileri girdikten sonra üyeliği tamamla diyerek kaydını gerçekleştirir.
2. Üye Girişi Yapma
  - Site açıldığında yer alan giriş ekranı üzerinden sisteme giriş yapılır. Üyeler kayıt esnasında verdiklei mail ve şifre bilgileriyle giriş sağlarlar. Admin kullanıcısı ise sistem ayağa kaldırılırken oluşturulan mail ve şifre bilgileriyle sisteme giriş yapar.
  - Her mail adresine sadece bir kullanıcı hesabı tanımlıdır.
3. Admin Kullanıcısı Olma
  - Admin kullanıcısı kendisine sunulan menü üzerinden sistemde tanımlı ürün ve kategorilerle ilgili işlemleri yürütür. Kategori ekleme, güncelleme ve kaldırma işlemlerini gerçekleştirir. Ürün ekleme, güncelleme ve kaldırma işlemlerini yapar.
  - Kategorilerin sadece adı vardır ve bir ad sadece bir kategoriyi tanımlar.
  - Ürünlerin adı ve görseli vardır. Her ürünün bir kategorisi vardır. Sistemde aynı isimde tek bir ürün olur. Ürün görseli belli bir markayı işaret etmemelidir. Görsel olarak ikonlar da kullanılabilir.
4. Liste Oluşturma ve Ürün Ekleme
  - Üyeler istedikleri kadar liste oluşturabilir. Listelerin sadece adı vardır.
  -Kullanıcılar ürün listesinden ürün seçerek listeye ürün eklerler. Seçilen ürün için isterlerse bir açıklama(miktar, adet, marka vb. bilgiler için) girebilirler.
  - Listelerini görüntülediklerinde ürünlerin sadece adını ve sistemde kayıtlı görselini görürler. İsterlerse detayına gidip ürün eklerken girdikleri açıklamayı görebilirler ve buradan bu bilgiyi değiştirebilirler.
  - Listede görüntülenen ürünlerden istediklerini kaldırabilirler.
5. Alışveriş Yapma
-Üyeler listelerdeki ürünler için alışverişe çıktığında “Alışverişe Çıkıyorum” seçeneğini işaretlerler. Bu işaretlemeyi yaptıktan sonra ilgili liste üzerinde oynama yapamazlar. Sadece görüntüleyebilirler.
  - Alışverişe çıkan üye, mağazada ürünleri aldıkça ilgili ürünü “Aldım” şeklinde işaretleyebilir.
  - Alışveriş bittiğinde ilgili liste için “Alışveriş Tamamlandı” seçeneğini işaretler. Böylece yeniden liste üzerinde ürün ekleme, silme ve güncelleme işlemlerini yapabilirler. Ayrıca “Aldım” şeklinde işaretlediği ürünler otomatik olarak listeden kaldırılır
6. Liste Silme
  - Üyeler kendi oluşturdukları listeleri istedikleri zaman tamamen silebilirler.

# Ekran Görüntüleri

![homepage](https://r.resimlink.com/lzbSsFR.png "homepage")
<p align="center">Homepage</p>
<hr />

![register](https://r.resimlink.com/6RUMzm7.png "register")
<p align="center">Register</p>
<hr />

![login](https://r.resimlink.com/RY0pzDmT.png "login")
<p align="center">Log in</p>
<hr />

![inventory](https://r.resimlink.com/ANTSECG1I.png "inventory")
<p align="center">Inventory</p>
<hr />

![shoppinglist](https://r.resimlink.com/6Wh9SMdLke.png "shoppinglist")
<p align="center">Shopping List</p>
<hr />

![additemtoshoppinglist](https://r.resimlink.com/iyZwe.png "additemtoshoppinglist")
<p align="center">Add Item to Shopping List</p>
<hr />

![manageshoppinglist](https://r.resimlink.com/iD5kXehum6N.png "manageshoppinglist")
<p align="center">Manage Shopping List</p>
<hr />

![editlistitem](https://r.resimlink.com/yLxGANsOFa.png "editlistitem")
<p align="center">Edit List Item</p>
