using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using G1ANT.Language;

namespace G1ANT.Addon.Facebook
{
    [Command(Name ="facebook.sendmessage",Tooltip ="This command is used to send message to any person on facebook")]
    class FacebookSendMessageCommand : Command
    {
        public FacebookSendMessageCommand(AbstractScripter scripter) : base(scripter)
        {

        }
        
        public class Arguments : SeleniumCommandArguments
        {
            [Argument(Required =true, Tooltip ="Enter the unique id of the person whom to send the message")]
            public TextStructure id { get; set; }

            [Argument(Required = true, Tooltip = "Enter the message here")]
            public TextStructure message { get; set; }

            [Argument(DefaultVariable = "timeoutselenium", Tooltip = "Specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed")]
            public override TimeSpanStructure Timeout { get; set; } = new TimeSpanStructure(SeleniumSettings.SeleniumTimeout);
        }
        public void Execute (Arguments arguments)
        {
            try
            {
                Thread.Sleep(7000);
                var baseURL = String.Format("https://www.facebook.com/", arguments.Timeout.Value);
                var URL = String.Concat(baseURL, arguments.id.Value);
                SeleniumManager.CurrentWrapper.NewTab(arguments.Timeout.Value, URL, true);
                Thread.Sleep(15000);
                arguments.Search.Value = "//span[contains(text(),'Message')]";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                Thread.Sleep(5000);
                arguments.Search.Value = "//body/div/div/div/div/div/div/div/div/div/div/div/div/div/div/div/div/div/form/div/div/div/div/div/div/div/div/div[2]/div[1]";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                Thread.Sleep(5000);
                SeleniumManager.CurrentWrapper.TypeText(arguments.message.Value,arguments, arguments.Timeout.Value);
                Thread.Sleep(3000);
                arguments.Search.Value = "//body/div/div/div/div/div/div/div/div/div/div/div/div/div/div/div/div/div/form/div/div/span[2]/div[1]//*[local-name()='svg']";
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
