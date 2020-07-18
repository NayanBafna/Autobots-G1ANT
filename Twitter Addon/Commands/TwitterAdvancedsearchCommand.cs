using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using G1ANT.Language;

namespace G1ANT.Addon.twitter

{
    [Command(Name = "twitter.advancedsearch", Tooltip = "This command is used for advanced search on the twitter site.")]
    public class TwitterAdvancedsearchCommand : Command
    {
        public TwitterAdvancedsearchCommand(AbstractScripter scripter) : base(scripter)
        {

        }
        public class Arguments : SeleniumCommandArguments
        {
            [Argument(Tooltip = "Enter all of the words you want to include in your search here")]
            public TextStructure allofthesewords { get; set; }

            [Argument(Tooltip = "Enter the exact phrase to be searched here")]
            public TextStructure thisexactphrase { get; set; }

            [Argument(Tooltip = "Enter any of these words which you want to search here")]
            public TextStructure anyofthesewords { get; set; }

            [Argument(Tooltip = "Enter the words which you do not want to include in your search here")]
            public TextStructure noneofthesewords { get; set; }

            [Argument(Tooltip = "Enter the hashtags to be searched here")]
            public TextStructure thesehashtags { get; set; }

            [Argument(Tooltip = "Enter the language here")]
            public TextStructure language { get; set; }

            [Argument(Tooltip = "Enter the accounts from which tweets should be posted here")]
            public TextStructure fromtheseaccounts { get; set; }

            [Argument(Tooltip = "Enter the accounts to whom tweets are posted here")]
            public TextStructure totheseaccounts { get; set; }

            [Argument(Tooltip = "Enter the accounts which should be mentioned in the tweet here")]
            public TextStructure mentioningtheseaccounts { get; set; }

            [Argument(Tooltip = "Enter the starting month from where search should begin here")]
            public TextStructure frommonth { get; set; }

            [Argument(Tooltip = "Enter the starting date from where search should begin here")]
            public TextStructure fromdate { get; set; }

            [Argument(Tooltip = "Enter the starting year from where search should begin here")]
            public TextStructure fromyear { get; set; }

            [Argument(Tooltip = "Enter the month upto which search have to be done here")]
            public TextStructure tomonth { get; set; }

            [Argument(Tooltip = "Enter the date upto which search should be done here")]
            public TextStructure todate { get; set; }

            [Argument(Tooltip = "Enter the year upto which search should be done here")]
            public TextStructure toyear { get; set; }


            [Argument(DefaultVariable = "timeoutselenium", Tooltip = "Specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed")]
            public override TimeSpanStructure Timeout { get; set; } = new TimeSpanStructure(SeleniumSettings.SeleniumTimeout);
        }

