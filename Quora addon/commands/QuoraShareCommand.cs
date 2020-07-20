using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using G1ANT.Language;

namespace G1ANT.Addon.Quora
{
    [Command(Name ="quora.share",Tooltip ="This command is used to share any post on quora's site")]
    class QuoraShareCommand : Command
    {
        public QuoraShareCommand(AbstractScripter scripter) : base(scripter)
        {

        }

        public class Arguments : SeleniumCommandArguments
        {
            [Argument(DefaultVariable = "timeoutselenium", Tooltip = "Specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed")]
            public override TimeSpanStructure Timeout { get; set; } = new TimeSpanStructure(SeleniumSettings.SeleniumTimeout);

            [Argument(Required = true, Tooltip = "Enter a message to share with post")]
            public TextStructure text { set; get; }

        }
        public void Execute(Arguments arguments)
        {
            try
            {
                Thread.Sleep(7000);
                arguments.Search.Value = "//body[contains(@class,'q-platform--desktop')]/div/div/div[contains(@class,'q-box')]/div[contains(@class,'q-box')]/div[contains(@class,'q-box')]/div[contains(@class,'q-text qu-display--flex qu-px--large qu-pb--large qu-flexDirection--row qu-fontSize--regular')]/div[contains(@class,'q-box')]/div/div[2]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[2]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/span[1]/span[1]//*[local-name()='svg']";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                Thread.Sleep(4000);
                arguments.Search.Value = "//div[contains(@class,'modal_content modal_body')]//div//div[contains(@class,'QuoraShareEditor')]//div[contains(@class,'selector_input_interaction')]//div//textarea[contains(@placeholder,'Say something about this...')]";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                Thread.Sleep(2000);
                SeleniumManager.CurrentWrapper.TypeText(arguments.text.Value, arguments, arguments.Timeout.Value);
                Thread.Sleep(3000);
                arguments.Search.Value = "//div[contains(@class,'QuoraShareModal Modal')]//a[contains(@class,'submit_button modal_action')][contains(text(),'Share')]";
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
