namespace CoreEmptyMvc
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
            var app = builder.Build();
            app.UseStaticFiles();
            //app.MapGet("/", () => "Hello World!");

            //if (app.Environment.IsDevelopment())
            //{

            //    app.UseExceptionHandler("/Home/Error");
            //    app.UseHsts();
            //}





            #region Routing
            //Route (Yonlendirme)
            //Gelen istekleri Url'leriyle eslestiren ve isleyen rota olarak tanimlanabilir.
            // Dotnet .Core'da varsayilan yonlendirme endpoint routing olarak isimlendirilir.
            // Kullanici istekte bulundugu zaman hangi controller icin calisacagini, 
            // Hangi actio'i ilgili modeli ile geri donecegini burada UseRouting middleware yapisi ile gerceklestirebilir.
            // Bu middleware sayesinde gelen istege karsi hangi controller calisacagini ve controller icerisindeki hangi action'nin tetiklenecegini belirleyebiliriz.
            // Bunun icin kullanilan middleware ise UseEndPoint middleware'dir.



            #endregion

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {

                endpoints.MapControllerRoute(name: "default",
                    pattern: "{controller=Kisi}/{action=Index}/{id?}");

            });
            app.Run();
        }
    }
}