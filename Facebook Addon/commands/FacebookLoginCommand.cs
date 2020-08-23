using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using G1ANT.Language;

namespace G1ANT.Addon.Facebook
{
    [Command(Name ="facebook.login", Tooltip = "This command is used to login")]
    class FacebookLoginCommand : Command
    {
        public FacebookLoginCommand(AbstractScripter scripter) : base(scripter)
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
                       "facebook.com",
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
                arguments.Search.Value = "//input[@placeholder='Email address or phone number']";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.TypeText(arguments.email.Value, arguments, arguments.Timeout.Value);
                arguments.Search.Value = "//input[@placeholder='Password']";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.TypeText(arguments.pword.Value, arguments, arguments.Timeout.Value);
                SeleniumManager.CurrentWrapper.PressKey("enter", arguments, arguments.Timeout.Value);
                var len = SeleniumManager.CurrentWrapper.RunScript("return document.getElementsByClassName(\"captcha -internal\").length");
                if (len == "1")
                {
                    RobotMessageBox.Show("Captcha detected, please solve the captcha");
                }
            }

            catch (Exception ex)
            {
                throw new ApplicationException($"Error occured while opening new selenium instance. Message: {ex.Message}", ex);
            }

        }
    }
}
