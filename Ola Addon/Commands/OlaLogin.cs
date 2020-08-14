using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using G1ANT.Language;


namespace G1ANT.Addon.Ola
{
    [Command(Name = "ola.login", Tooltip = "This will log into your ola account")]
    public class OlaLoginCommand : Language.Command
    {
        public class Arguments : SeleniumCommandArguments
        {
            // Enter all arguments you need
            [Argument(Name = "PhoneNumber", Required = true, Tooltip = "Enter your mobile number")]
            public TextStructure Phone { get; set; } = new TextStructure(string.Empty);

            [Argument(Tooltip = "If set to `true`, the command should wait for a new window to appear after clicking the specified element")]
            public BooleanStructure WaitForNewWindow { get; set; } = new BooleanStructure(true);

            [Argument(DefaultVariable = "timeoutselenium", Tooltip = "Specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed")]
            public override TimeSpanStructure Timeout { get; set; } = new TimeSpanStructure(SeleniumSettings.SeleniumTimeout);

            [Argument(Tooltip = "By default, waits until the webpage fully loads")]
            public BooleanStructure NoWait { get; set; } = new BooleanStructure(true);

            [Argument(Tooltip = "Result variable")]
            public VariableStructure Result { get; set; } = new VariableStructure("result");
        }

        public OlaLoginCommand(AbstractScripter scripter) :
            base(scripter)
        {
        }

        // Implement this method
        public void Execute(Arguments arguments)
        {
            SeleniumManager.CurrentWrapper.Navigate("https://www.olacabs.com/", arguments.Timeout.Value, arguments.NoWait.Value);

            arguments.Search.Value = "/html/body/ola-app//header/div/span[2]";
            arguments.By.Value = "xpath";
            SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value, arguments.WaitForNewWindow.Value);

            arguments.Search.Value = "/html/body/div[1]/div[1]/div[1]/div[1]/div[2]/div[3]/input";
            arguments.By.Value = "xpath";
            SeleniumManager.CurrentWrapper.TypeText(arguments.Phone.Value, arguments, arguments.Timeout.Value);

            arguments.Search.Value = "/html/body/div[2]/div[3]/div[1]/div/div/span/div[4]";
            arguments.By.Value = "xpath";
            SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value, arguments.WaitForNewWindow.Value);

            arguments.Search.Value = "/html/body/div[1]/div[1]/div[1]/div[1]/div[4]";
            arguments.By.Value = "xpath";
            SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value, arguments.WaitForNewWindow.Value);
        }
    }
}