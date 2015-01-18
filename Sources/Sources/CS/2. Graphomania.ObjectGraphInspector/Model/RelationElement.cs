namespace Graphomania.ObjectGraphInspector.Model
{
    using System;

    public class RelationElement : ObjectGraphElement, IEquatable<RelationElement>
    {
        private readonly NodeElement elementFrom;

        private readonly string relationName;

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
            return Equals(this.elementFrom, other.elementFrom) && string.Equals(this.relationName, other.relationName) && Equals(this.elementTo, other.elementTo);
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
                int hashCode = (this.elementFrom != null ? this.elementFrom.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.relationName != null ? this.relationName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.elementTo != null ? this.elementTo.GetHashCode() : 0);
                return hashCode;
            }
        }
    }
}