        public void Execute(Arguments arguments)
        {
            try
            {


                arguments.Search.Value = "/html[1]/body[1]/div[1]/div[1]/div[1]/div[2]/main[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[3]/div[1]/div[1]/*[local-name()='svg'][1]";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);

                System.Threading.Thread.Sleep(2000);

                arguments.Search.Value = "/html[1]/body[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[2]/div[3]/div[1]/div[1]/div[1]/a[2]/div[2]/div[1]/span[1]";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                System.Threading.Thread.Sleep(5000);
                arguments.Search.Value = "allOfTheseWords";
                arguments.By.Value = "name";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                SeleniumManager.CurrentWrapper.TypeText(arguments.allofthesewords.Value, arguments, arguments.Timeout.Value);

                arguments.Search.Value = "thisExactPhrase";
                arguments.By.Value = "name";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                SeleniumManager.CurrentWrapper.TypeText(arguments.thisexactphrase.Value, arguments, arguments.Timeout.Value);

                arguments.Search.Value = "anyOfTheseWords";
                arguments.By.Value = "name";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                SeleniumManager.CurrentWrapper.TypeText(arguments.anyofthesewords.Value, arguments, arguments.Timeout.Value);

                arguments.Search.Value = "noneOfTheseWords";
                arguments.By.Value = "name";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                SeleniumManager.CurrentWrapper.TypeText(arguments.noneofthesewords.Value, arguments, arguments.Timeout.Value);

                arguments.Search.Value = "theseHashtags";
                arguments.By.Value = "name";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                SeleniumManager.CurrentWrapper.TypeText(arguments.thesehashtags.Value, arguments, arguments.Timeout.Value);

                arguments.Search.Value = "/html[1]/body[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[2]/div[1]/div[2]/div[1]/div[1]/div[1]/div[2]/div[6]/div[2]/select[1]";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                SeleniumManager.CurrentWrapper.TypeText(arguments.language.Value, arguments, arguments.Timeout.Value);
                SeleniumManager.CurrentWrapper.PressKey("enter", arguments, arguments.Timeout.Value);

                arguments.Search.Value = "fromTheseAccounts";
                arguments.By.Value = "name";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                SeleniumManager.CurrentWrapper.TypeText(arguments.fromtheseaccounts.Value, arguments, arguments.Timeout.Value);

                arguments.Search.Value = "toTheseAccounts";
                arguments.By.Value = "name";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                SeleniumManager.CurrentWrapper.TypeText(arguments.totheseaccounts.Value, arguments, arguments.Timeout.Value);

                arguments.Search.Value = "mentioningTheseAccounts";
                arguments.By.Value = "name";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                SeleniumManager.CurrentWrapper.TypeText(arguments.mentioningtheseaccounts.Value, arguments, arguments.Timeout.Value);

                arguments.Search.Value = "/html[1]/body[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[2]/div[1]/div[2]/div[1]/div[1]/div[1]/div[16]/div[1]/div[2]/div[1]/div[1]/div[2]/select[1]";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                SeleniumManager.CurrentWrapper.TypeText(arguments.frommonth.Value, arguments, arguments.Timeout.Value);
                SeleniumManager.CurrentWrapper.PressKey("enter", arguments, arguments.Timeout.Value);

                arguments.Search.Value = "/html[1]/body[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[2]/div[1]/div[2]/div[1]/div[1]/div[1]/div[16]/div[1]/div[2]/div[1]/div[2]/div[2]/select[1]";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                SeleniumManager.CurrentWrapper.TypeText(arguments.fromdate.Value, arguments, arguments.Timeout.Value);
                SeleniumManager.CurrentWrapper.PressKey("enter", arguments, arguments.Timeout.Value);

                arguments.Search.Value = "/html[1]/body[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[2]/div[1]/div[2]/div[1]/div[1]/div[1]/div[16]/div[1]/div[2]/div[1]/div[3]/div[2]/select[1]";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                SeleniumManager.CurrentWrapper.TypeText(arguments.fromyear.Value, arguments, arguments.Timeout.Value);
                SeleniumManager.CurrentWrapper.PressKey("enter", arguments, arguments.Timeout.Value);


                arguments.Search.Value = "/html[1]/body[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[2]/div[1]/div[2]/div[1]/div[1]/div[1]/div[16]/div[1]/div[4]/div[1]/div[1]/div[2]/select[1]";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                SeleniumManager.CurrentWrapper.TypeText(arguments.tomonth.Value, arguments, arguments.Timeout.Value);
                SeleniumManager.CurrentWrapper.PressKey("enter", arguments, arguments.Timeout.Value);


                arguments.Search.Value = "/html[1]/body[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[2]/div[1]/div[2]/div[1]/div[1]/div[1]/div[16]/div[1]/div[4]/div[1]/div[2]/div[2]/select[1]";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                SeleniumManager.CurrentWrapper.TypeText(arguments.todate.Value, arguments, arguments.Timeout.Value);
                SeleniumManager.CurrentWrapper.PressKey("enter", arguments, arguments.Timeout.Value);


                arguments.Search.Value = "/html[1]/body[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[2]/div[1]/div[2]/div[1]/div[1]/div[1]/div[16]/div[1]/div[4]/div[1]/div[3]/div[2]/select[1]";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                SeleniumManager.CurrentWrapper.TypeText(arguments.toyear.Value, arguments, arguments.Timeout.Value);
                SeleniumManager.CurrentWrapper.PressKey("enter", arguments, arguments.Timeout.Value);


                arguments.Search.Value = "/html[1]/body[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[3]/div[1]/div[1]/span[1]/span[1]";
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