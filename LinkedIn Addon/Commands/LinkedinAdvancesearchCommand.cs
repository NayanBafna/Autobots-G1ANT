using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using G1ANT.Language;

namespace G1ANT.Addon.Linkedin
{
    [Command(Name = "linkedin.advancesearch", Tooltip = "This command is used to advance search on the linkedin site by applying filters.")]
    public class LinkedinAdvancesearchCommand : Command
    {
        public LinkedinAdvancesearchCommand(AbstractScripter scripter) : base(scripter)
        {

        }
        public class Arguments : SeleniumCommandArguments
        {
           
            [Argument( Tooltip = "Enter the degree of connection that is 1st,2nd or 3rd here")]
            public TextStructure connection { get; set; }
            [Argument( Tooltip = "Enter the name whose connections you want to search here")]
            public TextStructure connectionsof { get; set; }
            [Argument( Tooltip = "Enter the location here")]
            public TextStructure location { get; set; }
            [Argument(Tooltip = "Enter the name of current company to search here")]
            public TextStructure currentcompany { get; set; }
            [Argument(Tooltip = "Enter the name of past company to search here")]
            public TextStructure pastcompany { get; set; }

            [Argument(Tooltip = "Enter the industry to search here")]
            public TextStructure industry { get; set; }
            [Argument(Tooltip = "Enter the name of school to search here")]
            public TextStructure school { get; set; }
           
            [Argument(Tooltip = "Enter the service to search here")]
            public TextStructure service { get; set; }



            [Argument(DefaultVariable = "timeoutselenium", Tooltip = "Specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed")]
            public override TimeSpanStructure Timeout { get; set; } = new TimeSpanStructure(SeleniumSettings.SeleniumTimeout);
        }

