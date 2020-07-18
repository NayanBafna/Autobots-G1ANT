using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using G1ANT.Language;

namespace G1ANT.Addon.Quora
{
    [Command(Name ="quora.getquestions",Tooltip ="This command is used to get all the questions for you to Answer")]
    class QuoraGetQuestionsCommand : Command
    {
        public QuoraGetQuestionsCommand(AbstractScripter scripter) : base(scripter)
        {

        }

        public class Arguments : SeleniumCommandArguments
        {
            [Argument(DefaultVariable = "timeoutselenium", Tooltip = "Specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed")]
            public override TimeSpanStructure Timeout { get; set; } = new TimeSpanStructure(SeleniumSettings.SeleniumTimeout);

            [Argument(Tooltip = "Name of a variable where the value of a specified attribute will be stored")]
            public VariableStructure result { get; set; } = new VariableStructure("result");

            [Argument(Required = true, Tooltip ="Enter what kind of questions you want to answer")]
            public TextStructure kind { get; set; }
        }
        public void Execute(Arguments arguments)
        {try
            {
                Thread.Sleep(7000);
                arguments.Search.Value = "//div[@class='q-text qu-fontSize--button qu-medium'][contains(text(),'Answer')]";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                Thread.Sleep(5000);

                if (arguments.kind.Value == "Answer requests")
                {
                    arguments.Search.Value = "//div[contains(text(),'Answer requests')]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                    Thread.Sleep(5000);
                    arguments.Search.Value = "//div[@class='q-flex qu-px--large qu-py--medium qu-bg--white qu-alignItems--center qu-justifyContent--center qu-textAlign--center']";
                    arguments.By.Value = "xpath";

                }

                else if (arguments.kind.Value == "Answer later")
                {
                    arguments.Search.Value = "//div[contains(text(),'Answer later')]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                    Thread.Sleep(5000);
                    arguments.Search.Value = "//div[@class='q-flex qu-px--large qu-py--medium qu-bg--gray qu-alignItems--center qu-justifyContent--center qu-textAlign--center']";
                    arguments.By.Value = "xpath";

                }
                else
                {
                    arguments.Search.Value = "//div[contains(text(),'Questions for you')]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                    Thread.Sleep(5000);
                    arguments.Search.Value = "//body[@class='q-platform--desktop']/div/div/div[@class='q-box']/div[@class='q-box']/div[@class='q-box']/div[@class='q-text qu-display--flex qu-px--large qu-pb--large qu-flexDirection--row qu-fontSize--regular']/div[2]/div[1]/div[1]";
                    arguments.By.Value = "xpath";
                }
                var AttributeValue =SeleniumManager.CurrentWrapper.GetTextValue(arguments, arguments.Timeout.Value);

                Scripter.Variables.SetVariableValue(arguments.result.Value, new TextStructure(AttributeValue));
            }

            catch (Exception ex)
            {
                throw new ApplicationException($"Error occured while opening new selenium instance. Message: {ex.Message}", ex);
            }
        }

    }
}
