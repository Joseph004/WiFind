

using System.Configuration;
using Microsoft.AspNetCore.Components;

namespace WiFind_Blazor.Pages
{
    partial class Index : ComponentBase
    {
        RegisterAccountForm model = new();
        [Inject] HttpClient _httpClient { get; set; }
        bool showSuccessMessage = false;
        string successMessage = "";
        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
        }
        public class RegisterAccountForm
        {
            public string Location { get; set; } = "";
            public string Where { get; set; } = "";
            public string WiFiName { get; set; } = "";
            public string Password { get; set; } = "";
        }

        private async Task OnValidSubmit()
        {

            //_httpClient.PostAsync("https://localhost:67657/api/password", model);




            StateHasChanged();
            await Task.Delay(3000);

            // Reset the success message and the form after a while
            showSuccessMessage = false;
            successMessage = "";
            model = new RegisterAccountForm();
        }

        private string GetRandomSuccessMessage()
        {
            Random random = new Random();
            int index = random.Next(successMessages.Count);
            return successMessages[index];
        }

        private List<string> successMessages = new List<string>
    {
        "Hooray! You did it!",
        "Success: High-five moment!",
        "Bravo! Task accomplished!",
        "Achievement unlocked!",
        "Ta-da! Magic happened!",
        "Congratulations! Another success!",
        "Well done! You're amazing!",
        "Success: You're on fire!",
        "Awesome! You nailed it!",
        "Kudos! You're a rock star!",
        "Way to go! Success is yours!",
        "Success: You're a superstar!",
        "Woot woot! Victory is yours!",
        "Excellent! You're a champ!",
        "Success: You're unstoppable!",
        "Amazing! You're a legend!",
        "Success: You're a wizard!",
        "Great job! You're a genius!",
        "Success: You're a superhero!",
        "Outstanding! You're a master!",
        // add more if u feel creative!
    };
    }
}