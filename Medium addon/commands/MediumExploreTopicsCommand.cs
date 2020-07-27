using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using G1ANT.Language;

namespace G1ANT.Addon.Medium
{
    [Command(Name ="medium.exploretopics", Tooltip ="This command is used to explore and follow your favourite topics")]
    class MediumExploreTopicsCommand : Command
    {
        public MediumExploreTopicsCommand(AbstractScripter scripter) : base(scripter)
        {

        }

        public class Arguments : SeleniumCommandArguments
        {
            [Argument(DefaultVariable = "timeoutselenium", Tooltip = "Specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed")]
            public override TimeSpanStructure Timeout { get; set; } = new TimeSpanStructure(SeleniumSettings.SeleniumTimeout);
            
            [Argument(Required = true, Tooltip = "Enter the topic to explore and follow")]
            public TextStructure topic { get; set; }
        }

        public void Execute(Arguments arguments)
        {
            try
            {
                Thread.Sleep(5000);
                arguments.Search.Value = "//nav//div[3]//button[1]//span[1]//*[local-name()='svg']";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                Thread.Sleep(3000);
                arguments.Search.Value = "//a[contains(text(),'More')]";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                Thread.Sleep(4000);
                if (arguments.topic.Value == "Beauty")
                {
                    arguments.Search.Value = "//a[contains(text(),'Beauty')]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                }
                else if (arguments.topic.Value == "Books")
                {
                    arguments.Search.Value = "//a[contains(text(),'Books')]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                }
                else if (arguments.topic.Value == "Comics")
                {
                    arguments.Search.Value = "//a[contains(text(),'Comics')]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                }
                else if (arguments.topic.Value == "Culture")
                {
                    arguments.Search.Value = "//a[contains(text(),'Culture')]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                }
                else if (arguments.topic.Value == "Fiction")
                {
                    arguments.Search.Value = "//a[contains(text(),'Fiction')]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                }
                else if (arguments.topic.Value == "Film")
                {
                    arguments.Search.Value = "//a[contains(text(),'Film')]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                }
                else if (arguments.topic.Value == "Food")
                {
                    arguments.Search.Value = "//a[contains(text(),'Food')]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                }
                else if (arguments.topic.Value == "Gaming")
                {
                    arguments.Search.Value = "//a[contains(text(),'Gaming')]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                }
                else if (arguments.topic.Value == "Humor")
                {
                    arguments.Search.Value = "//a[contains(text(),'Humor')]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                }
                else if (arguments.topic.Value == "Makers")
                {
                    arguments.Search.Value = "//a[contains(text(),'Makers')]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                }
                else if (arguments.topic.Value == "Music")
                {
                    arguments.Search.Value = "//a[contains(text(),'Music')]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                }
                else if (arguments.topic.Value == "Photography")
                {
                    arguments.Search.Value = "//a[contains(text(),'Photography')]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                }
                else if (arguments.topic.Value == "Podcasts")
                {
                    arguments.Search.Value = "//a[contains(text(),'Podcasts')]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                }
                else if (arguments.topic.Value == "Poetry")
                {
                    arguments.Search.Value = "//a[contains(text(),'Poetry')]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                }
                else if (arguments.topic.Value == "Social Media")
                {
                    arguments.Search.Value = "//a[contains(text(),'Social Media')]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                }
                else if (arguments.topic.Value == "Sports")
                {
                    arguments.Search.Value = "//a[contains(text(),'Sports')]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                }
                else if (arguments.topic.Value == "Style")
                {
                    arguments.Search.Value = "//a[contains(text(),'Style')]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                }
                else if (arguments.topic.Value == "True Crime")
                {
                    arguments.Search.Value = "//a[contains(text(),'True Crime')]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                }
                else if (arguments.topic.Value == "TV")
                {
                    arguments.Search.Value = "//a[contains(text(),'TV')]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                }
                else if (arguments.topic.Value == "Writing")
                {
                    arguments.Search.Value = "//a[contains(text(),'Writing')]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                }
                else if (arguments.topic.Value == "Biotech")
                {
                    arguments.Search.Value = "//a[contains(text(),'Biotech')]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                }
                else if (arguments.topic.Value == "Business")
                {
                    arguments.Search.Value = "//a[contains(text(),'Business')]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                }
                else if (arguments.topic.Value == "Design")
                {
                    arguments.Search.Value = "//a[contains(text(),'Design')]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                }
                else if (arguments.topic.Value == "Economy")
                {
                    arguments.Search.Value = "//a[contains(text(),'Economy')]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                }
                else if (arguments.topic.Value == "Freelancing")
                {
                    arguments.Search.Value = "//a[contains(text(),'Freelancing')]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                }
                else if (arguments.topic.Value == "Leadership")
                {
                    arguments.Search.Value = "//a[contains(text(),'Leadership')]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                }
                else if (arguments.topic.Value == "Marketing")
                {
                    arguments.Search.Value = "//a[contains(text(),'Marketing')]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                }
                else if (arguments.topic.Value == "Product Management")
                {
                    arguments.Search.Value = "//a[contains(text(),'Product Management')]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                }
                else if (arguments.topic.Value == "Productivity")
                {
                    arguments.Search.Value = "//a[contains(text(),'Produtivity')]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                }
                else if (arguments.topic.Value == "Remote Work")
                {
                    arguments.Search.Value = "//a[contains(text(),'Remote Work')]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                }
                else if (arguments.topic.Value == "Startups")
                {
                    arguments.Search.Value = "//a[contains(text(),'Startups')]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                }
                else if (arguments.topic.Value == "Venture Capital")
                {
                    arguments.Search.Value = "//a[contains(text(),'Venture Capital')]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                }
                else if (arguments.topic.Value == "Work")
                {
                    arguments.Search.Value = "//a[contains(text(),'Work')]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                }
                else if (arguments.topic.Value == "Accessibility")
                {
                    arguments.Search.Value = "//a[contains(text(),'Accessibility')]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                }
                else if (arguments.topic.Value == "Android Dev")
                {
                    arguments.Search.Value = "//a[contains(text(),'Android Dev')]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                }
                else if (arguments.topic.Value == "Artificial Intelligence")
                {
                    arguments.Search.Value = "//a[contains(text(),'Artificial Intelligence')]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                }
                else if (arguments.topic.Value == "Gadgets")
                {
                    arguments.Search.Value = "//a[contains(text(),'Gadgets')]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                }
                else if (arguments.topic.Value == "Digital Life")
                {
                    arguments.Search.Value = "//a[contains(text(),'Digital Life')]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                }
                else if (arguments.topic.Value == "Math")
                {
                    arguments.Search.Value = "//a[contains(text(),'Math')]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                }
                else if (arguments.topic.Value == "Science")
                {
                    arguments.Search.Value = "//a[contains(text(),'Science')]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                }
                else if (arguments.topic.Value == "Self-Driving Cars")
                {
                    arguments.Search.Value = "//a[contains(text(),'Self-Driving Cars')]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                }
                else if (arguments.topic.Value == "Space")
                {
                    arguments.Search.Value = "//a[contains(text(),'Space')]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                }
                else if (arguments.topic.Value == "Technology")
                {
                    arguments.Search.Value = "//a[contains(text(),'Technology')]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                }
                else if (arguments.topic.Value == "Addiction")
                {
                    arguments.Search.Value = "//a[contains(text(),'Addiction')]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                }
                else if (arguments.topic.Value == "Family")
                {
                    arguments.Search.Value = "//a[contains(text(),'Family')]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                }
                else if (arguments.topic.Value == "Fitness")
                {
                    arguments.Search.Value = "//a[contains(text(),'Fitness')]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                }
                else if (arguments.topic.Value == "Health")
                {
                    arguments.Search.Value = "//a[contains(text(),'Health')]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                }
                else if (arguments.topic.Value == "Lifestyle")
                {
                    arguments.Search.Value = "//a[contains(text(),'Lifestyle')]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                }
                else if (arguments.topic.Value == "Mental Health")
                {
                    arguments.Search.Value = "//a[contains(text(),'Mental Health')]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                }
                else if (arguments.topic.Value == "Money")
                {
                    arguments.Search.Value = "//a[contains(text(),'Money')]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                }
                else if (arguments.topic.Value == "Pets")
                {
                    arguments.Search.Value = "//a[contains(text(),'Pets')]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                }
                else if (arguments.topic.Value == "Self")
                {
                    arguments.Search.Value = "//a[contains(text(),'Self')]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                }
                else if (arguments.topic.Value == "Travel")
                {
                    arguments.Search.Value = "//a[contains(text(),'Travel')]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                }
                else if (arguments.topic.Value == "Education")
                {
                    arguments.Search.Value = "//a[contains(text(),'Education')]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                }
                else if (arguments.topic.Value == "Coronavirus")
                {
                    arguments.Search.Value = "//a[contains(text(),'Coronavirus')]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                }
                else if (arguments.topic.Value == "Environment")
                {
                    arguments.Search.Value = "//a[contains(text(),'Environment')]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                }
                else if (arguments.topic.Value == "Future")
                {
                    arguments.Search.Value = "//a[contains(text(),'Future')]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                }
                else if (arguments.topic.Value == "History")
                {
                    arguments.Search.Value = "//a[contains(text(),'History')]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                }
                else if (arguments.topic.Value == "Language")
                {
                    arguments.Search.Value = "//a[contains(text(),'Language')]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                }
                else if (arguments.topic.Value == "Media")
                {
                    arguments.Search.Value = "//a[contains(text(),'Media')]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                }
                else if (arguments.topic.Value == "Philosophy")
                {
                    arguments.Search.Value = "//a[contains(text(),'Philosophy')]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                }
                else if (arguments.topic.Value == "Politics")
                {
                    arguments.Search.Value = "//a[contains(text(),'Politics')]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                }
                else if (arguments.topic.Value == "Privacy")
                {
                    arguments.Search.Value = "//a[contains(text(),'Privacy')]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                }
                else if (arguments.topic.Value == "Religion")
                {
                    arguments.Search.Value = "//a[contains(text(),'Religion')]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                }
                else if (arguments.topic.Value == "Race")
                {
                    arguments.Search.Value = "//a[contains(text(),'Race')]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                }
                else if (arguments.topic.Value == "Society")
                {
                    arguments.Search.Value = "//a[contains(text(),'Society')]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                }
                else if (arguments.topic.Value == "Women")
                {
                    arguments.Search.Value = "//a[contains(text(),'Women')]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                }
                else if (arguments.topic.Value == "World")
                {
                    arguments.Search.Value = "//a[contains(text(),'World')]";
                    arguments.By.Value = "xpath";
                    SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                }
                else 
                {
                    RobotMessageBox.Show("Enter valid topic");
                }

                arguments.Search.Value = "//div[2]//div[1]//div[1]//div[2]//button[1]";
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
