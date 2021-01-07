using System;

namespace CsIntermediate.Workflow.Activities
{
    public class UploadVideoToCloudStorageActivity : IActivity
    {
        public void Execute()
        {
            Console.WriteLine("Upload a video to a cloud storage.");
        }
    }
}