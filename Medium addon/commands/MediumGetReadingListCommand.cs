using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using G1ANT.Language;

namespace G1ANT.Addon.Medium
{
    [Command(Name ="medium.getreadinglist", Tooltip ="This command is used to get bookmarked or reading list")]
    class MediumGetReadingListCommand : Command
    {
        public MediumGetReadingListCommand(AbstractScripter scripter) : base(scripter)
        {

        }

        public class Arguments : SeleniumCommandArguments
        {

            [Argument(DefaultVariable = "timeoutselenium", Tooltip = "Specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed")]
            public override TimeSpanStructure Timeout { get; set; } = new TimeSpanStructure(SeleniumSettings.SeleniumTimeout);

            [Argument(Required = true, Tooltip = "Enter which reading list you want: Saved, Archived or Recently viewed")]
            public TextStructure list { get; set; }
            [Argument(Tooltip = "Enter a variable where the value of a specified attribute will be stored")]
            public VariableStructure result { get; set; } = new VariableStructure("result");
        }

        public void Execute(Arguments arguments)
        {
            try
            {
                Thread.Sleep(8000);
                arguments.Search.Value = "//a[2]//span[1]//span[1]//*[local-name()='svg']";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                Thread.Sleep(8000);
                arguments.Search.Value = "x-29px_svg__svgIcon-use";
                arguments.By.Value = "class";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                Thread.Sleep(5000);
                if (arguments.list.Value == "Saved")
                {
                    arguments.Search.Value = "//body/div/div/div/div/div/div/div/div[1]";
                    arguments.By.Value = "xpath";
                    var attributeValue = SeleniumManager.CurrentWrapper.GetTextValue(arguments, arguments.Timeout.Value);
                    Scripter.Variables.SetVariableValue(arguments.result.Value, new TextStructure(attributeValue));
                }
                else if (arguments.list.Value == "Archived")
                {
                    arguments.Search.Value = "//a[contains(text(),'Archived')]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                    Thread.Sleep(4000);
                    arguments.Search.Value = "//body/div/div/div/div/div/div/div/div[1]";
                    arguments.By.Value = "xpath";
                    var attributeValue = SeleniumManager.CurrentWrapper.GetTextValue(arguments, arguments.Timeout.Value);
                    Scripter.Variables.SetVariableValue(arguments.result.Value, new TextStructure(attributeValue));
                }
                else if (arguments.list.Value == "Recently viewed")
                {
                    arguments.Search.Value = "//a[contains(text(),'Recently viewed')]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                    Thread.Sleep(4000);
                    arguments.Search.Value = "//body/div/div/div/div/div/div/div/div[1]";
                    arguments.By.Value = "xpath";
                    
                    var attributeValue = SeleniumManager.CurrentWrapper.GetTextValue(arguments, arguments.Timeout.Value);
                    Scripter.Variables.SetVariableValue(arguments.result.Value, new TextStructure(attributeValue));
                }

                else
                {
                    RobotMessageBox.Show("Entered list is invalid. Plz choose from those three!!");
                }

            }

            catch (Exception ex)
            {
                throw new ApplicationException($"Error occured while opening new selenium instance. Message: {ex.Message}", ex);
            }
        }
    }
}
