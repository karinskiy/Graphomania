namespace Graphomania.ObjectGraphInspector.Model
{
    using System;
    using System.Collections.Generic;

    public class NodeElement : ObjectGraphElement, IEquatable<NodeElement>
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

        public bool Equals(NodeElement other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }
            if (ReferenceEquals(this, other))
            {
                return true;
            }
            return string.Equals(this.objectType, other.objectType) && string.Equals(this.objectId, other.objectId);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            if (obj.GetType() != this.GetType())
            {
                return false;
            }
            return Equals((NodeElement)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((this.objectType != null ? this.objectType.GetHashCode() : 0) * 397) ^ (this.objectId != null ? this.objectId.GetHashCode() : 0);
            }
        }
    }
}
