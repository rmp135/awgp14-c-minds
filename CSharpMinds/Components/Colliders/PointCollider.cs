using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpMinds.Components
{
    class PointCollider : ColliderComponent
    {
        Vector _point;
        public PointCollider(Vector point) {
            _point = point;
        }
        public override Vector Min {
            get { return _point; }
        }
        public override Vector Max {
            get { return _point; }
        }
    }
}
