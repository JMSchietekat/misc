using System.Collections.Generic;

namespace CsIntermediate.Workflow
{
    public class WorkflowRunner
    {
        private readonly IList<IActivity> _activities;
        
        public WorkflowRunner()
        {
            _activities = new List<IActivity>();
        }

        public void Add(IActivity activity)
        {
            _activities.Add(activity);
        }

        public void Run()
        {
            foreach (var activity in _activities)
            {
                activity.Execute();
            }
        }

    }
}