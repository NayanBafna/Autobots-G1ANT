using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using G1ANT.Language;

namespace G1ANT.Addon.Quora
{
    [Command(Name ="quora.downvote", Tooltip ="This command is used to downvote on quora's site")]
    class QuoraDownvoteCommand : Command
    {
        public QuoraDownvoteCommand(AbstractScripter scripter) : base(scripter)
        {

        }

        public class Arguments : SeleniumCommandArguments
        {
            [Argument(Required = true, Tooltip = "Enter what you want to downvote(Question or Answer)")]
            public TextStructure downvote { get; set; } = new TextStructure("Question");

            [Argument(DefaultVariable = "timeoutselenium", Tooltip = "Specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed")]
            public override TimeSpanStructure Timeout { get; set; } = new TimeSpanStructure(SeleniumSettings.SeleniumTimeout);

        }

        public void Execute(Arguments arguments)
        {
            try
            {
                Thread.Sleep(5000);
                arguments.Search.Value = "//body[contains(@class,'q-platform--desktop')]//div[contains(@class,'q-box')]//div[contains(@class,'q-box')]//div[contains(@class,'q-box')]//div[contains(@class,'q-box')]//div[2]//div[1]//div[1]//div[1]//div[1]//div[2]//div[1]//div[1]//div[1]//div[2]//div[1]//div[4]//div[3]//div[1]//div[1]//div[1]//div[1]//div[1]//div[1]//div[1]//div[1]//span[1]//span[1]//*[local-name()='svg']";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                Thread.Sleep(2000);
                
                if (arguments.downvote.Value == "Answer")
                {
                    arguments.Search.Value = "//div[contains(text(),'Downvote Answer')]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                }
                else
                {
                    arguments.Search.Value = "//div[contains(text(),'Downvote Question')]";
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
