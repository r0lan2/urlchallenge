using System.Linq;
using hey_url_challenge_code_dotnet.Models;
using hey_url_challenge_code_dotnet.ViewModels;

namespace hey_url_challenge_code_dotnet.Services
{
    public static class UrlClickConverter
    {
        public static ShowViewModel ToShowViewModel(this Url url)
        {
            ShowViewModel viewModel = new ShowViewModel
            {
                Url = url,
                DailyClicks = url.Clicks.GroupBy(s=> s.ClickDate).ToDictionary(g=> g.Key.ToString(), g=>g.Count()),
                BrowseClicks = url.Clicks.GroupBy(s => s.BrowserName).ToDictionary(g => g.Key.ToString(), g => g.Count()),
                PlatformClicks = url.Clicks.GroupBy(s => s.OsName).ToDictionary(g => g.Key.ToString(), g => g.Count())
            };
            return viewModel;
        }
    }
}

