using CookieAuthenticationMultipleMvc.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CookieAuthenticationMultipleMvc.Controllers
{
  /// <remarks>
  /// <see cref="AllowAnonymous"/> 属性は Cookie 認証していなくてもアクセスできる Action (Controller) であることを示す。
  /// </remarks>
  [AllowAnonymous]
  public class AccountController : Controller
  {
    /// <summary>仮のユーザーデータベースとする。</summary>
    private Dictionary<string, string> UserAccounts { get; set; } = new Dictionary<string, string>
    {
      { "user1", "password1" },
      { "user2", "password2" },
    };

    /// <summary>ログイン画面を表示します。</summary>
    public IActionResult LoginFirst() => View();

    /// <summary>ログイン処理を実行します。</summary>
    [HttpPost]
    public async Task<IActionResult> LoginFirst(LoginModel model)
    {
      // 入力内容にエラーがある場合は処理を中断してエラー表示
      if (ModelState.IsValid == false) return View(model);

      // ユーザーの存在チェックとパスワードチェック (仮実装)
      // 本 Tips は Cookie 認証ができるかどうかの確認であるため入力内容やパスワードの厳密なチェックは行っていません
      if (UserAccounts.TryGetValue(model.UserName, out string? getPass) == false || model.Password != getPass)
      {
        ModelState.AddModelError("", "ユーザー名またはパスワードが一致しません。");
        return View(model);
      }

      // サインインに必要なプリンシパルを作る
      var claims = new[] { new Claim(ClaimTypes.Name, model.UserName) };
      var identity = new ClaimsIdentity(claims, "FirstAuth");
      var principal = new ClaimsPrincipal(identity);

      // 認証クッキーをレスポンスに追加
      await HttpContext.SignInAsync("FirstAuth", principal);

      // ログインが必要な画面にリダイレクトします
      return RedirectToAction(nameof(HomeController.Index), "HomeFirst");
    }

    /// <summary>ログアウト処理を実行します。</summary>
    public async Task<IActionResult> LogoutFirst()
    {
      // 認証クッキーをレスポンスから削除
      await HttpContext.SignOutAsync("FirstAuth");

      // ログイン画面にリダイレクト
      return RedirectToAction(nameof(LoginFirst));
    }

    /// <summary>ログイン画面を表示します。</summary>
    public IActionResult LoginSecond() => View();

    /// <summary>ログイン処理を実行します。</summary>
    [HttpPost]
    public async Task<IActionResult> LoginSecond(LoginModel model)
    {
      // 入力内容にエラーがある場合は処理を中断してエラー表示
      if (ModelState.IsValid == false) return View(model);

      // ユーザーの存在チェックとパスワードチェック (仮実装)
      // 本 Tips は Cookie 認証ができるかどうかの確認であるため入力内容やパスワードの厳密なチェックは行っていません
      if (UserAccounts.TryGetValue(model.UserName, out string? getPass) == false || model.Password != getPass)
      {
        ModelState.AddModelError("", "ユーザー名またはパスワードが一致しません。");
        return View(model);
      }

      // サインインに必要なプリンシパルを作る
      var claims = new[] { new Claim(ClaimTypes.Name, model.UserName) };
      var identity = new ClaimsIdentity(claims, "SecondAuth");
      var principal = new ClaimsPrincipal(identity);

      // 認証クッキーをレスポンスに追加
      await HttpContext.SignInAsync("SecondAuth", principal);

      // ログインが必要な画面にリダイレクトします
      return RedirectToAction(nameof(HomeController.Index), "HomeSecond");
    }

    /// <summary>ログアウト処理を実行します。</summary>
    public async Task<IActionResult> LogoutSecond()
    {
      // 認証クッキーをレスポンスから削除
      await HttpContext.SignOutAsync("SecondAuth");

      // ログイン画面にリダイレクト
      return RedirectToAction(nameof(LoginSecond));
    }
  }
}