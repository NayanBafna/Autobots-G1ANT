using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using G1ANT.Language;

namespace G1ANT.Addon.Instagram

{
    [Command(Name = "instagram.sharepost", Tooltip = "This command is used to share any post on the instagram site.")]
    public class InstagramSharepostCommand : Command
    {
        public InstagramSharepostCommand(AbstractScripter scripter) : base(scripter)
        {

        }
        public class Arguments : SeleniumCommandArguments
        {


            [Argument(Required = true, Tooltip = "Enter the person's name or username.")]
            public TextStructure shareto { get; set; }

            [Argument(DefaultVariable = "timeoutselenium", Tooltip = "Specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed")]

            public override TimeSpanStructure Timeout { get; set; } = new TimeSpanStructure(SeleniumSettings.SeleniumTimeout);


        }

        public void Execute(Arguments arguments)
        {
            try
            {


                arguments.Search.Value = "/html[1]/body[1]/div[1]/section[1]/main[1]/div[1]/div[1]/article[1]/div[3]/section[1]/button[1]/div[1]/*[local-name()='svg'][1]";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);

                arguments.Search.Value = "/html[1]/body[1]/div[4]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);

                arguments.Search.Value = "/html[1]/body[1]/div[5]/div[1]/div[1]/div[2]/div[1]/div[1]/div[2]/input[1]";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                SeleniumManager.CurrentWrapper.TypeText(arguments.shareto.Value, arguments, arguments.Timeout.Value);
                arguments.Search.Value = "/html[1]/body[1]/div[5]/div[1]/div[1]/div[2]/div[2]/div[1]/div[1]/div[3]/button[1]/span[1]";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);

                arguments.Search.Value = "/html[1]/body[1]/div[5]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/button[1]/div[1]";
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