using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using G1ANT.Language;

namespace G1ANT.Addon.Facebook
{
    [Command(Name ="facebook.createpost", Tooltip ="This command is used to create and post any post on facebook")]
    class FacebookCreatePostCommand : Command
    {
        public FacebookCreatePostCommand(AbstractScripter scripter) : base(scripter)
        {

        }

        public class Arguments : SeleniumCommandArguments
        {
            [Argument(Required = true, Tooltip ="Enter your text for post here")]
            public TextStructure post { get; set; }

            [Argument(DefaultVariable = "timeoutselenium", Tooltip = "Specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed")]
            public override TimeSpanStructure Timeout { get; set; } = new TimeSpanStructure(SeleniumSettings.SeleniumTimeout);

        }
        public void Execute(Arguments arguments)
        {
            try
            {
                Thread.Sleep(8000);
                arguments.Search.Value = "//body/div/div/div/div/div/div/div/div/div/div/div/div/div/div/div/div/div/div/div/div[1]/div[1]/div[1]/span[1]";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                Thread.Sleep(3000);
                arguments.Search.Value = "//html//body//div//div//div//div//div//div//div//div//div//div//div//div//div//form//div//div//div//div//div//div//div//div//div//div//div//div//div//div//div//div//div";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                SeleniumManager.CurrentWrapper.TypeText(arguments.post.Value, arguments, arguments.Timeout.Value);
                Thread.Sleep(3000);
                
                arguments.Search.Value = "//div[contains(text(),'Post')]";
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