        public void Execute(Arguments arguments)
        {
            try
            {
                
                arguments.Search.Value = "/html[1]/body[1]/div[9]/div[4]/div[1]/div[1]/header[1]/div[1]/div[1]/div[2]/button[1]/span[1]";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                System.Threading.Thread.Sleep(5000);

                var con = arguments.connection.Value;
                if (con=="1st")
                {
                    arguments.Search.Value = "/html[1]/body[1]/div[4]/div[1]/div[1]/div[2]/div[1]/div[1]/ul[1]/li[1]/form[1]/div[1]/fieldset[1]/ol[1]/li[1]/label[1]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                }
                else if (con=="2nd")
                {
                    arguments.Search.Value = "/html[1]/body[1]/div[4]/div[1]/div[1]/div[2]/div[1]/div[1]/ul[1]/li[1]/form[1]/div[1]/fieldset[1]/ol[1]/li[2]/label[1]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                }
                else if (con=="3rd")
                {
                    arguments.Search.Value = "/html[1]/body[1]/div[4]/div[1]/div[1]/div[2]/div[1]/div[1]/ul[1]/li[1]/form[1]/div[1]/fieldset[1]/ol[1]/li[3]/label[1]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                }

                arguments.Search.Value = "/html[1]/body[1]/div[4]/div[1]/div[1]/div[2]/div[1]/div[1]/ul[1]/li[2]/form[1]/div[1]/fieldset[1]/ol[1]/li[1]/div[1]/div[1]/input[1]";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                SeleniumManager.CurrentWrapper.TypeText(arguments.connectionsof.Value, arguments, arguments.Timeout.Value);
                System.Threading.Thread.Sleep(2000);
                SeleniumManager.CurrentWrapper.PressKey("down", arguments, arguments.Timeout.Value);
                System.Threading.Thread.Sleep(2000);
                SeleniumManager.CurrentWrapper.PressKey("enter", arguments, arguments.Timeout.Value);

                arguments.Search.Value = "/html[1]/body[1]/div[4]/div[1]/div[1]/div[2]/div[1]/div[1]/ul[1]/li[3]/form[1]/div[1]/fieldset[1]/ol[1]/li[1]/div[1]/div[1]/input[1]";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                SeleniumManager.CurrentWrapper.TypeText(arguments.location.Value, arguments, arguments.Timeout.Value);
                System.Threading.Thread.Sleep(2000);
                SeleniumManager.CurrentWrapper.PressKey("down", arguments, arguments.Timeout.Value);
                System.Threading.Thread.Sleep(2000);
                SeleniumManager.CurrentWrapper.PressKey("enter", arguments, arguments.Timeout.Value);

                arguments.Search.Value = "/html[1]/body[1]/div[4]/div[1]/div[1]/div[2]/div[1]/div[1]/ul[1]/li[4]/form[1]/div[1]/fieldset[1]/ol[1]/li[1]/div[1]/div[1]/input[1]";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                SeleniumManager.CurrentWrapper.TypeText(arguments.currentcompany.Value, arguments, arguments.Timeout.Value);
                System.Threading.Thread.Sleep(2000);
                SeleniumManager.CurrentWrapper.PressKey("down", arguments, arguments.Timeout.Value);
                System.Threading.Thread.Sleep(2000);
                SeleniumManager.CurrentWrapper.PressKey("enter", arguments, arguments.Timeout.Value);

                arguments.Search.Value = "/html[1]/body[1]/div[4]/div[1]/div[1]/div[2]/div[1]/div[1]/ul[1]/li[5]/form[1]/div[1]/fieldset[1]/ol[1]/li[1]/div[1]/div[1]/input[1]";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                SeleniumManager.CurrentWrapper.TypeText(arguments.pastcompany.Value, arguments, arguments.Timeout.Value);
                SeleniumManager.CurrentWrapper.PressKey("down", arguments, arguments.Timeout.Value);
                System.Threading.Thread.Sleep(2000);
                SeleniumManager.CurrentWrapper.PressKey("enter", arguments, arguments.Timeout.Value);


                arguments.Search.Value = "/html[1]/body[1]/div[4]/div[1]/div[1]/div[2]/div[1]/div[1]/ul[1]/li[6]/form[1]/div[1]/fieldset[1]/ol[1]/li[1]/div[1]/div[1]/input[1]";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                SeleniumManager.CurrentWrapper.TypeText(arguments.industry.Value, arguments, arguments.Timeout.Value);
                System.Threading.Thread.Sleep(2000);
                SeleniumManager.CurrentWrapper.PressKey("down", arguments, arguments.Timeout.Value);
                System.Threading.Thread.Sleep(2000);
                SeleniumManager.CurrentWrapper.PressKey("enter", arguments, arguments.Timeout.Value);

                arguments.Search.Value = "/html[1]/body[1]/div[4]/div[1]/div[1]/div[2]/div[1]/div[1]/ul[1]/li[8]/form[1]/div[1]/fieldset[1]/ol[1]/li[1]/div[1]/div[1]/input[1]";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                SeleniumManager.CurrentWrapper.TypeText(arguments.school.Value, arguments, arguments.Timeout.Value);
                System.Threading.Thread.Sleep(2000);
                SeleniumManager.CurrentWrapper.PressKey("down", arguments, arguments.Timeout.Value);
                System.Threading.Thread.Sleep(2000);
                SeleniumManager.CurrentWrapper.PressKey("enter", arguments, arguments.Timeout.Value);


                arguments.Search.Value = "/html[1]/body[1]/div[4]/div[1]/div[1]/div[2]/div[1]/div[1]/ul[1]/li[10]/form[1]/div[1]/fieldset[1]/ol[1]/li[1]/div[1]/div[1]/input[1]";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                SeleniumManager.CurrentWrapper.TypeText(arguments.service.Value, arguments, arguments.Timeout.Value);
                System.Threading.Thread.Sleep(2000);
                SeleniumManager.CurrentWrapper.PressKey("down", arguments, arguments.Timeout.Value);
                System.Threading.Thread.Sleep(2000);
                SeleniumManager.CurrentWrapper.PressKey("enter", arguments, arguments.Timeout.Value);



                System.Threading.Thread.Sleep(5000);
                arguments.Search.Value = "/html[1]/body[1]/div[4]/div[1]/div[1]/div[1]/div[1]/div[2]/button[2]/span[1]";
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