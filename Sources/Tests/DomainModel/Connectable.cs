using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public abstract class Connectable : HeatingSystemElement
    {
        private readonly ICollection<ConnectionPoint> connectionPoints = new HashSet<ConnectionPoint>();

        protected Connectable(string name, HeatingSystemElement owner) : base(name, owner)
        {
        }

        public ICollection<ConnectionPoint> ConnectionPoints
        {
            get
            {
                return this.connectionPoints;
            }
        }

        public ConnectionPoint CreateConnectionPoint(string name)
        {
            var connectionPoint = new ConnectionPoint(name, this);
            connectionPoints.Add(connectionPoint);
            return connectionPoint;
        }
    }
}
