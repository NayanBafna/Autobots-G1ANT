using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using G1ANT.Language;

namespace G1ANT.Addon.Instagram

{
    [Command(Name = "instagram.login", Tooltip = "This command is used to login in to the instagram site.")]
    public class InstagramLoginCommand : Command
    {
        public InstagramLoginCommand(AbstractScripter scripter) : base(scripter)
        {

        }
        public class Arguments : SeleniumCommandArguments
        {
            [Argument(Required = true, Tooltip = "Enter the username here")]
            public TextStructure username { get; set; }

            [Argument(Required = true, Tooltip = "Enter the password here")]
            public TextStructure pword { get; set; }
            [Argument(DefaultVariable = "timeoutselenium", Tooltip = "Specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed")]
            public override TimeSpanStructure Timeout { get; set; } = new TimeSpanStructure(SeleniumSettings.SeleniumTimeout);
        }

        public void Execute(Arguments arguments)
        {
            try
            {
                SeleniumWrapper wrapper = SeleniumManager.CreateWrapper(
                       "chrome",
                       "instagram.com",
                       arguments.Timeout.Value,
                       false,
                       Scripter.Log,
                       Scripter.Settings.UserDocsAddonFolder.FullName);
                int wrapperId = wrapper.Id;
                OnScriptEnd = () =>
                {
                    SeleniumManager.DisposeAllOpenedDrivers();
                    SeleniumManager.RemoveWrapper(wrapperId);
                    SeleniumManager.CleanUp();
                };
                
                arguments.Search.Value = "username";
                arguments.By.Value = "name";
                SeleniumManager.CurrentWrapper.TypeText(arguments.username.Value, arguments, arguments.Timeout.Value);
                arguments.Search.Value = "password";
                arguments.By.Value = "name";
                SeleniumManager.CurrentWrapper.TypeText(arguments.pword.Value, arguments, arguments.Timeout.Value);
                SeleniumManager.CurrentWrapper.PressKey("enter", arguments, arguments.Timeout.Value);
                System.Threading.Thread.Sleep(2000);
                arguments.Search.Value = "#react-root > section > main > div > div > div > div > button";
                arguments.By.Value = "cssselector";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                System.Threading.Thread.Sleep(10000);
                arguments.Search.Value = "body > div.RnEpo.Yx5HN > div > div > div > div.mt3GC > button.aOOlW.HoLwm";
                arguments.By.Value = "cssselector";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);


            }

            catch (Exception ex)
            {
                throw new ApplicationException($"Error occured while opening new selenium instance. Message: {ex.Message}", ex);
            }
        }
    }
}