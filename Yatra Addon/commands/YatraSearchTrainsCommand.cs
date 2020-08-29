using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using G1ANT.Language;

namespace G1ANT.Addon.Yatra
{
    [Command(Name = "yatra.searchtrains", Tooltip ="This command is used to search trains on yatra's site")]
    class YatraSearchTrainsCommand :Command
    {
        public YatraSearchTrainsCommand(AbstractScripter scripter) : base(scripter)
        {

        }

        public class Arguments : SeleniumCommandArguments
        {
            [Argument(Required = true, Tooltip = "Enter depart from location here")]
            public TextStructure departfrom { get; set; }

            [Argument(Required = true, Tooltip = "Enter destination here")]
            public TextStructure destination { get; set; }

            [Argument(Required = true, Tooltip = "Enter departure date here in dd/mm/yyyy format")]
            public TextStructure departdate { get; set; }

            [Argument(Required = true, Tooltip ="Enter your irctc id here")]
            public TextStructure irctcid { get; set; }

            [Argument(DefaultVariable = "timeoutselenium", Tooltip = "Specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed")]
            public override TimeSpanStructure Timeout { get; set; } = new TimeSpanStructure(SeleniumSettings.SeleniumTimeout);
        }
        public void Execute(Arguments arguments)
        {
            try
            {
                Thread.Sleep(10000);
                arguments.Search.Value = "//span[contains(text(),'+ More')]";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                Thread.Sleep(2000);
                arguments.Search.Value = "//a[@id='booking_engine_trains']";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                Thread.Sleep(3000);
                arguments.Search.Value = "//input[@id='BE_train_from_station']";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                Thread.Sleep(2000);
                SeleniumManager.CurrentWrapper.TypeText(arguments.departfrom.Value, arguments, arguments.Timeout.Value);
                Thread.Sleep(3000);
                SeleniumManager.CurrentWrapper.PressKey("enter", arguments, arguments.Timeout.Value);
                Thread.Sleep(3000);
                arguments.Search.Value = "//input[@id='BE_train_to_station']";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                Thread.Sleep(2000);
                SeleniumManager.CurrentWrapper.TypeText(arguments.destination.Value, arguments, arguments.Timeout.Value);
                Thread.Sleep(3000);
                SeleniumManager.CurrentWrapper.PressKey("enter", arguments, arguments.Timeout.Value);
                Thread.Sleep(3000);
                arguments.Search.Value = "//input[@id='BE_train_depart_date']";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                Thread.Sleep(2000);
                arguments.Search.Value = arguments.departdate.Value;
                arguments.By.Value = "id";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                Thread.Sleep(3000);
                arguments.Search.Value = "//input[@id='BE_train_search_btn']";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                Thread.Sleep(3000);
                arguments.Search.Value = "//*[@id='otpUserId']";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                Thread.Sleep(2000);
                SeleniumManager.CurrentWrapper.TypeText(arguments.irctcid.Value,arguments, arguments.Timeout.Value);
                Thread.Sleep(2000);
                arguments.Search.Value = "//*[@id='validationFormDiv']/div[1]/button";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                Thread.Sleep(2000);
                arguments.Search.Value = "//*[@id='validationSuccessDiv']/div/button";
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
