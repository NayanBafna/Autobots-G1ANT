using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using G1ANT.Language;

namespace G1ANT.Addon.InstagramApp
{
    [Command(Name = "instagramapp.open", Tooltip = "This command opens the instagram App. Use this command first before using any of the other commands")]
    class InstagramappOpenCommand : Command
    {
        public InstagramappOpenCommand(AbstractScripter scripter) : base(scripter)
        {
        }

        public class Arguments : CommandArguments
        {
            [Argument(Required = true, Tooltip = "Enter the password here")]
            public TextStructure pword { get; set; } = new TextStructure();
            [Argument(Required = true, Tooltip = "Enter the e-mail ID here")]
            public TextStructure email { get; set; } = new TextStructure();
        }

        public void Execute(Arguments arguments)
        {
            AppiumWrapper.pword = arguments.pword.Value;
            AppiumWrapper.email = arguments.email.Value;
            AppiumWrapper.AppiumOpen();
        }
    }
}
