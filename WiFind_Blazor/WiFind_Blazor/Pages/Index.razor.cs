using Microsoft.AspNetCore.Components;
using MudBlazor;
using WiFind_Blazor.Models.Dtos;
using WiFind_Blazor.Repositories;

namespace WiFind_Blazor.Pages
{
    partial class Index : ComponentBase
    {
        RegisterAccountForm model = new();
        [Inject] IPasswordRepository PasswordRepository { get; set; }
        [Inject] ISnackbar Snackbar { get; set; }

        private bool _progress = false;
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
            _progress = true;
            StateHasChanged();
            var saveDataToDb = await PasswordRepository.PostPassword(new PostPasswordCommand
            {
                Location = model.Location,
                WiFiName = model.WiFiName,
                Password = model.Password,
                Where = model.Where
            });

            Snackbar.Add("Password Added succeeded", Severity.Success);
            await table.ReloadServerData();
            _progress = false;
            StateHasChanged();
            model = new RegisterAccountForm();
        }

        private IEnumerable<LocationDto> pagedData;
        private MudTable<LocationDto> table;

        private int totalItems;
        private string searchString = null;

        private async Task<TableData<LocationDto>> ServerReload(TableState state)
        {
            IEnumerable<LocationDto> data = await PasswordRepository.GetLocations();
            data = data.Where(location =>
            {
                if (string.IsNullOrWhiteSpace(searchString))
                    return true;
                if (location.LocationName.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                    return true;
                if (location.WiFiName.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                    return true;
                if (location.Password.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                    return true;
                if (location.City.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                    return true;
                if (location.CreatedTime.ToString().Contains(searchString, StringComparison.OrdinalIgnoreCase))
                    return true;
                return false;
            }).ToArray();
            totalItems = data.Count();
            switch (state.SortLabel)
            {
                case "location_field":
                    data = data.OrderByDirection(state.SortDirection, o => o.LocationName);
                    break;
                case "wifiname_field":
                    data = data.OrderByDirection(state.SortDirection, o => o.WiFiName);
                    break;
                case "password_field":
                    data = data.OrderByDirection(state.SortDirection, o => o.Password);
                    break;
                case "where_field":
                    data = data.OrderByDirection(state.SortDirection, o => o.City);
                    break;
                case "createdtime_field":
                    data = data.OrderByDirection(state.SortDirection, o => o.CreatedTime);
                    break;
            }

            pagedData = data.Skip(state.Page * state.PageSize).Take(state.PageSize).ToArray();
            return new TableData<LocationDto>() { TotalItems = totalItems, Items = pagedData };
        }

        private void OnSearch(string text)
        {
            searchString = text;
            table.ReloadServerData();
        }
    }
}