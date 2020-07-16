using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using G1ANT.Addon.Linkedin;
using G1ANT.Language;
using OpenQA.Selenium;
using OpenQA.Selenium.Internal;
using System.Threading;
using Keys = System.Windows.Forms.Keys;


namespace G1ANT.Addon.Linkedin
{
    [Command(Name = "linkedin.viewprofile", Tooltip = "This command is used to view any profile on the linkedin site.")]
    class LinkedinViewprofileCommand : Command
    {
        public LinkedinViewprofileCommand(AbstractScripter scripter) : base(scripter)
        {

        }

        public class Arguments : SeleniumCommandArguments
        {
            [Argument(Required = true, Tooltip = "Enter person's name and id here seperated each word by '-'")]
            public TextStructure nameid { get; set; }

            [Argument(DefaultVariable = "timeoutselenium", Tooltip = "Specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed")]
            public override TimeSpanStructure Timeout { get; set; } = new TimeSpanStructure(SeleniumSettings.SeleniumTimeout);
            [Argument(Tooltip = "Name of a variable where the value of a specified attribute will be stored")]
            public VariableStructure Result { get; set; } = new VariableStructure("result");

            [Argument(Tooltip = "By default, waits until the webpage fully loads")]
            public BooleanStructure NoWait { get; set; } = new BooleanStructure(false);
        }
        public void Execute(Arguments arguments)
        {
            try
            {

                var baseURL = String.Format("https://www.linkedin.com/in/", arguments.Timeout.Value,arguments.NoWait.Value);
                var URL = String.Concat(baseURL, arguments.nameid.Value,arguments.NoWait.Value);
                SeleniumManager.CurrentWrapper.NewTab(arguments.Timeout.Value, URL, true);
                System.Threading.Thread.Sleep(10000);
                arguments.Search.Value = "/html[1]/body[1]/div[8]/div[3]/div[1]/div[1]/div[1]/div[1]/div[2]/main[1]/div[1]/section[1]/div[2]/div[2]";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                var attributeValue = SeleniumManager.CurrentWrapper.GetTextValue(
                 arguments,
                 arguments.Timeout.Value);

                Scripter.Variables.SetVariableValue(arguments.Result.Value, new TextStructure(attributeValue));

            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error occured while opening new selenium instance. Message: {ex.Message}", ex);
            }

        }


    }
}