var builder = WebApplication.CreateBuilder(args);

// 在這裡註冊所有服務
builder.Services.AddControllersWithViews(); // 註冊 MVC 控制器和視圖服務

// 加入分散式記憶體快取和 Session 的服務
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Session 過期時間
    options.Cookie.HttpOnly = true; // 限制只能透過 HTTP 訪問 Cookie
    options.Cookie.IsEssential = true; // 確保即使在 GDPR 模式下，Session 也會被儲存
});

var app = builder.Build(); // 呼叫 Build() 建立應用程式

app.UseStaticFiles();   // 用來 access wwwroot(專門暴露給用戶端的資料夾)

// 加入 Session 中介軟體，需放在 UseRouting 之前
app.UseRouting();
app.UseSession(); // 啟用 Session 功能

// 設定應用程式的路由
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"); // 默認路由設定為 https://localhost:7071/Home/Index

app.Run(); // 啟動應用程式
