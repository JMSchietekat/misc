using System;

namespace CsIntermediate.Workflow.Activities
{
    public class PostToYoutubeActivity : IActivity
    {
        public void Execute()
        {
            Console.WriteLine("Call a web service provided by a third-party video encoding service to tell them you have a video ready for encoding.");
        }
    }
}