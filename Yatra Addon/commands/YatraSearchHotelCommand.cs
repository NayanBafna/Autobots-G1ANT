using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using G1ANT.Language;

namespace G1ANT.Addon.Yatra
{
    [Command(Name ="yatra.searchhotel", Tooltip ="This command is used to search hotel on yatra's site")]
    class YatraSearchHotelCommand : Command
    {
        public YatraSearchHotelCommand(AbstractScripter scripter) : base(scripter)
        {

        }

        public class Arguments : SeleniumCommandArguments
        {
            [Argument(DefaultVariable = "timeoutselenium", Tooltip = "Specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed")]
            public override TimeSpanStructure Timeout { get; set; } = new TimeSpanStructure(SeleniumSettings.SeleniumTimeout);

            [Argument(Required =true, Tooltip ="Enter city,location or hotel name here")]
            public TextStructure hotel { get; set; }

            [Argument(Required = true, Tooltip = "Enter check-in date here in dd/mm/yyyy format")]
            public TextStructure checkindate { get; set; }

            [Argument(Required = true, Tooltip = "Enter check-out date here in dd/mm/yyyy format")]
            public TextStructure checkoutdate { get; set; }

            [Argument(Tooltip ="Enter the no. of adults in a single room(1-4)")]

            public IntegerStructure adults { get; set; }

            [Argument(Tooltip = "Name of a variable where the value of a specified attribute will be stored")]
            public VariableStructure result { get; set; } = new VariableStructure("result");
        }
        public void Execute(Arguments arguments)
        {
            try
            {
                Thread.Sleep(10000);
                arguments.Search.Value = "//body/div/div/section/div/div/section/div/div/div/ul/li[2]/a[1]";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                Thread.Sleep(3000);
                arguments.Search.Value = "//body/div/div/section/div/div/div/section/div/div/div/div/div/ul/li/div/label/input[1]";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                Thread.Sleep(2000);
                SeleniumManager.CurrentWrapper.TypeText(arguments.hotel.Value, arguments, arguments.Timeout.Value);
                Thread.Sleep(2000);
                SeleniumManager.CurrentWrapper.PressKey("enter", arguments, arguments.Timeout.Value);
                Thread.Sleep(5000);
                arguments.Search.Value = "//li[1]//section[1]//label[1]//input[1]";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                Thread.Sleep(2000);
                arguments.Search.Value = arguments.checkindate.Value;
                arguments.By.Value = "id";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                Thread.Sleep(3000);
                arguments.Search.Value = "//li[3]//section[1]//label[1]//input[1]";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                Thread.Sleep(2000);
                arguments.Search.Value = arguments.checkoutdate.Value;
                arguments.By.Value = "id";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                Thread.Sleep(3000);
                arguments.Search.Value = "//body/div/div/section/div/div/div/section/div/div/div/div/div/div/i[1]";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                Thread.Sleep(3000);
                if (arguments.adults.Value == 1)
                {
                    arguments.Search.Value = "//div//div//div//div//div//div//div//div//div//div//div//div//div//div//div[2]//div[1]//div[1]//span[1]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                }
                else if (arguments.adults.Value == 3)
                {
                    arguments.Search.Value = "//div//div//div//div//div//div//div//div//div//div//div//div//div//div//div[2]//div[1]//div[1]//span[2]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                }
                else if (arguments.adults.Value == 4)
                {
                    arguments.Search.Value = "//div//div//div//div//div//div//div//div//div//div//div//div//div//div//div[2]//div[1]//div[1]//span[2]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                    Thread.Sleep(2000);
                    arguments.Search.Value = "//div//div//div//div//div//div//div//div//div//div//div//div//div//div//div[2]//div[1]//div[1]//span[2]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                }
                else
                {
                    arguments.Search.Value = "//body/div/div/section/div/div/div/section/div/div/div/div/div/div/i[1]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                }
                Thread.Sleep(3000);
                arguments.Search.Value = "//body/div/div/section/div/div/div/section/div/div/div/div/div/input[1]";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                Thread.Sleep(10000);
                arguments.Search.Value = "//div[@id='result-wrapper']";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                var attributeValue = SeleniumManager.CurrentWrapper.GetTextValue(
                 arguments,
                 arguments.Timeout.Value);


                Scripter.Variables.SetVariableValue(arguments.result.Value, new TextStructure(attributeValue));

            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error occured while opening new selenium instance. Message: {ex.Message}", ex);
            }
        }


    }
}
