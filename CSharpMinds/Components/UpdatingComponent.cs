using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpMinds.Components {
    public class UpdatingComponent: Component {

        int testint;

        public int TestInt { get { return testint; } }

        public UpdatingComponent(string name) : base(name) {
            testint = 0;
        }

        public string GetTestSring() {
            return "test string";
        }

        public override void Update() {
            testint++;
        }
    }
}
