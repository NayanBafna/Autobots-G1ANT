using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using G1ANT.Language;

namespace G1ANT.Addon.Quora
{
    [Command(Name ="quora.changelanguage",Tooltip ="This command is used to change language of Quora's site")]
    class QuoraChangeLanguageCommand : Command
    {
        public QuoraChangeLanguageCommand(AbstractScripter scripter) : base(scripter)
        {

        }

        public class Arguments : SeleniumCommandArguments
        {
            [Argument(DefaultVariable = "timeoutselenium", Tooltip = "Specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed")]
            public override TimeSpanStructure Timeout { get; set; } = new TimeSpanStructure(SeleniumSettings.SeleniumTimeout);

            [Argument(Required =true, Tooltip ="Enter language to change to")]
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
                
                if (arguments.language.Value == "Hindi")
                {
                    arguments.Search.Value = "//div[@class='q-fixed qu-fullX qu-zIndex--header qu-bg--white qu-borderBottom qu-boxShadow--medium']//a[2]//div[1]//div[2]//div[1]//div[1]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);

                }
                
                else if (arguments.language.Value == "German")
                {
                    arguments.Search.Value = "//div[contains(text(),'Deutsch')]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);

                }
                else if (arguments.language.Value == "Spanish")
                {
                    arguments.Search.Value = "//div[contains(text(),'Español')]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);

                }
                else if (arguments.language.Value == "French")
                {
                    arguments.Search.Value = "//div[contains(text(),'Français')]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);

                }
                else
                {
                    arguments.Search.Value = "//div[contains(text(),'English')]";
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
