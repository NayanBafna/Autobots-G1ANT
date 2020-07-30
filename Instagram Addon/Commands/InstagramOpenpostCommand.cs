using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using G1ANT.Language;

namespace G1ANT.Addon.Instagram
{
    [Command(Name = "instagram.openpost", Tooltip = "This command is used to open any post on instagram site.")]
    public class InstagramOpenpostCommand : Command
    {
        public InstagramOpenpostCommand(AbstractScripter scripter) : base(scripter)
        {

        }
        public class Arguments : SeleniumCommandArguments
        {
            [Argument(Required = true, Tooltip = "Webpage address of the tweet to load")]
            public TextStructure posturl { get; set; }

            [Argument(DefaultVariable = "timeoutselenium", Tooltip = "Specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed")]
            public override TimeSpanStructure Timeout { get; set; } = new TimeSpanStructure(SeleniumSettings.SeleniumTimeout);

            [Argument(Tooltip = "By default, waits until the webpage fully loads")]
            public BooleanStructure NoWait { get; set; } = new BooleanStructure(false);
        }

        public void Execute(Arguments arguments)
        {
            try
            {
                SeleniumManager.CurrentWrapper.NewTab(arguments.Timeout.Value, arguments.posturl.Value, arguments.NoWait.Value);
            }

            catch (Exception ex)
            {
                throw new ApplicationException($"Error occured while opening new selenium instance. Message: {ex.Message}", ex);
            }
        }
    }
}