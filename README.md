# sabanci-dx-case

Bu proje, sabanci-dx-case adıyla yayınlanmıştır. Bu readme belgesi, projeyi yerel bir geliştirme ortamında nasıl çalıştırmanız gerektiğini adım adım açıklar.

## Gereksinimler

Aşağıdaki gereksinimleri sağlamalısınız:

- [Visual Studio 2022](https://visualstudio.microsoft.com/) yüklü olmalıdır.
- [.NET Core 6](https://dotnet.microsoft.com/download/dotnet/6.0) yüklü olmalıdır.
- [Microsoft SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) yüklü ve yerel sunucu olarak erişilebilir olmalıdır.

## Kurulum

1. Bu depoyu bilgisayarınıza klonlayın veya ZIP dosyasını indirin ve çıkarın.
2. Visual Studio 2022'yi açın ve projeyi açmak için "File" -> "Open" -> "Project/Solution" seçeneğini kullanın.
3. Proje açıldığında, Visual Studio içinde NuGet Package Manager'ı açın.
4. Aşağıdaki komutu kullanarak veritabanını oluşturun:
   Update-Database
   
Veritabanı başarıyla oluşturulduktan sonra, proje çalıştırılabilir.

##Kullanım
Proje başarıyla çalıştırıldığında, https://localhost:7074 adresini kullanarak uygulamayı görüntüleyebilirsiniz.
