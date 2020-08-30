using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using G1ANT.Language;

namespace G1ANT.Addon.Instagram
{
    [Command(Name = "instagram.acceptrequests", Tooltip = "This command is used to accept follow request")]
    class InstagramAcceptRequestsCommand : Command
    {
        public InstagramAcceptRequestsCommand(AbstractScripter scripter) : base(scripter)
        {

        }
        public class Arguments : SeleniumCommandArguments
        {
            [Argument(DefaultVariable = "timeoutselenium", Tooltip = "Specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed")]
            public override TimeSpanStructure Timeout { get; set; } = new TimeSpanStructure(SeleniumSettings.SeleniumTimeout);

            [Argument(Required = true, Tooltip = " Enter the number from 1 to 5 to provide how many follow request to be accepted")]
            public IntegerStructure number { get; set; } = new IntegerStructure("1");
        }
        public void Execute(Arguments arguments)
        {
            try
            {
                Thread.Sleep(8000);
                arguments.Search.Value = "/html[1]/body[1]/div[1]/section[1]/nav[1]/div[2]/div[1]/div[1]/div[3]/div[1]/div[4]/a[1]/*[local-name()='svg'][1]";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                arguments.Search.Value = "/html[1]/body[1]/div[1]/section[1]/nav[1]/div[2]/div[1]/div[1]/div[3]/div[1]/div[4]/div[1]/div[1]/div[2]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                Thread.Sleep(5000);
                if (arguments.number.Value == 2)
                {
                    arguments.Search.Value = "/html[1]/body[1]/div[1]/section[1]/nav[1]/div[2]/div[1]/div[1]/div[3]/div[1]/div[4]/div[1]/div[1]/div[2]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[3]/div[1]/div[1]/button[1]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                    Thread.Sleep(3000);
                    arguments.Search.Value = "/html[1]/body[1]/div[1]/section[1]/nav[1]/div[2]/div[1]/div[1]/div[3]/div[1]/div[4]/div[1]/div[1]/div[2]/div[2]/div[1]/div[1]/div[1]/div[1]/div[2]/div[3]/div[1]/div[1]/button[1]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                }
                else if (arguments.number.Value == 3)
                {
                    arguments.Search.Value = "/html[1]/body[1]/div[1]/section[1]/nav[1]/div[2]/div[1]/div[1]/div[3]/div[1]/div[4]/div[1]/div[1]/div[2]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[3]/div[1]/div[1]/button[1]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                    Thread.Sleep(3000);
                    arguments.Search.Value = "/html[1]/body[1]/div[1]/section[1]/nav[1]/div[2]/div[1]/div[1]/div[3]/div[1]/div[4]/div[1]/div[1]/div[2]/div[2]/div[1]/div[1]/div[1]/div[1]/div[2]/div[3]/div[1]/div[1]/button[1]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                    Thread.Sleep(3000);
                    arguments.Search.Value = "/html[1]/body[1]/div[1]/section[1]/nav[1]/div[2]/div[1]/div[1]/div[3]/div[1]/div[4]/div[1]/div[1]/div[2]/div[2]/div[1]/div[1]/div[1]/div[1]/div[3]/div[3]/div[1]/div[1]/button[1]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                }
                else if (arguments.number.Value == 4)
                {
                    arguments.Search.Value = "/html[1]/body[1]/div[1]/section[1]/nav[1]/div[2]/div[1]/div[1]/div[3]/div[1]/div[4]/div[1]/div[1]/div[2]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[3]/div[1]/div[1]/button[1]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                    Thread.Sleep(3000);
                    arguments.Search.Value = "/html[1]/body[1]/div[1]/section[1]/nav[1]/div[2]/div[1]/div[1]/div[3]/div[1]/div[4]/div[1]/div[1]/div[2]/div[2]/div[1]/div[1]/div[1]/div[1]/div[2]/div[3]/div[1]/div[1]/button[1]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                    Thread.Sleep(3000);
                    arguments.Search.Value = "/html[1]/body[1]/div[1]/section[1]/nav[1]/div[2]/div[1]/div[1]/div[3]/div[1]/div[4]/div[1]/div[1]/div[2]/div[2]/div[1]/div[1]/div[1]/div[1]/div[3]/div[3]/div[1]/div[1]/button[1]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                    Thread.Sleep(3000);
                    arguments.Search.Value = "/html[1]/body[1]/div[1]/section[1]/nav[1]/div[2]/div[1]/div[1]/div[3]/div[1]/div[4]/div[1]/div[1]/div[2]/div[2]/div[1]/div[1]/div[1]/div[1]/div[4]/div[3]/div[1]/div[1]/button[1]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                }
                else if (arguments.number.Value == 5)
                {
                    arguments.Search.Value = "/html[1]/body[1]/div[1]/section[1]/nav[1]/div[2]/div[1]/div[1]/div[3]/div[1]/div[4]/div[1]/div[1]/div[2]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[3]/div[1]/div[1]/button[1]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                    Thread.Sleep(3000);
                    arguments.Search.Value = "/html[1]/body[1]/div[1]/section[1]/nav[1]/div[2]/div[1]/div[1]/div[3]/div[1]/div[4]/div[1]/div[1]/div[2]/div[2]/div[1]/div[1]/div[1]/div[1]/div[2]/div[3]/div[1]/div[1]/button[1]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                    Thread.Sleep(3000);
                    arguments.Search.Value = "/html[1]/body[1]/div[1]/section[1]/nav[1]/div[2]/div[1]/div[1]/div[3]/div[1]/div[4]/div[1]/div[1]/div[2]/div[2]/div[1]/div[1]/div[1]/div[1]/div[3]/div[3]/div[1]/div[1]/button[1]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                    Thread.Sleep(3000);
                    arguments.Search.Value = "/html[1]/body[1]/div[1]/section[1]/nav[1]/div[2]/div[1]/div[1]/div[3]/div[1]/div[4]/div[1]/div[1]/div[2]/div[2]/div[1]/div[1]/div[1]/div[1]/div[4]/div[3]/div[1]/div[1]/button[1]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                    Thread.Sleep(3000);
                    arguments.Search.Value = "/html[1]/body[1]/div[1]/section[1]/nav[1]/div[2]/div[1]/div[1]/div[3]/div[1]/div[4]/div[1]/div[1]/div[2]/div[2]/div[1]/div[1]/div[1]/div[1]/div[5]/div[3]/div[1]/div[1]/button[1]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                }
                else
                {
                    arguments.Search.Value = "/html[1]/body[1]/div[1]/section[1]/nav[1]/div[2]/div[1]/div[1]/div[3]/div[1]/div[4]/div[1]/div[1]/div[2]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[3]/div[1]/div[1]/button[1]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error occured while opening new selenium instance. Message: {ex.Message}", ex);
            }
        }
    }
}


