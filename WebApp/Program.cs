var builder = WebApplication.CreateBuilder(args);

// �b�o�̵��U�Ҧ��A��
builder.Services.AddControllersWithViews(); // ���U MVC ����M���ϪA��

// �[�J�������O����֨��M Session ���A��
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Session �L���ɶ�
    options.Cookie.HttpOnly = true; // ����u��z�L HTTP �X�� Cookie
    options.Cookie.IsEssential = true; // �T�O�Y�Ϧb GDPR �Ҧ��U�ASession �]�|�Q�x�s
});

var app = builder.Build(); // �I�s Build() �إ����ε{��

app.UseStaticFiles();   // �Ψ� access wwwroot(�M�����S���Τ�ݪ���Ƨ�)

// �[�J Session �����n��A�ݩ�b UseRouting ���e
app.UseRouting();
app.UseSession(); // �ҥ� Session �\��

// �]�w���ε{��������
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"); // �q�{���ѳ]�w�� https://localhost:7071/Home/Index

app.Run(); // �Ұ����ε{��
