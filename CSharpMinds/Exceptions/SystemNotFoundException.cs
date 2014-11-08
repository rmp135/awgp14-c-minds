using System;

namespace CSharpMinds.Exceptions
{
    public class SystemNotFoundException : Exception
    {
        private string _systemName;

        public string SystemName {
            get { return _systemName; }
        }

        public SystemNotFoundException(string systemname) {
            _systemName = systemname;
        }

        public override string Message {
            get {
                return "The requested system can not be found. Ensure the system exists and is assigned in the Initialise method.";
            }
        }
    }
}