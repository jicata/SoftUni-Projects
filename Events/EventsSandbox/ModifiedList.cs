namespace EventsSandbox
{
    using System.Collections.Generic;
    using Models;

    public class ModifiedList : List<Job>
    {
        public void HandleJobCompletion(object sender, JobDoneEventArgs e)
        {  
            this.Remove(e.Job);
        }
    }
}
