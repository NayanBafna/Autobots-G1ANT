using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using G1ANT.Language;

namespace G1ANT.Addon.Yatra
{
    [Command(Name = "yatra.login", Tooltip = "This command is used to login yatra site")]
    class YatraLoginCommand : Command
    {
        public YatraLoginCommand(AbstractScripter scripter) : base(scripter)
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
                       "yatra.com",
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

                Thread.Sleep(20000);
                arguments.Search.Value = "//a[contains(text(),'My Account')]";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                Thread.Sleep(3000);
                arguments.Search.Value = "//html//body//div//div//div//div//div//div//div//ul//li//div//div//div//div//ul//li//a[contains(text(),'Login')]";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                Thread.Sleep(3000);
                arguments.Search.Value = "//input[@placeholder='Email ID / Mobile Number']";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                Thread.Sleep(2000);
                SeleniumManager.CurrentWrapper.TypeText(arguments.email.Value, arguments, arguments.Timeout.Value);
                Thread.Sleep(4000);
                arguments.Search.Value = "//form[@name='login-form']//button[contains(text(),'Continue')]";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                Thread.Sleep(3000);
                arguments.Search.Value = "//input[@placeholder='Enter your password']";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                Thread.Sleep(2000);
                SeleniumManager.CurrentWrapper.TypeText(arguments.pword.Value, arguments, arguments.Timeout.Value);
                Thread.Sleep(3000);
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
