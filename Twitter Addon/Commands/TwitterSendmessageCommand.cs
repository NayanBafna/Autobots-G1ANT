﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using G1ANT.Language;

namespace G1ANT.Addon.twitter

{
    [Command(Name = "twitter.sendmessage", Tooltip = "This command is used to send any message from your twitter account.")]
    public class TwitterSendmessageCommand : Command
    {
        public TwitterSendmessageCommand(AbstractScripter scripter) : base(scripter)
        {

        }
        public class Arguments : SeleniumCommandArguments
        {
            [Argument(Required = true, Tooltip = "Enter the name or username of the person here")]
            public TextStructure name { get; set; }
            [Argument(Required = true, Tooltip = "Enter the message here")]
            public TextStructure message { get; set; }

            [Argument(DefaultVariable = "timeoutselenium", Tooltip = "Specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed")]
            public override TimeSpanStructure Timeout { get; set; } = new TimeSpanStructure(SeleniumSettings.SeleniumTimeout);

          
        }

        public void Execute(Arguments arguments)
        {
            try
            {


                arguments.Search.Value = "/html[1]/body[1]/div[1]/div[1]/div[1]/div[2]/header[1]/div[1]/div[1]/div[1]/div[1]/div[2]/nav[1]/a[4]/div[1]/div[1]/*[local-name()='svg'][1]/*[name()='g'][1]/*[name()='path'][1]";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                System.Threading.Thread.Sleep(5000);

                arguments.Search.Value = "/html[1]/body[1]/div[1]/div[1]/div[1]/div[2]/main[1]/div[1]/div[1]/div[1]/section[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/a[1]/div[1]/*[local-name()='svg'][1]";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);

                arguments.Search.Value = "/html[1]/body[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[2]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/form[1]/div[1]/div[1]/div[1]/div[2]/input[1]";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);

                SeleniumManager.CurrentWrapper.TypeText(arguments.name.Value, arguments, arguments.Timeout.Value);
                SeleniumManager.CurrentWrapper.PressKey("enter", arguments, arguments.Timeout.Value);
                System.Threading.Thread.Sleep(5000);

                arguments.Search.Value = "/html[1]/body[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[2]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/form[1]/div[2]/div[1]/div[2]/div[1]/li[1]";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                System.Threading.Thread.Sleep(2000);
                arguments.Search.Value = "/html[1]/body[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[3]/div[1]/div[1]/div[1]";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);

                System.Threading.Thread.Sleep(2000);
                arguments.Search.Value = "//div[@class='notranslate public-DraftEditor-content']";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                SeleniumManager.CurrentWrapper.TypeText(arguments.message.Value, arguments, arguments.Timeout.Value);
                
                SeleniumManager.CurrentWrapper.PressKey("enter", arguments, arguments.Timeout.Value);

            }

            catch (Exception ex)
            {
                throw new ApplicationException($"Error occured while opening new selenium instance. Message: {ex.Message}", ex);
            }
        }
    }
}