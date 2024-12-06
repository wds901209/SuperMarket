var builder = WebApplication.CreateBuilder(args);

// �b�o�̵��U�Ҧ��A��
builder.Services.AddControllersWithViews(); // ���U MVC ����M���ϪA��

var app = builder.Build(); // �I�s Build() �إ����ε{��

app.UseStaticFiles();   // �Ψ�access wwwroot(�M�����S���Τ�ݪ���Ƨ� means's exposed)

// �]�w���ε{�������ѩM�����n��
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"); // �q�{���ѳ]�w�� https://localhost:7071/Home/Index

app.Run(); // �Ұ����ε{��
