using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using DocumentFormat.OpenXml.Spreadsheet;

namespace AuthenticationApp.Pages.Account
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public string InputUserID { get; set; }
        [BindProperty]
        public string InputPassword { get; set; }
        public string OutMessage { get; set; } = "";

        public void OnGet()
        {

        }

        public IActionResult OnPost(string ReturnUrl)
        {
            List<UserInfo> userList = new List<UserInfo>();
            userList.Add(new UserInfo("penta", "pen123", "ぺんた"));
            userList.Add(new UserInfo("tori", "tor123", "とりっち"));
            userList.Add(new UserInfo("morgan", "mog123", "もーがん"));
            userList.Add(new UserInfo("lucy", "luc123", "るーしー"));

            UserInfo authUserInfo = null;
            foreach (UserInfo ui in userList)
            {
                if (ui.id == InputUserID && ui.password == InputPassword)
                {
                    authUserInfo = ui;
                }
            }

            if (authUserInfo != null)
            {
                Claim[] claims = {
        new Claim(ClaimTypes.NameIdentifier, authUserInfo.id),
        new Claim(ClaimTypes.Name, authUserInfo.name)
        };

                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                HttpContext.SignInAsync(
                  CookieAuthenticationDefaults.AuthenticationScheme,
                  new ClaimsPrincipal(claimsIdentity),
                  new AuthenticationProperties
                  {
                      IsPersistent = true
                  }
                );

                if (ReturnUrl == null || ReturnUrl == "")
                {
                    return RedirectToPage("/Index");
                }
                else
                {
                    return Redirect(ReturnUrl);
                }

            }
            else
            {
                OutMessage = "IDまたはパスワードが違います。";
                return Page();
            }
        }

    }
}