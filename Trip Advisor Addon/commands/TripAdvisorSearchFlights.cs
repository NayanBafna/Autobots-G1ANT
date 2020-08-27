using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using G1ANT.Language;

namespace G1ANT.Addon.TripAdvisor
{
    [Command(Name = "tripadvisor.searchflight", Tooltip = "This command is used to search flights for 1 adult")]
    class YatraSearchFlightCommand : Command
    {
        public YatraSearchFlightCommand(AbstractScripter scripter) : base(scripter)
        {

        }

        public class Arguments : SeleniumCommandArguments
        {
            [Argument(Tooltip = "Enter one way trip or two way in interger")]
            public IntegerStructure type { get; set; }

            [Argument(Required = true, Tooltip = "Enter depart from location here")]
            public TextStructure departfrom { get; set; }

            [Argument(Required = true, Tooltip = "Enter destination here")]
            public TextStructure destination { get; set; }

            [Argument(Required = true, Tooltip = "Enter departure date here in dd/mm/yyyy format")]
            public TextStructure departdate { get; set; }

            [Argument(Tooltip = "If Two way trip, enter return date here in dd/mm/yyyy format")]
            public TextStructure returndate { get; set; }

            [Argument(Required = true, Tooltip = "Enter the class here")]
            public TextStructure seat { get; set; } = new TextStructure("Economy");
        }
        public void Execute(Arguments arguments)
        {
            try
            {
                Thread.Sleep(10000);
                arguments.Search.Value = "/html/body/div/main/div[1]/div[2]/div/div/div[7]/a";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                if (arguments.type.Value == 2)
                {
                    Thread.Sleep(5000);
                    arguments.Search.Value = "/html/body/div[2]/div[1]/div/div/div[2]/div/div/div/div[1]/div/div/span[1]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                    Thread.Sleep(2000);
                    arguments.Search.Value = "/html/body/div[2]/div[1]/div/div/div[2]/div/div/div/div[2]/div/div[1]/div/div[1]/div/div/div/input";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                    Thread.Sleep(2000);
                    SeleniumManager.CurrentWrapper.TypeText(arguments.departfrom.Value, arguments, arguments.Timeout.Value);
                    Thread.Sleep(3000);
                    SeleniumManager.CurrentWrapper.PressKey("enter", arguments, arguments.Timeout.Value);
                    Thread.Sleep(3000);
                    arguments.Search.Value = "/html/body/div[2]/div[1]/div/div/div[2]/div/div/div/div[2]/div/div[1]/div/div[2]/div/div/div/input";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                    Thread.Sleep(2000);
                    SeleniumManager.CurrentWrapper.TypeText(arguments.destination.Value, arguments, arguments.Timeout.Value);
                    Thread.Sleep(3000);
                    SeleniumManager.CurrentWrapper.PressKey("enter", arguments, arguments.Timeout.Value);
                    Thread.Sleep(3000);
                    arguments.Search.Value = "/html/body/div[2]/div[1]/div/div/div[2]/div/div/div/div[2]/div/div[2]/div/div[1]/div";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                    Thread.Sleep(2000);
                    arguments.Search.Value = arguments.departdate.Value;
                    arguments.By.Value = "id";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                    Thread.Sleep(3000);
                    arguments.Search.Value = "/html/body/div[2]/div[1]/div/div/div[2]/div/div/div/div[2]/div/div[2]/div/div[2]/div";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                    Thread.Sleep(2000);
                    arguments.Search.Value = arguments.returndate.Value;
                    arguments.By.Value = "id";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                    Thread.Sleep(3000);
                }

                else
                {

                    Thread.Sleep(5000);
                    arguments.Search.Value = "/html/body/div[2]/div[1]/div/div/div[2]/div/div/div/div[1]/div/div/span[2]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                    Thread.Sleep(2000);
                    arguments.Search.Value = "/html/body/div[2]/div[1]/div/div/div[2]/div/div/div/div[2]/div/div[1]/div/div[1]/div/div/div/input";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                    Thread.Sleep(2000);
                    SeleniumManager.CurrentWrapper.TypeText(arguments.departfrom.Value, arguments, arguments.Timeout.Value);
                    Thread.Sleep(3000);
                    SeleniumManager.CurrentWrapper.PressKey("enter", arguments, arguments.Timeout.Value);
                    Thread.Sleep(3000);
                    arguments.Search.Value = "/html/body/div[2]/div[1]/div/div/div[2]/div/div/div/div[2]/div/div[1]/div/div[2]/div/div/div/input";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                    Thread.Sleep(2000);
                    SeleniumManager.CurrentWrapper.TypeText(arguments.destination.Value, arguments, arguments.Timeout.Value);
                    Thread.Sleep(3000);
                    SeleniumManager.CurrentWrapper.PressKey("enter", arguments, arguments.Timeout.Value);
                    Thread.Sleep(3000);
                    arguments.Search.Value = "/html/body/div[2]/div[1]/div/div/div[2]/div/div/div/div[2]/div/div[2]/div/div[1]/div";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                    Thread.Sleep(2000);
                    arguments.Search.Value = arguments.departdate.Value;
                    arguments.By.Value = "id";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                    Thread.Sleep(3000);
                    
                }

                Thread.Sleep(2000);

                if (arguments.seat.Value == "Premium Economy")
                {
                    arguments.Search.Value = "/html/body/div[2]/div[1]/div/div/div[2]/div/div/div/div[2]/div/div[3]/div";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                    Thread.Sleep(2000);
                    arguments.Search.Value = "/html/body/div[2]/div[1]/div/div/div[2]/div/div/div/div[2]/div/div[3]/div/div/div/div[2]/span[2]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                }
                else if (arguments.seat.Value == "Business")
                {
                    arguments.Search.Value = "/html/body/div[2]/div[1]/div/div/div[2]/div/div/div/div[2]/div/div[3]/div";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                    Thread.Sleep(2000);
                    arguments.Search.Value = "/html/body/div[2]/div[1]/div/div/div[2]/div/div/div/div[2]/div/div[3]/div/div/div/div[2]/span[2]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                }

                else if (arguments.seat.Value == "First Class")
                {
                    arguments.Search.Value = "/html/body/div[2]/div[1]/div/div/div[2]/div/div/div/div[2]/div/div[3]/div";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                    Thread.Sleep(2000);
                    arguments.Search.Value = "/html/body/div[2]/div[1]/div/div/div[2]/div/div/div/div[2]/div/div[3]/div/div/div/div[2]/span[2]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                }
                else
                {
                    arguments.Search.Value = "/html/body/div[2]/div[1]/div/div/div[2]/div/div/div/div[3]/div/div[1]/span/div[1]/label/span";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                    Thread.Sleep(2000);
                    arguments.Search.Value = "/html/body/div[2]/div[1]/div/div/div[2]/div/div/div/div[3]/div/div[2]/span/div[1]/label/span";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                }
                Thread.Sleep(3000);
                arguments.Search.Value = "/html/body/div[2]/div[1]/div/div/div[2]/div/div/div/div[5]/button";
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