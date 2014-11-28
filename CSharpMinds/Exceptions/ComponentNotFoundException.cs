using System;

namespace CSharpMinds.Exceptions
{
    public class ComponentNotFoundException : Exception
    {
        private string _componentName;

        public string ComponentName {
            get { return _componentName; }
        }

        public ComponentNotFoundException(string componentName) {
            _componentName = componentName;
        }

        public override string Message {
            get {
                return "The requested component can not be found. Ensure the component exists and is assigned in the Initialise method.";
            }
        }
    }
}