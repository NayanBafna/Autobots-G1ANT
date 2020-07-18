using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using G1ANT.Addon.twitter;
using G1ANT.Language;
using OpenQA.Selenium;
using OpenQA.Selenium.Internal;
using System.Threading;
using Keys = System.Windows.Forms.Keys;


namespace G1ANT.Addon.twitter
{
    [Command(Name = "twitter.follow", Tooltip = "This command is used to follow any profile on the twitter site.")]
    class TwitterFollowCommand : Command
    {
        public TwitterFollowCommand(AbstractScripter scripter) : base(scripter)
        {

        }

        public class Arguments : SeleniumCommandArguments
        {
            [Argument(Required = true, Tooltip = "Enter person's unique username here")]
            public TextStructure username { get; set; }

            [Argument(DefaultVariable = "timeoutselenium", Tooltip = "Specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed")]
            public override TimeSpanStructure Timeout { get; set; } = new TimeSpanStructure(SeleniumSettings.SeleniumTimeout);
            

            [Argument(Tooltip = "By default, waits until the webpage fully loads")]
            public BooleanStructure NoWait { get; set; } = new BooleanStructure(false);
        }
        public void Execute(Arguments arguments)
        {
            try
            {

                var baseURL = String.Format("https://www.twitter.com/", arguments.Timeout.Value, arguments.NoWait.Value);
                var URL = String.Concat(baseURL, arguments.username.Value);
                SeleniumManager.CurrentWrapper.NewTab(arguments.Timeout.Value, URL, true);
                System.Threading.Thread.Sleep(10000);
                arguments.Search.Value = "/html[1]/body[1]/div[1]/div[1]/div[1]/div[2]/main[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[3]/div[1]/div[1]/div[1]/span[1]/span[1]";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error occured while opening new selenium instance. Message: {ex.Message}", ex);
            }

        }


    }
}