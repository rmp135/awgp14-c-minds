using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpMinds {
    public class TestComponent: Component {

        int testint;

        public int TestInt { get { return testint; } }

        public TestComponent(string name) : base(name) {
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
