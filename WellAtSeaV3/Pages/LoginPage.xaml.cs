
using System.Diagnostics;

namespace WellAtSeaV3
{
    public partial class LoginPage : ContentPage
    {
        private bool _isPasswordVisible = false;

        public LoginPage()
        {
            InitializeComponent();
        }

        private void TogglePasswordVisibility(object sender, EventArgs e)
        {
            var passwordEntry = (sender as ImageButton)?.Parent is Grid grid ? 
                grid.Children.FirstOrDefault(c => c is Entry) as Entry : null;

            if (passwordEntry != null)
            {
                _isPasswordVisible = !_isPasswordVisible;
                passwordEntry.IsPassword = !_isPasswordVisible;
                // Ideally, we would change the eye icon here too
            }
        }

        private async void OnLoginClicked(object sender, EventArgs e)
        {
            // TODO: Implement actual login logic
            Debug.WriteLine("Login button clicked");
            
            // For now, just navigate to the main page
            await Shell.Current.GoToAsync("//MainPage");
        }

        private async void OnForgotPasswordClicked(object sender, EventArgs e)
        {
            // TODO: Implement forgot password functionality
            await DisplayAlert("Forgot Password", "Password reset functionality will be implemented soon.", "OK");
        }
    }
}
