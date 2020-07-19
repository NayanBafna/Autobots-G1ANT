using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using G1ANT.Language;

namespace G1ANT.Addon.Quora
{
    [Command(Name = "quora.getmessage", Tooltip = "This command is used to get all the messages")]
    class QuoraGetMessageCommand : Command
    {
        public QuoraGetMessageCommand(AbstractScripter scripter) : base(scripter)
        {

        }

        public class Arguments : SeleniumCommandArguments
        {
            [Argument(DefaultVariable = "timeoutselenium", Tooltip = "Specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed")]
            public override TimeSpanStructure Timeout { get; set; } = new TimeSpanStructure(SeleniumSettings.SeleniumTimeout);

            [Argument(Tooltip = "Enter a variable where the value of a specified attribute will be stored")]
            public VariableStructure result { get; set; } = new VariableStructure("result");
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
                arguments.Search.Value = "//div[@class='ModalMessagesThreadListEmptyState EmptyState']";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                var attributeValue = SeleniumManager.CurrentWrapper.GetTextValue(arguments, arguments.Timeout.Value);

                Scripter.Variables.SetVariableValue(arguments.result.Value, new TextStructure(attributeValue));

            }

            catch (Exception ex)
            {
                throw new ApplicationException($"Error occured while opening new selenium instance. Message: {ex.Message}", ex);
            }

        }





    }
}
