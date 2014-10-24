using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpMinds
{

    /// <summary>
    /// Basic 3D vector.
    /// </summary>
    public class Vector
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }


        /// <summary>
        /// Construct a Vector at position 0.
        /// </summary>
        public Vector() : this(0f, 0f, 0f) { }

        /// <summary>
        /// Construct a Vector with given coordinates. 
        /// </summary>
        /// <param name="x">X coord.</param>
        /// <param name="y">Y coord.</param>
        /// <param name="z">Z coord.</param>
        public Vector(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        /// <summary>
        /// Add another Vector to this.
        /// </summary>
        /// <param name="v">The vector to add.</param>
        /// <returns>The combined Vector.</returns>
        public Vector Add(Vector v) {
            return new Vector(X + v.X, Y + v.Y, Z + v.Z);
        }

        public static Vector operator +(Vector v1, Vector v2) {
            return v1.Add(v2);
        }

        /// <summary>
        /// Subtract another Vector from this.
        /// </summary>
        /// <param name="v">The Vector to subtract.</param>
        /// <returns>The calculated Vector.</returns>
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
