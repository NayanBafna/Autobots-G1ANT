using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using G1ANT.Language;

namespace G1ANT.Addon.Medium
{
    [Command(Name = "medium.login", Tooltip = "This command is login to open medium site")]
    class MediumLoginCommand : Command
    {
        public MediumLoginCommand(AbstractScripter scripter) : base(scripter)
        {

        }

        public class Arguments : SeleniumCommandArguments
        {
            [Argument(Name = "email", Required = true, Tooltip = "Enter you email id here")]
            public TextStructure email { get; set; }

            [Argument(Name = "pword", Required = true, Tooltip = "Enter your password here")]
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
                       "medium.com",
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
                Thread.Sleep(15000);
                arguments.Search.Value = "//a[@class='av aw ax ay az ba bb bc bd be bf bg bh bi bj'][contains(text(),'Sign in')]";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                Thread.Sleep(7000);
                arguments.Search.Value = "//div[contains(text(),'Sign in with Google')]";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                Thread.Sleep(5000);
                arguments.Search.Value = "identifier";
                arguments.By.Value = "name";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                Thread.Sleep(2000);
                SeleniumManager.CurrentWrapper.TypeText(arguments.email.Value, arguments, arguments.Timeout.Value);
                Thread.Sleep(2000);
                SeleniumManager.CurrentWrapper.PressKey("enter", arguments, arguments.Timeout.Value);
                Thread.Sleep(4000);
                arguments.Search.Value = "password";
                arguments.By.Value = "name";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                Thread.Sleep(2000);
                SeleniumManager.CurrentWrapper.TypeText(arguments.pword.Value, arguments, arguments.Timeout.Value);
                Thread.Sleep(2000);
                SeleniumManager.CurrentWrapper.PressKey("enter", arguments, arguments.Timeout.Value);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error occured while opening new selenium instance. Message: {ex.Message}", ex);
            }
        }
}
    }