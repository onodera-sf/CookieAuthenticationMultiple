using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;

var builder = WebApplication.CreateBuilder(args);

// �R���e�i�ɃT�[�r�X��ǉ����܂��B
builder.Services.AddRazorPages();

// ����������ǉ�

// Cookie �ɂ��F�؃X�L�[����ǉ�����
builder.Services
  .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
  .AddCookie("FirstAuth", option =>
  {
    option.LoginPath = "/Account/LoginFirst";
  })
  .AddCookie("SecondAuth", option =>
  {
    option.LoginPath = "/Account/LoginSecond";
  });

builder.Services.AddAuthorization(options =>
{
  // �F�ؑ�����ݒ肵�Ă��Ȃ���ʂ� FirstAuth �X�L�[�}�̔F�؂��K�v�ƂȂ�
  options.FallbackPolicy = new AuthorizationPolicyBuilder("FirstAuth")
    .RequireAuthenticatedUser()
    .Build();
});

// �������܂Œǉ�


var app = builder.Build();

// HTTP ���N�G�X�g �p�C�v���C�����\�����܂��B
if (!app.Environment.IsDevelopment())
{
  app.UseExceptionHandler("/Error");
  // �f�t�H���g�� HSTS �l�� 30 ���ł��B �^�p�V�i���I�ł͂����ύX���邱�Ƃ��ł��܂��Bhttps://aka.ms/aspnetcore-hsts ���Q�Ƃ��Ă��������B
  app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication(); // [�ǉ�] �F��
app.UseAuthorization(); // �F��

app.MapRazorPages();

app.Run();
