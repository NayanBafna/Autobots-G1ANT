using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using G1ANT.Language;

namespace G1ANT.Addon.Yatra
{
    [Command(Name ="yatra.searchcabs", Tooltip = "This command is used to search cabs on yatra's site")]
    class YatraSearchCabsCommand : Command
    {
        public YatraSearchCabsCommand(AbstractScripter scripter) : base(scripter)
        {

        }

        public class Arguments : SeleniumCommandArguments
        {
            [Argument(Tooltip = "Enter one way trip=1 or two way=2 in integer")]
            public IntegerStructure type { get; set; }

            [Argument(Required = true, Tooltip = "Enter depart from location here")]
            public TextStructure departfrom { get; set; }

            [Argument(Required = true, Tooltip = "Enter destination here")]
            public TextStructure destination { get; set; }

            [Argument(Required = true, Tooltip = "Enter departure date here in dd/mm/yyyy format")]
            public TextStructure departdate { get; set; }

            [Argument(Tooltip = "If Two way trip, enter return date here in dd/mm/yyyy format")]
            public TextStructure returndate { get; set; }
        }
        public void Execute(Arguments arguments)
        {
            try
            {
                Thread.Sleep(10000);
                arguments.Search.Value = "//a[@id='booking_engine_cabs']";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                if (arguments.type.Value == 2)
                {
                    Thread.Sleep(5000);
                    arguments.Search.Value = "//a[contains(text(),'Outstation Round Trip')]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                    Thread.Sleep(2000);
                    arguments.Search.Value = "//input[@id='BE_cabs_from_station']";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                    Thread.Sleep(2000);
                    SeleniumManager.CurrentWrapper.TypeText(arguments.departfrom.Value, arguments, arguments.Timeout.Value);
                    Thread.Sleep(3000);
                    SeleniumManager.CurrentWrapper.PressKey("enter", arguments, arguments.Timeout.Value);
                    Thread.Sleep(3000);
                    arguments.Search.Value = "//input[@id='BE_cabs_to_station']";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                    Thread.Sleep(2000);
                    SeleniumManager.CurrentWrapper.TypeText(arguments.destination.Value, arguments, arguments.Timeout.Value);
                    Thread.Sleep(3000);
                    SeleniumManager.CurrentWrapper.PressKey("enter", arguments, arguments.Timeout.Value);
                    Thread.Sleep(3000);
                    arguments.Search.Value = "//input[@id='BE_cabs_checkin_date']";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                    Thread.Sleep(2000);
                    arguments.Search.Value = arguments.departdate.Value;
                    arguments.By.Value = "id";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                    Thread.Sleep(3000);
                    arguments.Search.Value = "//input[@id='checkInTimeField']";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                    Thread.Sleep(3000);
                    arguments.Search.Value = "//div[@id='checkInTimeList']//li[contains(text(),'10:00 am')]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                    Thread.Sleep(3000);
                    arguments.Search.Value = "//input[@id='BE_cabs_checkout_date']";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                    Thread.Sleep(2000);
                    arguments.Search.Value = arguments.returndate.Value;
                    arguments.By.Value = "id";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                    Thread.Sleep(3000);
                    arguments.Search.Value = "//input[@id='checkOutTimeField']";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                    Thread.Sleep(3000);
                    arguments.Search.Value = "//div[@id='checkOutTimeList']//li[contains(text(),'10:00 pm')]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                    Thread.Sleep(3000);
                }

                else
                {

                    Thread.Sleep(5000);
                    arguments.Search.Value = "//a[contains(text(),'Outstation Oneway')]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                    Thread.Sleep(2000);
                    arguments.Search.Value = "//input[@id='BE_cabs_from_station']";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                    Thread.Sleep(2000);
                    SeleniumManager.CurrentWrapper.TypeText(arguments.departfrom.Value, arguments, arguments.Timeout.Value);
                    Thread.Sleep(3000);
                    SeleniumManager.CurrentWrapper.PressKey("enter", arguments, arguments.Timeout.Value);
                    Thread.Sleep(3000);
                    arguments.Search.Value = "//input[@id='BE_cabs_to_station']";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                    Thread.Sleep(2000);
                    SeleniumManager.CurrentWrapper.TypeText(arguments.destination.Value, arguments, arguments.Timeout.Value);
                    Thread.Sleep(3000);
                    SeleniumManager.CurrentWrapper.PressKey("enter", arguments, arguments.Timeout.Value);
                    Thread.Sleep(3000);
                    arguments.Search.Value = "//input[@id='BE_cabs_checkin_date']";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                    arguments.Search.Value = arguments.departdate.Value;
                    arguments.By.Value = "id";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                    Thread.Sleep(3000);
                    arguments.Search.Value = "//input[@id='checkInTimeField']";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                    Thread.Sleep(3000);
                    arguments.Search.Value = "//div[@id='checkInTimeList']//li[contains(text(),'10:00 am')]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                    Thread.Sleep(3000);

                }
                Thread.Sleep(2000);
                arguments.Search.Value = "//input[@id='BE_cabs_htsearch_btn']";
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
