using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using G1ANT.Language;

namespace G1ANT.Addon.Telegram
{
    [Command(Name = "telegram.channelinfo", Tooltip = "This command is used for viewing channel info in telegram account.")]
    public class TelegramChannelInfoCommand : Command
    {
        public TelegramChannelInfoCommand(AbstractScripter scripter) : base(scripter)
        {

        }
        public class Arguments : SeleniumCommandArguments
        {

            [Argument(DefaultVariable = "timeoutselenium", Tooltip = "Specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed")]
            public override TimeSpanStructure Timeout { get; set; } = new TimeSpanStructure(SeleniumSettings.SeleniumTimeout);
            [Argument(Tooltip = "Name of a variable where the value of a specified attribute will be stored")]
            public VariableStructure Result { get; set; } = new VariableStructure("result");
        }

        public void Execute(Arguments arguments, string attributeValue)
        {
            try
            {
                arguments.Search.Value = "/html/body/div[1]/div[2]/div/div[1]/div[2]/div/div[1]/ul/li[1]/a";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                System.Threading.Thread.Sleep(6000);
                arguments.Search.Value = "/html/body/div[1]/div[1]/div/div/div[2]/div/div[2]/a";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                System.Threading.Thread.Sleep(6000);
                

                Scripter.Variables.SetVariableValue(arguments.Result.Value, new TextStructure(attributeValue));

            }

            catch (Exception ex)
            {
                throw new ApplicationException($"Error occured while opening new selenium instance. Message: {ex.Message}", ex);
            }
        }
    }
}