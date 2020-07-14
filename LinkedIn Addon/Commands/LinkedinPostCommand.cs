using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using G1ANT.Language;

namespace G1ANT.Addon.Linkedin
{
    [Command(Name = "linkedin.post", Tooltip = "This command is used to post on the linkedin site.")]
    public class LinkedinPostCommand : Command
    {
        public LinkedinPostCommand(AbstractScripter scripter) : base(scripter)
        {

        }
        public class Arguments : SeleniumCommandArguments
        {
            [Argument(Required = true, Tooltip = "Enter the value to be posted here")]
            public TextStructure post { get; set; }


            [Argument(DefaultVariable = "timeoutselenium", Tooltip = "Specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed")]
            public override TimeSpanStructure Timeout { get; set; } = new TimeSpanStructure(SeleniumSettings.SeleniumTimeout);
        }

        public void Execute(Arguments arguments)
        {
            try
            {

                arguments.Search.Value = "share-box-feed-entry__trigger--v2";
                arguments.By.Value = "class";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                arguments.Search.Value = "ql-editor";
                arguments.By.Value = "class";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                SeleniumManager.CurrentWrapper.TypeText(arguments.post.Value, arguments, arguments.Timeout.Value);
                System.Threading.Thread.Sleep(10000);
                arguments.Search.Value = "share-actions__primary-action";
                arguments.By.Value = "class";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);


            }

            catch (Exception ex)
            {
                throw new ApplicationException($"Error occured while opening new selenium instance. Message: {ex.Message}", ex);
            }
        }
    }
}