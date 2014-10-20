using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpMinds
{
    public class Vector
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        public Vector() : this(0f, 0f, 0f) { }

        public Vector(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Vector Add(Vector v) {
            return new Vector(X + v.X, Y + v.Y, Z + v.Z);
        }

        public static Vector operator +(Vector v1, Vector v2) {
            return v1.Add(v2);
        }

        public Vector Subtract(Vector v) {
            return new Vector(X - v.X, Y - v.Y, Z - v.Z);
        }

        public static Vector operator -(Vector v1, Vector v2) {
            return v1.Subtract(v2);
        }

        public override string ToString() {
 	        return string.Format("X:{0}, Y:{1}, Z:{2}", X, Y, Z);
        }

        public bool Equals(Vector v) {
            return (X == v.X) && (Y == v.Y) && (Z == v.Z);
        }

        public override bool Equals(object obj) {
            if (obj is Vector)
                return Equals((Vector)obj);
            return base.Equals(obj);
        }

        public static bool operator ==(Vector v1, Vector v2) {
            if (Object.ReferenceEquals(v1, v2))
                return true;
            if (v1 == null || v2 == null)
                return false;
            return v1.Equals(v2);
        }

        public static bool operator !=(Vector v1, Vector v2) {
            return !v1.Equals(v2);
        }

    }
}
