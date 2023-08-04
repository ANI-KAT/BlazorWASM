namespace BlazorApp.Helpers
{
    public class NavbarService
    {
        public event Action<bool> OnNavbarVisibilityChanged;
        private bool isVisible = true;

        public bool IsVisible => isVisible;

        public void HideNavbar()
        {
            if (isVisible)
            {
                isVisible = false;
                NotifyNavbarVisibilityChanged();
            }
        }

        public void ShowNavbar()
        {
            if (!isVisible)
            {
                isVisible = true;
                NotifyNavbarVisibilityChanged();
            }
        }

        private void NotifyNavbarVisibilityChanged()
        {
            OnNavbarVisibilityChanged?.Invoke(isVisible);
        }
    }
}
