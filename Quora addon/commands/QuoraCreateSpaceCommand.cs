using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using G1ANT.Language;
using OpenQA.Selenium.Internal;

namespace G1ANT.Addon.Quora
{
    [Command(Name = "quora.createspace", Tooltip = "This command is used to create spaces in quora")]
    class QuoraCreateSpaceCommand : Command
    {
        public QuoraCreateSpaceCommand(AbstractScripter scripter) : base(scripter)
        {

        }

        public class Arguments : SeleniumCommandArguments
        {
            [Argument(Required = true, Tooltip = "Enter a unique name for your space")]
            public TextStructure name { get; set; }
            [Argument(Required = true, Tooltip = "Enter 1-line description for your space")]
            public TextStructure desc { get; set; }

            [Argument(DefaultVariable = "timeoutselenium", Tooltip = "Specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed")]
            public override TimeSpanStructure Timeout { get; set; } = new TimeSpanStructure(SeleniumSettings.SeleniumTimeout);
        }

        public void Execute(Arguments arguments)
        {

            try
            {
                arguments.Search.Value = "//div[@class='q-click-wrapper qu-display--block qu-color--gray qu-tapHighlight--white qu-cursor--pointer']//div[@class='q-relative qu-display--flex qu-color--gray qu-alignItems--center qu-justifyContent--center qu-px--medium qu-hover--bg--darken']";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                Thread.Sleep(5000);
                arguments.Search.Value = "//a[contains(@class,'qu-active--bg--darken qu-active--textDecoration--none qu-focus--bg--darken qu-focus--textDecoration--none qu-display--inline-block qu-borderRadius--pill qu-textAlign--center qu-cursor--pointer qu-whiteSpace--nowrap qu-userSelect--none qu-hover--bg--darken qu-hover--textDecoration--none')]";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                Thread.Sleep(2000);
                arguments.Search.Value = "//div[contains(@class,'q-box qu-borderAll qu-borderRadius--small qu-boxShadow--small qu-bg--white')]//button[1]";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                Thread.Sleep(2000);
                arguments.Search.Value = "//input[contains(@placeholder,'Enter a name for your Space')]";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                SeleniumManager.CurrentWrapper.TypeText(arguments.name.Value, arguments, arguments.Timeout.Value);
                Thread.Sleep(2000);
                arguments.Search.Value = "//input[contains(@placeholder,'1-line description of your Space')]";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                SeleniumManager.CurrentWrapper.TypeText(arguments.desc.Value, arguments, arguments.Timeout.Value);
                arguments.Search.Value = "//body/div/div/div/div/div/div/div/div/div/div/div/div/div/span/button[1]";
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
