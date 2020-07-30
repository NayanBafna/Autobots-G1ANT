using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using G1ANT.Language;

namespace G1ANT.Addon.Instagram

{
    [Command(Name = "instagram.viewallstories", Tooltip = "This command is used to view all stories on the instagram site.")]
    public class InstagramViewallstoriesCommand : Command
    {
        public InstagramViewallstoriesCommand(AbstractScripter scripter) : base(scripter)
        {

        }
        public class Arguments : SeleniumCommandArguments
        {
            


            [Argument(DefaultVariable = "timeoutselenium", Tooltip = "Specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed")]

            public override TimeSpanStructure Timeout { get; set; } = new TimeSpanStructure(SeleniumSettings.SeleniumTimeout);

           
        }

        public void Execute(Arguments arguments)
        {
            try
            {


                arguments.Search.Value = "/html[1]/body[1]/div[1]/section[1]/nav[1]/div[2]/div[1]/div[1]/div[3]/div[1]/div[1]/div[1]/a[1]/*[local-name()='svg'][1]";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                

                arguments.Search.Value = "/html[1]/body[1]/div[1]/section[1]/main[1]/section[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/ul[1]/li[3]";
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