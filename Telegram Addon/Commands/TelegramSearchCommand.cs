using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using G1ANT.Language;

namespace G1ANT.Addon.Telegram
{
    [Command(Name = "telegram.search", Tooltip = "This command is used to search on the telegram site.")]
    public class TelegramSearchCommand : Command
    {
        public TelegramSearchCommand(AbstractScripter scripter) : base(scripter)
        {

        }
        public class Arguments : SeleniumCommandArguments
        {
            [Argument(Name = "search", Required = true, Tooltip = "Enter the value to search here")]
            public TextStructure searchthis { get; set; }


            [Argument(DefaultVariable = "timeoutselenium", Tooltip = "Specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed")]
            public override TimeSpanStructure Timeout { get; set; } = new TimeSpanStructure(SeleniumSettings.SeleniumTimeout);
        }

        public void Execute(Arguments arguments)
        {
            try
            {

                arguments.Search.Value = "/html/body/div[1]/div[2]/div/div[1]/div[1]/div/input";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);

                SeleniumManager.CurrentWrapper.TypeText(arguments.searchthis.Value, arguments, arguments.Timeout.Value);

                SeleniumManager.CurrentWrapper.PressKey("enter", arguments, arguments.Timeout.Value);

            }

            catch (Exception ex)
            {
                throw new ApplicationException($"Error occured while opening new selenium instance. Message: {ex.Message}", ex);
            }
        }
    }
}
