using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using G1ANT.Language;

namespace G1ANT.Addon.Facebook
{
    [Command(Name ="facebook.createpage", Tooltip = "This command is used to create a page on facebook")]
    class FacebookCreatePageCommand : Command
    {
        public FacebookCreatePageCommand(AbstractScripter scripter) : base(scripter)
        {

        }

        public class Arguments : SeleniumCommandArguments
        {
            [Argument(DefaultVariable = "timeoutselenium", Tooltip = "Specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed")]
            public override TimeSpanStructure Timeout { get; set; } = new TimeSpanStructure(SeleniumSettings.SeleniumTimeout);
            
            [Argument(Required = true, Tooltip = "Enter name of the page here")]
            public TextStructure name { get; set; }

            [Argument(Required =true, Tooltip ="Enter category of your page here")]
            public TextStructure category { get; set; }

            [Argument(Tooltip = "Enter descripton of your page here under 255 characters")]
            public TextStructure description { get; set; } = new TextStructure("");

        }
        public void Execute(Arguments arguments)
        {
            try 
            {
                Thread.Sleep(8000);
                arguments.Search.Value = "//body/div/div/div/div/div/div/div/div[2]/span[1]/div[1]";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                Thread.Sleep(3000);
                arguments.Search.Value = "//body/div/div/div/div/div/div/div/div/div/div/div/div/div/div/div/div/div/div/div/div[4]/a[1]/div[1]/div[2]/div[1]/div[1]/div[1]";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                Thread.Sleep(6000);
                arguments.Search.Value = "//body/div/div/div/div/div/div/div/div/div/div/div/div/div/div/div/div/div/div/div/label/div/div/input[1]";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                Thread.Sleep(2000);
                SeleniumManager.CurrentWrapper.TypeText(arguments.name.Value, arguments, arguments.Timeout.Value);
                Thread.Sleep(5000);
                arguments.Search.Value = "//html//body//div//div//div//div//div//div//div//div//div//div//div//div//div//div//div//div//div//div//div//label//div//div//div//div//div//div//span//input";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                Thread.Sleep(2000);
                SeleniumManager.CurrentWrapper.TypeText(arguments.category.Value, arguments, arguments.Timeout.Value);
                Thread.Sleep(3000);
                arguments.Search.Value = "//body/div/div/div/div/div/div/div/div/div/div/div/div/div/div/div/div/ul/li[1]/div[1]/div[1]/div[1]";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                Thread.Sleep(3000);
                if (arguments.description.Value != null)
                {
                    arguments.Search.Value = "//html//body//div//div//div//div//div//div//div//div//div//div//div//div//div//div//div//div//div//div//div//label//div//div//textarea";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                    Thread.Sleep(2000);
                    SeleniumManager.CurrentWrapper.TypeText(arguments.description.Value, arguments, arguments.Timeout.Value);
                    Thread.Sleep(2000);

                }
                else
                {
                    RobotMessageBox.Show("You have not provided any optional link");
                }
                arguments.Search.Value = "//span[contains(text(),'Create Page')]";
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
