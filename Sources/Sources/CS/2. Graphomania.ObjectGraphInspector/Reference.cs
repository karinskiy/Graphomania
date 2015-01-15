namespace Graphomania.ObjectGraphInspector
{
    public struct Reference
    {
        public Reference(string name, object from, object to)
            : this()
        {
            this.Name = name;
            this.From = from;
            this.To = to;
        }

        public string Name { get; private set; }

        public object From { get; private set; }

        public object To { get; private set; }
    }
}
