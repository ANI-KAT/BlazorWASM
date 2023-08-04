using BlazorApp.Data;
using BlazorApp.Helpers;
using BlazorApp.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;

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
        public ApiHelper ApiHelper { get; set; }

        [Inject]
        NavbarService navbarService { get; set; }

        protected override void OnInitialized()
        {
            navbarService.HideNavbar();
        }


        public async Task OnValidLicense()
        {
            string msg = string.Empty;
            UserNmErrorMsg = PasswdErrorMsg = string.Empty;
            if (!string.IsNullOrWhiteSpace(Username) && !string.IsNullOrWhiteSpace(Password))
            {
                ShowSpinner = true;
                var result = await ApiHelper.AuthicateUser(Username, Password);
                ShowSpinner = false;

                if (result == null)
                    await _jsRuntime.InvokeVoidAsync("ShowAlert", "error", "Server not responding.");
                else
                {
                    NavManager.NavigateTo($"/license");
                }
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
