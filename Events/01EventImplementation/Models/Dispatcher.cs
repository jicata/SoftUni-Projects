namespace _01EventImplementation.Models
{
    public delegate void NameChangeEventHandler(object sender, NameChangeEventArgs args);

    public class Dispatcher
    {
        private string name;
        public event NameChangeEventHandler ChangedName;

        public string Name
        {
            get { return this.name; }
            set
            {
                this.name = value;
                OnNameChange(new NameChangeEventArgs(value));
            }   
        }

        private void OnNameChange(NameChangeEventArgs args)
        {
            if (ChangedName != null)
            {
                ChangedName(this, args);
            }
        }
    }
}
