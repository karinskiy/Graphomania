namespace Graphomania.ObjectGraphInspector.Model
{
    using System.Collections.Generic;

    public class NodeElement : ObjectGraphElement
    {
        private readonly ICollection<PropertyDesc> propertyDescs = new HashSet<PropertyDesc>(); 

        public NodeElement()
        {
        }

        public IEnumerable<PropertyDesc> Properties
        {
            get
            {
                return this.propertyDescs;
            }
        }

        public NodeElement AddProperty(string name, object value)
        {
            this.propertyDescs.Add(new PropertyDesc(name, value));

            return this;
        }
    }
}
