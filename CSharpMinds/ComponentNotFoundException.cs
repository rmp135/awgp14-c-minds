using System;

namespace CSharpMinds
{
    public class ComponentNotFoundException : Exception
    {
        public override string Message {
            get {
                return "The requested component can not be found. Ensure the component exists and is assigned in the Initialise method.";
            }
        }
    }
}