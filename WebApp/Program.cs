var builder = WebApplication.CreateBuilder(args);

// 在這裡註冊所有服務
builder.Services.AddControllersWithViews(); // 註冊 MVC 控制器和視圖服務

var app = builder.Build(); // 呼叫 Build() 建立應用程式

app.UseStaticFiles();   // 用來access wwwroot(專門暴露給用戶端的資料夾 means's exposed)

// 設定應用程式的路由和中介軟體
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"); // 默認路由設定為 https://localhost:7071/Home/Index

app.Run(); // 啟動應用程式
