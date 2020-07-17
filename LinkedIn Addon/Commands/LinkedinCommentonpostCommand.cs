using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using G1ANT.Language;

namespace G1ANT.Addon.Linkedin
{
    [Command(Name = "linkedin.commentonpost", Tooltip = "This command is used to comment on any post on linkedin.")]
    public class LinkedinCommentonpostCommand : Command
    {
        public LinkedinCommentonpostCommand(AbstractScripter scripter) : base(scripter)
        {

        }
        public class Arguments : SeleniumCommandArguments
        {
            [Argument(Required = true, Tooltip = "Enter the comment to be posted here")]
            public TextStructure comment { get; set; }
            [Argument(DefaultVariable = "timeoutselenium", Tooltip = "Specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed")]
            public override TimeSpanStructure Timeout { get; set; } = new TimeSpanStructure(SeleniumSettings.SeleniumTimeout);

        }

        public void Execute(Arguments arguments)
        {
            try
            {
                arguments.Search.Value = "body.render-mode-BIGPIPE.nav-v2.theme.theme--classic.ember-application.boot-complete.icons-loaded:nth-child(2) div.application-outlet:nth-child(54) div.authentication-outlet:nth-child(3) div.feed-container-theme.feed-outlet div.self-focused.ember-view div.neptune-grid.three-column div.core-rail.update-outlet section.fixed-full div.feed-shared-update-v2.feed-shared-update-v2--minimal-padding.relative.full-height.Elevation-2dp.ember-view div.social-details-social-activity.update-v2-social-activity.ember-view div.social-details-social-activity.ember-view div.feed-shared-update-v2__comments-container.display-flex.flex-column div.comments-comment-box.comments-comment-box--has-avatar.ember-view div.comments-comment-box__form-container.flex-grow-1 form.comments-comment-box__form div.comments-comment-texteditor.display-flex div.comments-comment-box-comment__text-editor.ember-view div.ember-view div.editor-container.ember-view div.editor-content.ql-container > div.ql-editor.ql-blank";
                arguments.By.Value = "cssselector";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
                System.Threading.Thread.Sleep(2000);
                SeleniumManager.CurrentWrapper.TypeText(arguments.comment.Value, arguments, arguments.Timeout.Value);
               
                System.Threading.Thread.Sleep(5000);
                arguments.Search.Value = "comments-comment-box__submit-button";
                arguments.By.Value = "class";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);

            }

            catch (Exception ex)
            {
                throw new ApplicationException($"Error occured while opening new selenium instance. Message: {ex.Message}", ex);
            }
        }
    }
}
