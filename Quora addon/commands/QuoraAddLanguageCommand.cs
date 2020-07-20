using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using G1ANT.Language;

namespace G1ANT.Addon.Quora
{
    [Command(Name = "quora.addlanguage", Tooltip = "This Command is used to add language on Quora's site")]
    class QuoraAddLanguageCommand : Command
    {
        public QuoraAddLanguageCommand(AbstractScripter scripter) : base(scripter)
        {

        }

        public class Arguments : SeleniumCommandArguments
        {
            [Argument(DefaultVariable = "timeoutselenium", Tooltip = "Specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed")]
            public override TimeSpanStructure Timeout { get; set; } = new TimeSpanStructure(SeleniumSettings.SeleniumTimeout);

            [Argument(Required = true, Tooltip = "Enter language name to add")]
            public TextStructure language { set; get; }

        }
        public void Execute(Arguments arguments)
        {
            try
            {
                Thread.Sleep(7000);
                arguments.Search.Value = "//body/div/div/div/div/div/div/div[5]/div[1]/div[1]/div[1]/div[1]/div[1]/span[1]/span[1]//*[local-name()='svg']";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                Thread.Sleep(4000);
                arguments.Search.Value = "//div[contains(text(),'Add language')]";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                Thread.Sleep(8000);
                arguments.Search.Value = "//input[@placeholder='Search for a language']";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                Thread.Sleep(2000);
                SeleniumManager.CurrentWrapper.TypeText(arguments.language.Value, arguments, arguments.Timeout.Value);
                Thread.Sleep(2000);
                SeleniumManager.CurrentWrapper.PressKey("enter", arguments, arguments.Timeout.Value);
                Thread.Sleep(3000);
                arguments.Search.Value = "//input[@class='submit_button form_submit_button']";
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
    