namespace Graphomania.ObjectGraphInspector.Model
{
    using System;
    using System.Collections.Generic;

    public class NodeElement : ObjectGraphElement
    {
        private readonly string objectType;

        private readonly string objectId;

        private readonly ICollection<PropertyDesc> propertyDescs = new HashSet<PropertyDesc>(); 

        public NodeElement(string objectType, string objectId)
        {
            this.objectType = objectType;
            this.objectId = objectId;
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

        public string ObjectType
        {
            get
            {
                return this.objectType;
            }
        }

        public string ObjectId
        {
            get
            {
                return this.objectId;
            }
        }
    }
}
