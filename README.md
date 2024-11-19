# .NET-Framework-NLayered-Demo

Bu proje, katmanlı mimari kullanılarak oluşturulmuş bir demo projesidir. Proje, Northwind veritabanı bağlantısı ile ürün ekleme, silme ve güncelleme işlemlerini gerçekleştirmektedir.

> Not: Northwind, hazır bir veritabanı olduğu için silme işlemi, veritabanında önceden tanımlı elemanlar için geçerli olmayabilir.

---

## Özellikler

- Ürün ekleme
- Ürün güncelleme
- Ürün silme (kısıtlı kullanım)

---

## Kurulum

1. Proje dosyalarını klonlayın:
   ```bash
   git clone https://github.com/furkancaliskann/.NET-Framework-NLayered-Demo.git

2. MSSQL Management Studio veya benzeri bir araç kullanarak ana dizinde bulunan Northwind.bak dosyasını yedekten geri yükleyin.

3. Projeyi açın ve App.config dosyası içerisinde bulunan veritabanı bağlantı bilgilerinizi güncelleyin.