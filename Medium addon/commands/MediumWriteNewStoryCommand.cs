using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using G1ANT.Language;

namespace G1ANT.Addon.Medium
{ 
    [Command(Name = "medium.write", Tooltip ="This command is used to write a new public story and publish it")]
    class MediumWriteNewStoryCommand : Command
    {
        public MediumWriteNewStoryCommand(AbstractScripter scripter) : base(scripter)
        {

        }
        
        public class Arguments : SeleniumCommandArguments
        {
            [Argument(Required = true, Tooltip = " Enter the title of you story")]
            public TextStructure title { get; set; }

            [Argument(Required = true, Tooltip ="Enter the content of your story")]
            public TextStructure content { get; set; }

            [Argument(DefaultVariable = "timeoutselenium", Tooltip = "Specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed")]
            public override TimeSpanStructure Timeout { get; set; } = new TimeSpanStructure(SeleniumSettings.SeleniumTimeout);

        }
        public void Execute(Arguments arguments)
        {
            try
            {
                Thread.Sleep(8000);
                arguments.Search.Value = "//html//body//div//div//div//div//div//div//div//button//div//img";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                Thread.Sleep(3000);
                arguments.Search.Value = "//a[contains(text(),'New story')]";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                Thread.Sleep(3000);
                arguments.Search.Value = "//span[contains(text(),'Title')]";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                Thread.Sleep(2000);
                SeleniumManager.CurrentWrapper.TypeText(arguments.title.Value, arguments, arguments.Timeout.Value);
                Thread.Sleep(5000);
                arguments.Search.Value = "//span[contains(text(),'Tell your story')]";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                Thread.Sleep(2000);
                SeleniumManager.CurrentWrapper.TypeText(arguments.content.Value, arguments, arguments.Timeout.Value);
                Thread.Sleep(4000);
                arguments.Search.Value = "//span[contains(text(),'Publish')]";
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
