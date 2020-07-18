using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using G1ANT.Language;

namespace G1ANT.Addon.Quora
{
    [Command(Name ="quora.askquestion",Tooltip ="This command is used to ask question on quora's site")]
    class QuoraAskQuestionCommand : Command
    {
        public QuoraAskQuestionCommand(AbstractScripter scripter) : base(scripter)
        {

        }

        public class Arguments : SeleniumCommandArguments
        {
            [Argument(Required = true, Tooltip = "Enter your question here")]
            public TextStructure question { get; set; } = new TextStructure("question");

            [Argument(Tooltip = "Enter your link here")]
            public TextStructure link { get; set; } = new TextStructure("");

            [Argument(DefaultVariable = "timeoutselenium", Tooltip = "Specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed")]
            public override TimeSpanStructure Timeout { get; set; } = new TimeSpanStructure(SeleniumSettings.SeleniumTimeout);

        }
        
        public void Execute(Arguments arguments)
        {
            try
            {
                Thread.Sleep(5000);
                arguments.Search.Value = "//span[contains(text(),'What is your question or link?')]";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                Thread.Sleep(3000);
                arguments.Search.Value = "//html//body//div//div//div//div//div//div//div//div//div//div//div//div//div//div//div//div//div//div//div//div//div//div//textarea";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                SeleniumManager.CurrentWrapper.TypeText(arguments.question.Value, arguments, arguments.Timeout.Value);
                Thread.Sleep(3000);
                if (arguments.link.Value != null)
                {
                    arguments.Search.Value = "//div[@placeholder='Optional: include a link that gives context']//div//input[@placeholder='Optional: include a link that gives context']";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                    SeleniumManager.CurrentWrapper.TypeText(arguments.link.Value, arguments, arguments.Timeout.Value);
                    Thread.Sleep(2000);

                }
                else
                {
                    RobotMessageBox.Show("You have not provided any optional link");
                }
                    arguments.Search.Value = "//span[contains(text(),'Add Question')]";
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
