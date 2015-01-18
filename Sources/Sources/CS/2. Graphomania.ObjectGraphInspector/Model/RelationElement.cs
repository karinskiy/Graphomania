namespace Graphomania.ObjectGraphInspector.Model
{
    using System;

    public class RelationElement : ObjectGraphElement, IEquatable<RelationElement>
    {
        private readonly string elementFromId;

        private readonly NodeElement elementFrom;

        private readonly string relationName;

        private readonly string elementToId;

        private readonly NodeElement elementTo;

        public RelationElement(NodeElement elementFrom, string relationName, NodeElement elementTo)
        {
            this.elementFrom = elementFrom;
            this.relationName = relationName;
            this.elementTo = elementTo;
        }

        public RelationElement(ObjectGraphElement elementFrom, string relationName, ObjectGraphElement elementTo) : 
            this((NodeElement)elementFrom, relationName, (NodeElement)elementTo)
        {
        }

        public RelationElement(string elementFromId, string relationName, string elementToId)
        {
            this.elementFromId = elementFromId;
            this.relationName = relationName;
            this.elementToId = elementToId;
        }

        public NodeElement ElementFrom
        {
            get
            {
                return this.elementFrom;
            }
        }

        public string RelationName
        {
            get
            {
                return this.relationName;
            }
        }

        public NodeElement ElementTo
        {
            get
            {
                return this.elementTo;
            }
        }

        public string ElementFromId
        {
            get
            {
                return this.elementFromId;
            }
        }

        public string ElementToId
        {
            get
            {
                return this.elementToId;
            }
        }

        public bool Equals(RelationElement other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }
            if (ReferenceEquals(this, other))
            {
                return true;
            }
            return string.Equals(this.elementFromId, other.elementFromId) && string.Equals(this.relationName, other.relationName) && string.Equals(this.elementToId, other.elementToId);
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
            return Equals((RelationElement)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (this.elementFromId != null ? this.elementFromId.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.relationName != null ? this.relationName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.elementToId != null ? this.elementToId.GetHashCode() : 0);
                return hashCode;
            }
        }
    }
}
