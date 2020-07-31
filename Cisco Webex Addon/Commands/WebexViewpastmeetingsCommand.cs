using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using G1ANT.Language;

namespace G1ANT.Addon.Webex

{
    [Command(Name = "webex.viewpastmeetings", Tooltip = "This command is used to view all the past meetings on the webex meeting site.")]
    public class WebexViewpastmeetingsCommand : Command
    {
        public WebexViewpastmeetingsCommand(AbstractScripter scripter) : base(scripter)
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


                arguments.Search.Value = "/html[1]/body[1]/div[1]/div[3]/div[1]/div[1]/div[1]/div[2]/div[1]/div[2]/ul[1]/li[2]/a[1]/i[1]";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                System.Threading.Thread.Sleep(2000);
                arguments.Search.Value = "/html[1]/body[1]/div[1]/div[3]/div[1]/div[1]/div[4]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[3]/a[1]";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                System.Threading.Thread.Sleep(2000);
                arguments.Search.Value = "/html[1]/body[1]/div[1]/div[3]/div[1]/div[1]/div[4]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[2]/div[2]/div[2]/div[1]";
                    arguments.By.Value = "xpath";
                 
                    var attributeValue = SeleniumManager.CurrentWrapper.GetTextValue(
                 arguments,
                 arguments.Timeout.Value);

                    Scripter.Variables.SetVariableValue(arguments.Result.Value, new TextStructure(attributeValue));
                
               
            }

            catch (Exception ex)
            {
                throw new ApplicationException($"Error occured while opening new selenium instance. Message: {ex.Message}", ex);
            }
        }
    }
}