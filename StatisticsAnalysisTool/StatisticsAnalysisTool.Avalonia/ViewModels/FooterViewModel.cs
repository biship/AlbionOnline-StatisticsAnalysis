using ReactiveUI;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Input;

namespace StatisticsAnalysisTool.Avalonia.ViewModels
{
    // https://www.reactiveui.net/docs/handbook/commands/
    public class FooterViewModel : ViewModelBase
    {
        public ICommand OpenGitHubRepoClicked { get; }
        public ICommand OpenDonateUrlClicked { get; }
        public ICommand OpenDiscordUrlClicked { get; }

        public FooterViewModel()
        {
            OpenDonateUrlClicked = ReactiveCommand.Create(OpenDonateUrl);
            OpenDiscordUrlClicked = ReactiveCommand.Create(OpenDiscordUrl);
            OpenGitHubRepoClicked = ReactiveCommand.Create(OpenGithubRepo);
        }

        #region Hyperlinks

        private void OpenDonateUrl()
        {
            OpenWebsite("https://www.paypal.com/donate?hosted_button_id=4PZ8DB8PSWCK8");
        }

        private void OpenDiscordUrl()
        {
            OpenWebsite("https://discord.com/invite/sahSrSPmaJ");
        }

        private void OpenGithubRepo()
        {
            OpenWebsite("https://github.com/Triky313/AlbionOnline-StatisticsAnalysis");
        }

        private void OpenWebsite(string url)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                Process.Start(new ProcessStartInfo("cmd", $"/c start {url}"));
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                Process.Start("xdg-open", url);
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                Process.Start("open", url);
            }
        }

        #endregion

        #region Binding

        public static string Version => $"v{Assembly.GetExecutingAssembly().GetName().Version}";

        #endregion
    }
}