using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using G1ANT.Language;

namespace G1ANT.Addon.Facebook
{
    [Command(Name ="facebook.sentfriendrequest", Tooltip ="This command is used to sent friend request on facebook")]
    class FacebookSentFriendRequestCommand : Command
    {
        public FacebookSentFriendRequestCommand(AbstractScripter scripter) : base(scripter)
        {

        }

        public class Arguments : SeleniumCommandArguments
        {

            [Argument(Required = true, Tooltip = "Enter person's unique id here")]
            public TextStructure id { get; set; }

            [Argument(DefaultVariable = "timeoutselenium", Tooltip = "Specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed")]
            public override TimeSpanStructure Timeout { get; set; } = new TimeSpanStructure(SeleniumSettings.SeleniumTimeout);

        }

        public void Execute(Arguments arguments)
        {
            try
            {
                Thread.Sleep(7000);
                var baseURL = String.Format("https://www.facebook.com/", arguments.Timeout.Value);
                var URL = String.Concat(baseURL, arguments.id.Value);
                SeleniumManager.CurrentWrapper.NewTab(arguments.Timeout.Value, URL, true);
                Thread.Sleep(15000);
                arguments.Search.Value = "//body/div/div/div/div/div/div/div/div/div/div/div/div/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]";
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
