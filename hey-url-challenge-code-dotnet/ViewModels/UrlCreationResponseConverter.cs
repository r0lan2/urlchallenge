using System.Collections.Generic;
using hey_url_domain.Model;

namespace hey_url_challenge_code_dotnet.ViewModels
{
    public static class UrlCreationResponseConverter
    {
        public static HomeViewModel ToHomeViewModel(this UrlCreationResponse response, List<UrlListResponse> list)
        {
            var viewModel = new HomeViewModel()
            {
                ErrorMessages = response.IsOk ? new List<string>() : response.ValidationErrors,
                Urls = list
            };
            if (response.IsOk)
            {
                viewModel.NewUrl = new()
                {
                    LongUrl = string.Empty
                };
            }
            return viewModel;
        }
    }
}
