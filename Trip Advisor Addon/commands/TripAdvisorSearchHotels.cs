using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using G1ANT.Language;

namespace G1ANT.Addon.TripAdvisor
{
    [Command(Name = "tripadvisor.searchhotel", Tooltip = "This command is used to search a hotel to stay on the TripAdvisor site.")]
    public class TripAdvisorSearchHotelsCommand : Command
    {
        public TripAdvisorSearchHotelsCommand(AbstractScripter scripter) : base(scripter)
        {

        }
        public class Arguments : SeleniumCommandArguments
        {

            [Argument(DefaultVariable = "timeoutselenium", Tooltip = "Specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed")]
            public override TimeSpanStructure Timeout { get; set; } = new TimeSpanStructure(SeleniumSettings.SeleniumTimeout);

            [Argument(Required = true, Tooltip = "Enter city,location or hotel name here")]
            public TextStructure hotel { get; set; }

            [Argument(Required = true, Tooltip = "Enter check-in date here in dd/mm/yyyy format")]
            public TextStructure checkindate { get; set; }

            [Argument(Required = true, Tooltip = "Enter check-out date here in dd/mm/yyyy format")]
            public TextStructure checkoutdate { get; set; }

            [Argument(Tooltip = "Enter the no. of adults in a single room(1-4)")]

            public IntegerStructure adults { get; set; }

            [Argument(Tooltip = "Name of a variable where the value of a specified attribute will be stored")]
            public VariableStructure result { get; set; } = new VariableStructure("result");
        }
        public void Execute(Arguments arguments)
        {
            try
            {
                Thread.Sleep(10000);
                arguments.Search.Value = "/html/body/div/main/div[1]/div[2]/div/div/div[1]/a";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                Thread.Sleep(3000);
                arguments.Search.Value = "/html/body/div[2]/div/form/input[1]";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                Thread.Sleep(2000);
                SeleniumManager.CurrentWrapper.TypeText(arguments.hotel.Value, arguments, arguments.Timeout.Value);
                Thread.Sleep(2000);
                SeleniumManager.CurrentWrapper.PressKey("enter", arguments, arguments.Timeout.Value);
                Thread.Sleep(5000);
                arguments.Search.Value = "/html/body/div[1]/div/div[2]/div[6]/div[2]/div/div[2]/div[2]/div/div/div/div[1]/div/div/div[1]/button[1]/div";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                Thread.Sleep(2000);
                arguments.Search.Value = arguments.checkindate.Value;
                arguments.By.Value = "id";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                Thread.Sleep(3000);
                arguments.Search.Value = "/html/body/div[1]/div/div[2]/div[6]/div[2]/div/div[2]/div[2]/div/div/div/div[1]/div/div/div[1]/button[2]/div";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                Thread.Sleep(2000);
                arguments.Search.Value = arguments.checkoutdate.Value;
                arguments.By.Value = "id";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                Thread.Sleep(3000);
                
                if (arguments.adults.Value == 2)
                {
                    arguments.Search.Value = "/html/body/div[1]/div/div[2]/div[6]/div[2]/div/div[2]/div[2]/div/div/div/div[1]/div/div/div[2]/button/div";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                    arguments.Search.Value = "/html/body/div[4]/div[2]/div/div[2]/div/div[2]/div[1]/button[2]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                    arguments.Search.Value = "/html/body/div[4]/div[2]/div/div[2]/div/div[4]/button";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                }
                else if (arguments.adults.Value == 3)
                {
                    arguments.Search.Value = "/html/body/div[1]/div/div[2]/div[6]/div[2]/div/div[2]/div[2]/div/div/div/div[1]/div/div/div[2]/button/div";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                    arguments.Search.Value = "/html/body/div[4]/div[2]/div/div[2]/div/div[2]/div[1]/button[2]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                    arguments.Search.Value = "/html/body/div[4]/div[2]/div/div[2]/div/div[2]/div[1]/button[2]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                    arguments.Search.Value = "/html/body/div[4]/div[2]/div/div[2]/div/div[4]/button";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                }
                else if (arguments.adults.Value == 4)
                {
                    arguments.Search.Value = "/html/body/div[1]/div/div[2]/div[6]/div[2]/div/div[2]/div[2]/div/div/div/div[1]/div/div/div[2]/button/div";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                    arguments.Search.Value = "/html/body/div[4]/div[2]/div/div[2]/div/div[2]/div[1]/button[2]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                    arguments.Search.Value = "/html/body/div[4]/div[2]/div/div[2]/div/div[2]/div[1]/button[2]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                    arguments.Search.Value = "/html/body/div[4]/div[2]/div/div[2]/div/div[2]/div[1]/button[2]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                    arguments.Search.Value = "/html/body/div[4]/div[2]/div/div[2]/div/div[4]/button";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                }
                
                arguments.Search.Value = "/html/body/div[2]/div[1]/div[1]/div/div[2]/div[3]";
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

