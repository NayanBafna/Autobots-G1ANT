using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using G1ANT.Language;


namespace G1ANT.Addon.Quora
{
    [Command(Name = "quora.getfeed",Tooltip ="This command is used to get your personalized feed")]
    class QuoraGetFeedCommand : Command
    {
        public QuoraGetFeedCommand(AbstractScripter scripter) : base(scripter)
        {

        }
        public class Arguments : SeleniumCommandArguments
        {
            [Argument(Required = true, Tooltip = "Enter the type of feed you want to read")]
            public TextStructure feed { get; set; } 

            [Argument(Tooltip = "Enter a variable where the value of a specified attribute will be stored")]
            public VariableStructure result { get; set; } = new VariableStructure("result");

            [Argument(DefaultVariable = "timeoutselenium", Tooltip = "Specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed")]
            public override TimeSpanStructure Timeout { get; set; } = new TimeSpanStructure(SeleniumSettings.SeleniumTimeout);

        }
        public void Execute(Arguments arguments)
        {
            try
            {
                if (arguments.feed.Value == "Movies")
                {
                    arguments.Search.Value = "//div[contains(text(),'Movies')]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                }
                else if(arguments.feed.Value == "Books")
                {
                    arguments.Search.Value = "//div[contains(text(),'Books')]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                }
                else if (arguments.feed.Value == "Education")
                {
                    arguments.Search.Value = "//div[contains(text(),'Education')]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);

                }
                else if(arguments.feed.Value == "Politics")
                {
                    arguments.Search.Value = "//div[contains(text(),'Politics')]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);

                }
                else if (arguments.feed.Value == "Mobile phones")
                {
                    arguments.Search.Value = "//div[contains(text(),'Mobile Phones')]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);

                }
                else if (arguments.feed.Value == "Fashion and style")
                {
                    arguments.Search.Value = "//div[contains(text(),'Fashion and Style')]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);

                }
                else if (arguments.feed.Value == "Sports")
                {
                    arguments.Search.Value = "//div[contains(text(),'Sports')]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);

                }
                else if (arguments.feed.Value == "Music")
                {
                    arguments.Search.Value = "//div[contains(text(),'Music')]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);

                }
                else if (arguments.feed.Value == "Technology")
                {
                    arguments.Search.Value = "//div[contains(text(),'Technology')]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);

                }
                else if (arguments.feed.Value == "Science")
                {
                    arguments.Search.Value = "//div[contains(text(),'Science')]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);

                }
                else if (arguments.feed.Value == "Learning Java")
                {
                    arguments.Search.Value = "//div[contains(text(),'Learning Java')]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);

                }
                else if (arguments.feed.Value == "Node.js")
                {
                    arguments.Search.Value = "//div[contains(text(),'Node.js')]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);

                }
                else
                {
                    RobotMessageBox.Show("Enter a valid feed type");
                   
                }


                Thread.Sleep(5000);
                arguments.Search.Value = "//body[@class='q-platform--desktop']/div/div/div[@class='q-box']/div[@class='q-box']/div[@class='q-box']/div[@class='q-text qu-display--flex qu-px--large qu-pb--large qu-flexDirection--row qu-fontSize--regular']/div[@class='q-box']/div[4]";
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
