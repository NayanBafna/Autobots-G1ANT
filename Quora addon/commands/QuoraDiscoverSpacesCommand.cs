using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using G1ANT.Language;

namespace G1ANT.Addon.Quora
{
    [Command(Name = "quora.discoverspaces", Tooltip = "This command is used to get the spaces available on quora's sites")]
    class QuoraDiscoverSpacesCommand : Command
    {
        public QuoraDiscoverSpacesCommand(AbstractScripter scripter) : base(scripter)
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
                Thread.Sleep(7000);
                arguments.Search.Value = "//div[@class='q-click-wrapper qu-display--block qu-color--gray qu-tapHighlight--white qu-cursor--pointer']//div[@class='q-relative qu-display--flex qu-color--gray qu-alignItems--center qu-justifyContent--center qu-px--medium qu-hover--bg--darken']";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                Thread.Sleep(4000);
                arguments.Search.Value = "//a[contains(@class,'qu-active--bg--darken qu-active--textDecoration--none qu-focus--bg--darken qu-focus--textDecoration--none qu-display--inline-block qu-borderRadius--pill qu-textAlign--center qu-cursor--pointer qu-whiteSpace--nowrap qu-userSelect--none qu-hover--bg--darken qu-hover--textDecoration--none')]";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                Thread.Sleep(5000);
                arguments.Search.Value = "//button[2]";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                Thread.Sleep(5000);
                arguments.Search.Value = "//body[contains(@class,'q-platform--desktop')]/div/div/div[contains(@class,'q-box')]/div[contains(@class,'q-box')]/div[contains(@class,'q-text qu-display--flex qu-px--large qu-pb--large qu-flexDirection--row qu-fontSize--regular')]/div[contains(@class,'q-box')]/div[contains(@class,'q-box')]/div[contains(@class,'q-box qu-mt--large qu-mr--n_small')]/div[2]";
                arguments.By.Value = "xpath";
              
                var AttributeValue = SeleniumManager.CurrentWrapper.GetTextValue(arguments,arguments.Timeout.Value);

                Scripter.Variables.SetVariableValue(arguments.result.Value, new TextStructure(AttributeValue));


            }

            catch (Exception ex)
            {
                throw new ApplicationException($"Error occured while opening new selenium instance. Message: {ex.Message}", ex);
            }
        }
    }
}
