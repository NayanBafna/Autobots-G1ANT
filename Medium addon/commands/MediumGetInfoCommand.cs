using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using G1ANT.Language;

namespace G1ANT.Addon.Medium
{
    [Command(Name ="medium.getinfo", Tooltip ="This command is used to get info about story")]
    class MediumGetInfoCommand : Command
    {
        public MediumGetInfoCommand(AbstractScripter scripter) : base(scripter)
        {

        }
        public class Arguments : SeleniumCommandArguments
        {

            [Argument(DefaultVariable = "timeoutselenium", Tooltip = "Specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed")]
            public override TimeSpanStructure Timeout { get; set; } = new TimeSpanStructure(SeleniumSettings.SeleniumTimeout);

            [Argument(Required = true, Tooltip = "Enter what you want to find out: Title, Author or Publication")]
            public TextStructure text { get; set; }
            [Argument(Tooltip = "Enter a variable where the value of a specified attribute will be stored")]
            public VariableStructure result { get; set; } = new VariableStructure("result");
        }

        public void Execute(Arguments arguments)
        {
            try
            {
                Thread.Sleep(5000);
                if (arguments.text.Value == "Title")
                {
                    arguments.Search.Value = "//div//div//div//div//div//div[2]//article[1]//div[1]//a[1]//h2[1]";
                    arguments.By.Value = "xpath";
                    var attributeValue = SeleniumManager.CurrentWrapper.GetTextValue(arguments, arguments.Timeout.Value);
                    Scripter.Variables.SetVariableValue(arguments.result.Value, new TextStructure(attributeValue));
                }
                else if (arguments.text.Value == "Author")
                {
                    arguments.Search.Value = "//div//div//div//div//div//div[2]//article[1]//div[1]//div[1]//div[1]//div[1]//div[1]//div[1]//div[1]//a[1]";
                    arguments.By.Value = "xpath";
                    var attributeValue = SeleniumManager.CurrentWrapper.GetTextValue(arguments, arguments.Timeout.Value);
                    Scripter.Variables.SetVariableValue(arguments.result.Value, new TextStructure(attributeValue));
                }
                else if (arguments.text.Value == "Publication")
                {
                    arguments.Search.Value = "//div//div//div//div//div//div[2]//article[1]//div[1]//div[1]//div[1]//div[1]//div[1]//div[1]//div[1]//a[2]";
                    arguments.By.Value = "xpath";
                    var attributeValue = SeleniumManager.CurrentWrapper.GetTextValue(arguments, arguments.Timeout.Value);
                    Scripter.Variables.SetVariableValue(arguments.result.Value, new TextStructure(attributeValue));
                }
                
                else
                {
                    RobotMessageBox.Show("Entered text is invalid. Plz choose from those three!!");
                }
                
            }

            catch (Exception ex)
            {
                throw new ApplicationException($"Error occured while opening new selenium instance. Message: {ex.Message}", ex);
            }
        }

    }
}
