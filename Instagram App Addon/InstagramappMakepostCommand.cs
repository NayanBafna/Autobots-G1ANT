using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using G1ANT.Language;

namespace G1ANT.Addon.InstagramApp
{
    [Command(Name = "instagramapp.makepost", Tooltip = "This command makes a post with images from the gallery.")]
    class InstagramappMakePostCommand : Command
    {
        public InstagramappMakePostCommand(AbstractScripter scripter) : base(scripter)
        {

        }

        public class Arguments : CommandArguments
        {
            [Argument(Required = true, Tooltip = "Provide which image should be selected i.e, nth image in the gallery.")]
            public int imageNumber { get; set; } = new int();
            [Argument(Required = false, Tooltip = "Provide a caption for the post")]
            public TextStructure caption { get; set; } = new TextStructure(" ");
        }

        public void Execute(Arguments arguments)
        {
            AppiumWrapper.AppiumClick("//android.widget.LinearLayout[@index='3']/android.widget.FrameLayout[@index='2']", "xpath");
            if (arguments.imageNumber == 1)
            {
                AppiumWrapper.AppiumClick("//android.widget.FrameLayout[@index='1']//android.widget.CheckBox[@index='0']", "xpath");
            }
            else
            {
                for (int i = 0; i < arguments.imageNumber; i++)
                {
                    var xpath = String.Format("//android.widget.FrameLayout[@index='1']//android.widget.CheckBox[@index='{0}']", i);
                    AppiumWrapper.AppiumClick(xpath, "xpath");
                }
            }
            AppiumWrapper.AppiumClick("//android.widget.LinearLayout[@index='2']//android.widget.TextView[@index='2']", "xpath");
            AppiumWrapper.AppiumClick("//android.widget.FrameLayout[@index='1']//android.widget.TextView[@index='2']", "xpath");
            if (!string.IsNullOrEmpty(arguments.caption.Value))
            {
                AppiumWrapper.AppiumTypeText("//android.widget.FrameLayout[@index='0']//android.widget.EditText[@index='2']", arguments.caption.Value, "xpath");
            }
            AppiumWrapper.AppiumClick("//android.widget.FrameLayout[@index='1']//android.widget.TextView[@index='2']", "xpath");
        }
    }
}