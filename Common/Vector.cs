using System;
using System.Runtime.InteropServices;

namespace Common
{
    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Vector is an utility class for manipulating 2 dimensional
    /// vectors with float components
    /// 
    /// Modified slighty from the CSFML.Net Vector2f.
    /// </summary>
    ////////////////////////////////////////////////////////////
    [StructLayout(LayoutKind.Sequential)]
    public struct Vector : IEquatable<Vector>
    {
        ////////////////////////////////////////////////////////////
        /// <summary>
        /// Construct the vector from its coordinates, at 0 Z depth
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        ////////////////////////////////////////////////////////////
        public Vector(float x, float y) {
            X = x;
            Y = y;
            Z = 0f;
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        /// Construct the vector from its coordinates
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        /// <param name="z">Z coordinate</param>
        ////////////////////////////////////////////////////////////
        public Vector(float x, float y, float z) {
            X = x;
            Y = y;
            Z = z;
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        /// Operator - overload ; returns the opposite of a vector
        /// </summary>
        /// <param name="v">Vector to negate</param>
        /// <returns>-v</returns>
        ////////////////////////////////////////////////////////////
        public static Vector operator -(Vector v) {
            return new Vector(-v.X, -v.Y, -v.Z);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        /// Operator - overload ; subtracts two vectors
        /// </summary>
        /// <param name="v1">First vector</param>
        /// <param name="v2">Second vector</param>
        /// <returns>v1 - v2</returns>
        ////////////////////////////////////////////////////////////
        public static Vector operator -(Vector v1, Vector v2) {
            return new Vector(v1.X - v2.X, v1.Y - v2.Y, v1.Z - v2.Z);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        /// Operator + overload ; add two vectors
        /// </summary>
        /// <param name="v1">First vector</param>
        /// <param name="v2">Second vector</param>
        /// <returns>v1 + v2</returns>
        ////////////////////////////////////////////////////////////
        public static Vector operator +(Vector v1, Vector v2) {
            return new Vector(v1.X + v2.X, v1.Y + v2.Y, v1.Z + v2.Z);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        /// Operator * overload ; multiply a vector by a scalar value
        /// </summary>
        /// <param name="v">Vector</param>
        /// <param name="x">Scalar value</param>
        /// <returns>v * x</returns>
        ////////////////////////////////////////////////////////////
        public static Vector operator *(Vector v, float x) {
            return new Vector(v.X * x, v.Y * x, v.Z * x);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        /// Operator * overload ; multiply a scalar value by a vector
        /// </summary>
        /// <param name="x">Scalar value</param>
        /// <param name="v">Vector</param>
        /// <returns>x * v</returns>
        ////////////////////////////////////////////////////////////
        public static Vector operator *(float x, Vector v) {
            return new Vector(v.X * x, v.Y * x, v.Z * x);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        /// Operator / overload ; divide a vector by a scalar value
        /// </summary>
        /// <param name="v">Vector</param>
        /// <param name="x">Scalar value</param>
        /// <returns>v / x</returns>
        ////////////////////////////////////////////////////////////
        public static Vector operator /(Vector v, float x) {
            return new Vector(v.X / x, v.Y / x, v.Z / x);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        /// Operator == overload ; check vector equality
        /// </summary>
        /// <param name="v1">First vector</param>
        /// <param name="v2">Second vector</param>
        /// <returns>v1 == v2</returns>
        ////////////////////////////////////////////////////////////
        public static bool operator ==(Vector v1, Vector v2) {
            return v1.Equals(v2);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        /// Operator != overload ; check vector inequality
        /// </summary>
        /// <param name="v1">First vector</param>
        /// <param name="v2">Second vector</param>
        /// <returns>v1 != v2</returns>
        ////////////////////////////////////////////////////////////
        public static bool operator !=(Vector v1, Vector v2) {
            return !v1.Equals(v2);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        /// Provide a string describing the object
        /// </summary>
        /// <returns>String description of the object</returns>
        ////////////////////////////////////////////////////////////
        public override string ToString() {
            return "[Vector]" +
                   " X(" + X + ")" +
                   " Y(" + Y + ")" +
                   " Z(" + Z + ")";
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        /// Compare vector and object and checks if they are equal
        /// </summary>
        /// <param name="obj">Object to check</param>
        /// <returns>Object and vector are equal</returns>
        ////////////////////////////////////////////////////////////
        public override bool Equals(object obj) {
            if (obj is Vector)
                return Equals((Vector)obj);
            return base.Equals(obj);
        }

        ///////////////////////////////////////////////////////////
        /// <summary>
        /// Compare two vectors and checks if they are equal
        /// </summary>
        /// <param name="other">Vector to check</param>
        /// <returns>Vectors are equal</returns>
        ////////////////////////////////////////////////////////////
        public bool Equals(Vector other) {
            return (X == other.X) &&
                   (Y == other.Y) &&
                   (Z == other.Z);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        /// Provide a integer describing the object
        /// </summary>
        /// <returns>Integer description of the object</returns>
        ////////////////////////////////////////////////////////////
        public override int GetHashCode() {
            return X.GetHashCode() ^
                   Y.GetHashCode() ^
                   Z.GetHashCode();
        }

        /// <summary>
        /// X (horizontal) component of the vector.
        /// </summary>
        public float X;
        /// <summary>Y (vertical) component of the vector.</summary>
        public float Y;
        /// <summary>
        /// Z (depth) component of the vector.
        /// </summary>
        public float Z;
    }
}
