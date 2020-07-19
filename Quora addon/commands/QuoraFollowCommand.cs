using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using G1ANT.Language;

namespace G1ANT.Addon.Quora
{
    [Command(Name ="quora.follow",Tooltip ="This command is used to follow any individual on Quora's site")]
    class QuoraFollowCommand : Command
    {
        public QuoraFollowCommand(AbstractScripter scripter) : base(scripter)
        {

        }

        public class Arguments : SeleniumCommandArguments
        {

            [Argument(Required = true, Tooltip = "Enter person's name and id here seperated each word by '-'")]
            public TextStructure nameid { get; set; }

            [Argument(DefaultVariable = "timeoutselenium", Tooltip = "Specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed")]
            public override TimeSpanStructure Timeout { get; set; } = new TimeSpanStructure(SeleniumSettings.SeleniumTimeout);

        }

        public void Execute(Arguments arguments)
        {
            try
            {
                Thread.Sleep(5000);
                var baseURL = String.Format("https://www.quora.com/profile/", arguments.Timeout.Value);
                var URL = String.Concat(baseURL, arguments.nameid.Value);
                SeleniumManager.CurrentWrapper.NewTab(arguments.Timeout.Value, URL, true);
                Thread.Sleep(8000);
                arguments.Search.Value = "//div[contains(text(),'Follow')]";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value, true);


            }

            catch (Exception ex)
            {
                throw new ApplicationException($"Error occured while opening new selenium instance. Message: {ex.Message}", ex);
            }
        }


    }
}
