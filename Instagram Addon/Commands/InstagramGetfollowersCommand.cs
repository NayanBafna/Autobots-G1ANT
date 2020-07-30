using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using G1ANT.Language;

namespace G1ANT.Addon.Instagram

{
    [Command(Name = "instagram.getfollowers", Tooltip = "This command is used to get all your followers on instagram.")]
    public class InstagramGetfollowersCommand : Command
    {
        public InstagramGetfollowersCommand(AbstractScripter scripter) : base(scripter)
        {

        }
        public class Arguments : SeleniumCommandArguments
        {
           


            [Argument(DefaultVariable = "timeoutselenium", Tooltip = "Specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed")]

            public override TimeSpanStructure Timeout { get; set; } = new TimeSpanStructure(SeleniumSettings.SeleniumTimeout);

            [Argument(Tooltip = "Name of a variable where the value of a specified attribute will be stored")]
            public VariableStructure Result { get; set; } = new VariableStructure("result");
        }

        public void Execute(Arguments arguments)
        {
            try
            {


                arguments.Search.Value = "/html[1]/body[1]/div[1]/section[1]/nav[1]/div[2]/div[1]/div[1]/div[3]/div[1]/div[5]/span[1]";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
               
                arguments.Search.Value = "/html[1]/body[1]/div[1]/section[1]/nav[1]/div[2]/div[1]/div[1]/div[3]/div[1]/div[5]/div[2]/div[1]/div[2]/div[2]/a[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                arguments.Search.Value = "/html[1]/body[1]/div[1]/section[1]/main[1]/div[1]/header[1]/section[1]/ul[1]/li[2]/a[1]";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                arguments.Search.Value = "/html[1]/body[1]/div[4]/div[1]/div[1]/div[2]/ul[1]/div[1]";
                arguments.By.Value = "xpath";

                
                var attributeValue = SeleniumManager.CurrentWrapper.GetTextValue(
             arguments,
             arguments.Timeout.Value);

                Scripter.Variables.SetVariableValue(arguments.Result.Value, new TextStructure(attributeValue));


                arguments.Search.Value = "/html[1]/body[1]/div[4]/div[1]/div[1]/div[1]/div[1]/div[2]/button[1]/div[1]/*[local-name()='svg'][1]";
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