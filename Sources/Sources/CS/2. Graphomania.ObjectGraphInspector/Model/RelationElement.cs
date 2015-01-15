namespace Graphomania.ObjectGraphInspector.Model
{
    public class RelationElement : ObjectGraphElement
    {
        public RelationElement(NodeElement elementFrom, string relationName, NodeElement elementTo)
        {
        }

        public RelationElement(ObjectGraphElement elementFrom, string relationName, ObjectGraphElement elementTo) : 
            this((NodeElement)elementFrom, relationName, (NodeElement)elementTo)
        {
        }
    }
}
