namespace Graphomania.ObjectGraphInspector
{
    public struct PropertyDesc
    {
        public PropertyDesc(string name, object value)
        {
            this.Name = name;
            this.Value = value;
        }

        public readonly string Name;

        public readonly object Value;
    }
}
