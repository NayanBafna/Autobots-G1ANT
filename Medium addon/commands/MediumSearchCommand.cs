using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using G1ANT.Language;

namespace G1ANT.Addon.Medium
{
    [Command(Name ="medium.search", Tooltip ="This command is used to search anything on medium's site")]
    class MediumSearchCommand : Command
    {
        public MediumSearchCommand(AbstractScripter scripter) : base(scripter)
        {

        }
        public class Arguments : SeleniumCommandArguments
        {
            [Argument(Required = true, Tooltip = "Enter the value to search for")]
            public TextStructure searchtext { get; set; }

            [Argument(DefaultVariable = "timeoutselenium", Tooltip = "Specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed")]
            public override TimeSpanStructure Timeout { get; set; } = new TimeSpanStructure(SeleniumSettings.SeleniumTimeout);

            [Argument(Tooltip = "Enter type of search: Stories, People, Publications or Tags")]
            public TextStructure type { get; set; } = new TextStructure("Stories");
        }

        public void Execute(Arguments arguments)
        {
            try
            {
                Thread.Sleep(8000);
                arguments.Search.Value = "//a[1]//span[1]//span[1]//*[local-name()='svg']";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                Thread.Sleep(4000);
                arguments.Search.Value = "//input[@placeholder='Search Medium']";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                Thread.Sleep(3000);
                SeleniumManager.CurrentWrapper.TypeText(arguments.searchtext.Value, arguments, arguments.Timeout.Value);
                SeleniumManager.CurrentWrapper.PressKey("enter", arguments, arguments.Timeout.Value);
                Thread.Sleep(4000);
                if (arguments.type.Value == "People")
                {
                    arguments.Search.Value = "//a[contains(text(),'People')]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                }
                else if (arguments.type.Value == "Publications")
                {
                    arguments.Search.Value = "//a[contains(text(),'Publications')]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                }
                else if (arguments.type.Value == "Tags")
                {
                    arguments.Search.Value = "//a[contains(text(),'Tags')]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                }
                else
                {
                    arguments.Search.Value = "//a[contains(text(),'Stories')]";
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
