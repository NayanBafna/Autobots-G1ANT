using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using G1ANT.Language;

namespace G1ANT.Addon.Quora
{ 
    [Command(Name ="quora.sendnewmessage", Tooltip ="This command is used to send new message")]
    class QuoraSendNewMessageCommand : Command
    {
        public QuoraSendNewMessageCommand(AbstractScripter scripter) : base(scripter)
        {

        }

        public class Arguments : SeleniumCommandArguments
        {
            [Argument(DefaultVariable = "timeoutselenium", Tooltip = "Specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed")]
            public override TimeSpanStructure Timeout { get; set; } = new TimeSpanStructure(SeleniumSettings.SeleniumTimeout);

            [Argument(Required =true, Tooltip ="Enter Reciever Name here")]
            public TextStructure name { get; set; }

            [Argument(Required =true, Tooltip ="Enter message you want to share")]
            public TextStructure message { get; set; }

        }

        public void Execute(Arguments arguments)
        {
            try
            {
                Thread.Sleep(5000);
                arguments.Search.Value = "//body/div/div/div/div/div/div/div/div/div/div/div/div/div/div/div/img[1]";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                Thread.Sleep(3000);
                arguments.Search.Value = "//div[contains(text(),'Messages')]";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                Thread.Sleep(4000);
                arguments.Search.Value = "//a[contains(text(),'New Message')]";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                Thread.Sleep(5000);
                arguments.Search.Value = "//input[@placeholder='Enter a name']";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                SeleniumManager.CurrentWrapper.TypeText(arguments.name.Value, arguments, arguments.Timeout.Value);
                Thread.Sleep(4000);
                arguments.Search.Value = "//textarea[@placeholder='Type a message...']";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                SeleniumManager.CurrentWrapper.TypeText(arguments.message.Value, arguments, arguments.Timeout.Value);
                Thread.Sleep(4000);
                arguments.Search.Value = "//a[contains(text(),'Send')]";
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
