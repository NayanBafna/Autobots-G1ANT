using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using G1ANT.Language;

namespace G1ANT.Addon.Quora
{
    [Command(Name ="quora.getnotification",Tooltip ="This command is used to get all notification")]
    class QuoraGetNotificationsCommand : Command
    {
        public QuoraGetNotificationsCommand(AbstractScripter scripter) : base(scripter)
        {

        }

        public class Arguments : SeleniumCommandArguments
        {
            [Argument(Required =true,Tooltip ="Enter to get specific notifications")]
            public TextStructure note { get; set; }

            [Argument(DefaultVariable = "timeoutselenium", Tooltip = "Specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed")]
            public override TimeSpanStructure Timeout { get; set; } = new TimeSpanStructure(SeleniumSettings.SeleniumTimeout);
           
            [Argument(Tooltip = "Name of a variable where the value of a specified attribute will be stored")]
            public VariableStructure result { get; set; } = new VariableStructure("result");
        }

        public void Execute(Arguments arguments)
        {
            try
            {
                Thread.Sleep(5000);
                arguments.Search.Value = "//div[contains(text(),'Notifications')]";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);

                if (arguments.note.Value == "Stories")
                {
                    Thread.Sleep(5000);
                    arguments.Search.Value = "//span[contains(text(),'Stories')]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                }
                else if (arguments.note.Value == "Questions")
                {
                    Thread.Sleep(5000);
                    arguments.Search.Value = "//span[contains(text(),'Questions')]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                }
                else if (arguments.note.Value == "Spaces")
                {
                    Thread.Sleep(5000);
                    arguments.Search.Value = "//span[contains(text(),'Spaces')]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                }
                else if (arguments.note.Value =="Subscriptions")
                {
                    Thread.Sleep(5000);
                    arguments.Search.Value = "//span[contains(text(),'Subscriptions')]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                }
                else if (arguments.note.Value == "Comments")
                {
                    Thread.Sleep(5000);
                    arguments.Search.Value = "//span[contains(text(),'Comments')]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                }
                else if (arguments.note.Value == "Upvote")
                {
                    Thread.Sleep(5000);
                    arguments.Search.Value = "//span[contains(text(),'Upvotes')]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                }
                else if (arguments.note.Value == "Your Content")
                {
                    Thread.Sleep(5000);
                    arguments.Search.Value = "//span[contains(text(),'Your Content')]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                }
                else if (arguments.note.Value == "Your Profile")
                {
                    Thread.Sleep(5000);
                    arguments.Search.Value = "//span[contains(text(),'Your Profile')]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                }
                else if (arguments.note.Value =="Announcements")
                {
                    Thread.Sleep(5000);
                    arguments.Search.Value = "//span[contains(text(),'Announcements')]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                }
                else
                {
                    Thread.Sleep(5000);
                    arguments.Search.Value = "//div[contains(text(),'All Notifications')]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                }


                Thread.Sleep(5000);
                arguments.Search.Value = "//div[@class='q-flex qu-px--large qu-py--medium qu-bg--white qu-alignItems--center qu-justifyContent--center qu-textAlign--center']";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                var attributeValue = SeleniumManager.CurrentWrapper.GetTextValue(
                 arguments,
                 arguments.Timeout.Value);


                Scripter.Variables.SetVariableValue(arguments.result.Value, new TextStructure(attributeValue));

            }

            catch (Exception ex)
            {
                throw new ApplicationException($"Error occured while opening new selenium instance. Message: {ex.Message}", ex);
            }
        }
    }
}
