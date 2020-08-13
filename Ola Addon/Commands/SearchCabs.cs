using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using G1ANT.Language;

namespace G1ANT.Addon.Ola
{
    [Command(Name = "ola.searchcabs", Tooltip = "This command is used to search cabs")]
    class QuoraLoginCommand : Command
    {

        public QuoraLoginCommand(AbstractScripter scripter) : base(scripter)
        {

        }
        public class Arguments : SeleniumCommandArguments
        {
            [Argument(Name = "current location", Required = true, Tooltip = "Enter your location here")]
            public TextStructure currentlocation { get; set; }

            [Argument(Name = "destination", Required = true, Tooltip = "Enter your destination here")]
            public TextStructure destination { get; set; }

            [Argument(DefaultVariable = "timeoutselenium", Tooltip = "Specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed")]
            public override TimeSpanStructure Timeout { get; set; } = new TimeSpanStructure(SeleniumSettings.SeleniumTimeout);

        }

        public void Execute(Arguments arguments)
        {
            try
            {
                SeleniumWrapper wrapper = SeleniumManager.CreateWrapper(
                       "chrome",
                       "olacabs.com",
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
                arguments.Search.Value = "/html/body/div/div/div[2]/div/div[2]";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.TypeText(arguments.currentlocation.Value, arguments, arguments.Timeout.Value);
                arguments.Search.Value = "/html/body/div/div/div[3]/div/div[2]";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.TypeText(arguments.destination.Value, arguments, arguments.Timeout.Value);
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