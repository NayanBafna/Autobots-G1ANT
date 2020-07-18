using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using G1ANT.Language;

namespace G1ANT.Addon.twitter

{
    [Command(Name = "twitter.savesearch", Tooltip = "This command is used to save a search on the twitter site.")]
    public class TwitterSavesearchCommand : Command
    {
        public TwitterSavesearchCommand(AbstractScripter scripter) : base(scripter)
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

                arguments.Search.Value = "/html[1]/body[1]/div[1]/div[1]/div[1]/div[2]/main[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[3]/div[1]/div[1]/*[local-name()='svg'][1]";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                System.Threading.Thread.Sleep(2000);
                arguments.Search.Value = "div.css-1dbjc4n.r-13awgt0.r-12vffkv div.css-1dbjc4n.r-13awgt0.r-12vffkv div.r-1d2f490.r-u8s1d.r-zchlnj.r-ipm5af.r-184en5c div.css-1dbjc4n.r-1d2f490.r-105ug2t.r-u8s1d.r-zchlnj.r-ipm5af:nth-child(2) div.css-1dbjc4n.r-12vffkv div.css-1dbjc4n.r-12vffkv div.css-1dbjc4n.r-1pz39u2.r-16y2uox.r-1wbh5a2 div.css-1dbjc4n:nth-child(2) div.css-1dbjc4n.r-14lw9ot.r-1f0042m.r-1upvrn0.r-1ekmkwe.r-1udh08x.r-u8s1d:nth-child(3) div.css-1dbjc4n div.css-1dbjc4n div.css-1dbjc4n.r-1loqt21.r-18u37iz.r-1ny4l3l.r-1j3t67a.r-9qu9m4.r-o7ynqc.r-6416eg.r-13qz1uu:nth-child(3) div.css-1dbjc4n.r-16y2uox.r-1wbh5a2:nth-child(2) div.css-901oao.r-hkyrab.r-1qd0xha.r-a023e6.r-16dba41.r-ad9z0x.r-bcqeeo.r-qvutc0 > span.css-901oao.css-16my406.r-1qd0xha.r-ad9z0x.r-bcqeeo.r-qvutc0";
                arguments.By.Value = "cssselector";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);

            }

            catch (Exception ex)
            {
                throw new ApplicationException($"Error occured while opening new selenium instance. Message: {ex.Message}", ex);
            }
        }
    }
}