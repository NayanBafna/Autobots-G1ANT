using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using G1ANT.Language;

namespace G1ANT.Addon.Webex

{
    [Command(Name = "webex.login", Tooltip = "This command is used to login in to the webex meetings site.")]
    public class WebexLoginCommand : Command
    {
        public WebexLoginCommand(AbstractScripter scripter) : base(scripter)
        {

        }
        public class Arguments : SeleniumCommandArguments
        {
            [Argument(Required = true, Tooltip = "Enter the Login e-mail ID here")]
            public TextStructure email { get; set; }

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
                       "webex.com",
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
                arguments.Search.Value = "/html[1]/body[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/section[1]/nav[1]/div[1]/div[1]/ul[1]/li[8]/div[1]/a[1]";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                arguments.Search.Value = "/html[1]/body[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/section[1]/nav[1]/div[1]/div[1]/ul[1]/li[8]/div[1]/div[1]/div[1]/ul[1]/li[1]/div[1]/a[1]";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                arguments.Search.Value = "#sign-in > div.grid > div > form > div:nth-child(1) > div > div > input";
                arguments.By.Value = "cssselector";
                SeleniumManager.CurrentWrapper.TypeText(arguments.email.Value, arguments, arguments.Timeout.Value);
                SeleniumManager.CurrentWrapper.PressKey("enter", arguments, arguments.Timeout.Value);
                arguments.Search.Value = "#sign-in > div.grid > div > form > div.el-form-item.margin-top > div > div > input";
                arguments.By.Value = "cssselector";
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