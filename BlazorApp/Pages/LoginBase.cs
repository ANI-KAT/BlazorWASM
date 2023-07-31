using BlazorApp.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlazorApp.Pages
{
    public class LoginBase : ComponentBase
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string UserNmErrorMsg { get; set; } = string.Empty;
        public string PasswdErrorMsg { get; set; } = string.Empty;
        public bool ShowSpinner { get; set; } = false;

        [Inject]
        public NavigationManager NavManager { get; set; }

        [Inject]
        public IJSRuntime _jsRuntime { get; set; }


        [Inject]
        public IUserService UserService { get; set; }

        private DateTime dt = new DateTime(2023, 8, 30, 11, 0, 0);

        public async Task OnValidLicense()
        {
            string msg = string.Empty;
            UserNmErrorMsg = PasswdErrorMsg = string.Empty;
            if (!string.IsNullOrWhiteSpace(Username) && !string.IsNullOrWhiteSpace(Password))
            {
                ShowSpinner = true;
                var result = await UserService.Login(new UserRequest()
                {
                    email = Username,
                    password = Password
                });
                ShowSpinner = false;

                if (result == null)
                    await _jsRuntime.InvokeVoidAsync("ShowAlert", "error", "Server not responding.");
                else
                    NavManager.NavigateTo($"/license/{result.access_token}");
            }
            else
            {
                if (string.IsNullOrWhiteSpace(Username))
                {
                    UserNmErrorMsg = "Username cannot be blank";
                }
                if (string.IsNullOrWhiteSpace(Password))
                {
                    PasswdErrorMsg = "Password cannot be blank";
                }
            }
        }
    }
}
