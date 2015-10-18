﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rc.Framework.RMath
{
    /// <summary>
	/// 4D Vector structure with X, Y, Z and W coordinates.
	/// </summary>
	///
	/// <remarks><para>The structure incapsulates X, Y, Z and W coordinates of a 4D vector and
	/// provides some operations with it.</para></remarks>
	[Serializable]
    public struct Vector4
    {
        /// <summary>
        /// X coordinate of the vector.
        /// </summary>
        public float X;
        /// <summary>
        /// Y coordinate of the vector.
        /// </summary>
        public float Y;
        /// <summary>
        /// Z coordinate of the vector.
        /// </summary>
        public float Z;
        /// <summary>
        /// W coordinate of the vector.
        /// </summary>
        public float W;
        /// <summary>
        /// Returns maximum value of the vector.
        /// </summary>
        ///
        /// <remarks><para>Returns maximum value of all 4 vector's coordinates.</para></remarks>
        public float Max
        {
            get
            {
                float num = (this.X > this.Y) ? this.X : this.Y;
                float num2 = (this.Z > this.W) ? this.Z : this.W;
                if (num <= num2)
                {
                    return num2;
                }
                return num;
            }
        }
        /// <summary>
        /// Returns minimum value of the vector.
        /// </summary>
        ///
        /// <remarks><para>Returns minimum value of all 4 vector's coordinates.</para></remarks>
        public float Min
        {
            get
            {
                float num = (this.X < this.Y) ? this.X : this.Y;
                float num2 = (this.Z < this.W) ? this.Z : this.W;
                if (num >= num2)
                {
                    return num2;
                }
                return num;
            }
        }
        /// <summary>
        /// Returns index of the coordinate with maximum value.
        /// </summary>
        ///
        /// <remarks><para>Returns index of the coordinate, which has the maximum value - 0 for X,
        /// 1 for Y, 2 for Z or 3 for W.</para>
        ///
        /// <para><note>If there are multiple coordinates which have the same maximum value, the
        /// property returns smallest index.</note></para>
        /// </remarks>
        public int MaxIndex
        {
            get
            {
                float num;
                int result;
                if (this.X >= this.Y)
                {
                    num = this.X;
                    result = 0;
                }
                else
                {
                    num = this.Y;
                    result = 1;
                }
                float num2;
                int result2;
                if (this.Z >= this.W)
                {
                    num2 = this.Z;
                    result2 = 2;
                }
                else
                {
                    num2 = this.W;
                    result2 = 3;
                }
                if (num < num2)
                {
                    return result2;
                }
                return result;
            }
        }
        /// <summary>
        /// Returns index of the coordinate with minimum value.
        /// </summary>
        ///
        /// <remarks><para>Returns index of the coordinate, which has the minimum value - 0 for X,
        /// 1 for Y, 2 for Z or 3 for W.</para>
        ///
        /// <para><note>If there are multiple coordinates which have the same minimum value, the
        /// property returns smallest index.</note></para>
        /// </remarks>
        public int MinIndex
        {
            get
            {
                float num;
                int result;
                if (this.X <= this.Y)
                {
                    num = this.X;
                    result = 0;
                }
                else
                {
                    num = this.Y;
                    result = 1;
                }
                float num2;
                int result2;
                if (this.Z <= this.W)
                {
                    num2 = this.Z;
                    result2 = 2;
                }
                else
                {
                    num2 = this.W;
                    result2 = 3;
                }
                if (num > num2)
                {
                    return result2;
                }
                return result;
            }
        }
        /// <summary>
        /// Returns vector's norm.
        /// </summary>
        ///
        /// <remarks><para>Returns Euclidean norm of the vector, which is a
        /// square root of the sum: X<sup>2</sup>+Y<sup>2</sup>+Z<sup>2</sup>+W<sup>2</sup>.</para>
        /// </remarks>
        public float Norm
        {
            get
            {
                return (float)Math.Sqrt((double)(this.X * this.X + this.Y * this.Y + this.Z * this.Z + this.W * this.W));
            }
        }
        /// <summary>
        /// Returns square of the vector's norm.
        /// </summary>
        ///
        /// <remarks><para>Return X<sup>2</sup>+Y<sup>2</sup>+Z<sup>2</sup>+W<sup>2</sup>, which is
        /// a square of <see cref="P:Rc.Framework.RMath.Math.Vector4.Norm">vector's norm</see> or a <see cref="M:Rc.Framework.RMath.Math.Vector4.Dot(Rc.Framework.RMath.Math.Vector4,Rc.Framework.RMath.Math.Vector4)">dot product</see> of this vector
        /// with itself.</para></remarks>
        public float Square
        {
            get
            {
                return this.X * this.X + this.Y * this.Y + this.Z * this.Z + this.W * this.W;
            }
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Vector4" /> structure.
        /// </summary>
        ///
        /// <param name="x">X coordinate of the vector.</param>
        /// <param name="y">Y coordinate of the vector.</param>
        /// <param name="z">Z coordinate of the vector.</param>
        /// <param name="w">W coordinate of the vector.</param>
        public Vector4(float x, float y, float z, float w)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
            this.W = w;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Vector4" /> structure.
        /// </summary>
        ///
        /// <param name="value">Value, which is set to all 4 coordinates of the vector.</param>
        public Vector4(float value)
        {
            this.W = value;
            this.Z = value;
            this.Y = value;
            this.X = value;
        }
        /// <summary>
        /// Returns a string representation of this object.
        /// </summary>
        ///
        /// <returns>A string representation of this object.</returns>
        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "{0}, {1}, {2}, {3}", new object[]
            {
                this.X,
                this.Y,
                this.Z,
                this.W
            });
        }
        /// <summary>
        /// Returns array representation of the vector.
        /// </summary>
        ///
        /// <returns>Array with 4 values containing X/Y/Z/W coordinates.</returns>
        public float[] ToArray()
        {
            return new float[]
            {
                this.X,
                this.Y,
                this.Z,
                this.W
            };
        }
        /// <summary>
        /// Adds corresponding coordinates of two vectors.
        /// </summary>
        ///
        /// <param name="vector1">The vector to add to.</param>
        /// <param name="vector2">The vector to add to the first vector.</param>
        ///
        /// <returns>Returns a vector which coordinates are equal to sum of corresponding
        /// coordinates of the two specified vectors.</returns>
        public static Vector4 operator +(Vector4 vector1, Vector4 vector2)
        {
            return new Vector4(vector1.X + vector2.X, vector1.Y + vector2.Y, vector1.Z + vector2.Z, vector1.W + vector2.W);
        }
        /// <summary>
        /// Adds corresponding coordinates of two vectors.
        /// </summary>
        ///
        /// <param name="vector1">The vector to add to.</param>
        /// <param name="vector2">The vector to add to the first vector.</param>
        ///
        /// <returns>Returns a vector which coordinates are equal to sum of corresponding
        /// coordinates of the two specified vectors.</returns>
        public static Vector4 Add(Vector4 vector1, Vector4 vector2)
        {
            return vector1 + vector2;
        }
        /// <summary>
        /// Adds a value to all coordinates of the specified vector.
        /// </summary>
        ///
        /// <param name="vector">Vector to add the specified value to.</param>
        /// <param name="value">Value to add to all coordinates of the vector.</param>
        ///
        /// <returns>Returns new vector with all coordinates increased by the specified value.</returns>
        public static Vector4 operator +(Vector4 vector, float value)
        {
            return new Vector4(vector.X + value, vector.Y + value, vector.Z + value, vector.W + value);
        }
        /// <summary>
        /// Adds a value to all coordinates of the specified vector.
        /// </summary>
        ///
        /// <param name="vector">Vector to add the specified value to.</param>
        /// <param name="value">Value to add to all coordinates of the vector.</param>
        ///
        /// <returns>Returns new vector with all coordinates increased by the specified value.</returns>
        public static Vector4 Add(Vector4 vector, float value)
        {
            return vector + value;
        }
        /// <summary>
        /// Subtracts corresponding coordinates of two vectors.
        /// </summary>
        ///
        /// <param name="vector1">The vector to subtract from.</param>
        /// <param name="vector2">The vector to subtract from the first vector.</param>
        ///
        /// <returns>Returns a vector which coordinates are equal to difference of corresponding
        /// coordinates of the two specified vectors.</returns>
        public static Vector4 operator -(Vector4 vector1, Vector4 vector2)
        {
            return new Vector4(vector1.X - vector2.X, vector1.Y - vector2.Y, vector1.Z - vector2.Z, vector1.W - vector2.W);
        }
        /// <summary>
        /// Subtracts corresponding coordinates of two vectors.
        /// </summary>
        ///
        /// <param name="vector1">The vector to subtract from.</param>
        /// <param name="vector2">The vector to subtract from the first vector.</param>
        ///
        /// <returns>Returns a vector which coordinates are equal to difference of corresponding
        /// coordinates of the two specified vectors.</returns>
        public static Vector4 Subtract(Vector4 vector1, Vector4 vector2)
        {
            return vector1 - vector2;
        }
        /// <summary>
        /// Subtracts a value from all coordinates of the specified vector.
        /// </summary>
        ///
        /// <param name="vector">Vector to subtract the specified value from.</param>
        /// <param name="value">Value to subtract from all coordinates of the vector.</param>
        ///
        /// <returns>Returns new vector with all coordinates decreased by the specified value.</returns>
        public static Vector4 operator -(Vector4 vector, float value)
        {
            return new Vector4(vector.X - value, vector.Y - value, vector.Z - value, vector.W - value);
        }
        /// <summary>
        /// Subtracts a value from all coordinates of the specified vector.
        /// </summary>
        ///
        /// <param name="vector">Vector to subtract the specified value from.</param>
        /// <param name="value">Value to subtract from all coordinates of the vector.</param>
        ///
        /// <returns>Returns new vector with all coordinates decreased by the specified value.</returns>
        public static Vector4 Subtract(Vector4 vector, float value)
        {
            return vector - value;
        }
        /// <summary>
        /// Multiplies corresponding coordinates of two vectors.
        /// </summary>
        ///
        /// <param name="vector1">The first vector to multiply.</param>
        /// <param name="vector2">The second vector to multiply.</param>
        ///
        /// <returns>Returns a vector which coordinates are equal to multiplication of corresponding
        /// coordinates of the two specified vectors.</returns>
        public static Vector4 operator *(Vector4 vector1, Vector4 vector2)
        {
            return new Vector4(vector1.X * vector2.X, vector1.Y * vector2.Y, vector1.Z * vector2.Z, vector1.W * vector2.W);
        }
        /// <summary>
        /// Multiplies corresponding coordinates of two vectors.
        /// </summary>
        ///
        /// <param name="vector1">The first vector to multiply.</param>
        /// <param name="vector2">The second vector to multiply.</param>
        ///
        /// <returns>Returns a vector which coordinates are equal to multiplication of corresponding
        /// coordinates of the two specified vectors.</returns>
        public static Vector4 Multiply(Vector4 vector1, Vector4 vector2)
        {
            return vector1 * vector2;
        }
        /// <summary>
        /// Multiplies coordinates of the specified vector by the specified factor.
        /// </summary>
        ///
        /// <param name="vector">Vector to multiply coordinates of.</param>
        /// <param name="factor">Factor to multiple coordinates of the specified vector by.</param>
        ///
        /// <returns>Returns new vector with all coordinates multiplied by the specified factor.</returns>
        public static Vector4 operator *(Vector4 vector, float factor)
        {
            return new Vector4(vector.X * factor, vector.Y * factor, vector.Z * factor, vector.W * factor);
        }
        /// <summary>
        /// Multiplies coordinates of the specified vector by the specified factor.
        /// </summary>
        ///
        /// <param name="vector">Vector to multiply coordinates of.</param>
        /// <param name="factor">Factor to multiple coordinates of the specified vector by.</param>
        ///
        /// <returns>Returns new vector with all coordinates multiplied by the specified factor.</returns>
        public static Vector4 Multiply(Vector4 vector, float factor)
        {
            return vector * factor;
        }
        /// <summary>
        /// Divides corresponding coordinates of two vectors.
        /// </summary>
        ///
        /// <param name="vector1">The first vector to divide.</param>
        /// <param name="vector2">The second vector to devide.</param>
        ///
        /// <returns>Returns a vector which coordinates are equal to coordinates of the first vector divided by
        /// corresponding coordinates of the second vector.</returns>
        public static Vector4 operator /(Vector4 vector1, Vector4 vector2)
        {
            return new Vector4(vector1.X / vector2.X, vector1.Y / vector2.Y, vector1.Z / vector2.Z, vector1.W / vector2.W);
        }
        /// <summary>
        /// Divides corresponding coordinates of two vectors.
        /// </summary>
        ///
        /// <param name="vector1">The first vector to divide.</param>
        /// <param name="vector2">The second vector to devide.</param>
        ///
        /// <returns>Returns a vector which coordinates are equal to coordinates of the first vector divided by
        /// corresponding coordinates of the second vector.</returns>
        public static Vector4 Divide(Vector4 vector1, Vector4 vector2)
        {
            return vector1 / vector2;
        }
        /// <summary>
        /// Divides coordinates of the specified vector by the specified factor.
        /// </summary>
        ///
        /// <param name="vector">Vector to divide coordinates of.</param>
        /// <param name="factor">Factor to divide coordinates of the specified vector by.</param>
        ///
        /// <returns>Returns new vector with all coordinates divided by the specified factor.</returns>
        public static Vector4 operator /(Vector4 vector, float factor)
        {
            return new Vector4(vector.X / factor, vector.Y / factor, vector.Z / factor, vector.W / factor);
        }
        /// <summary>
        /// Divides coordinates of the specified vector by the specified factor.
        /// </summary>
        ///
        /// <param name="vector">Vector to divide coordinates of.</param>
        /// <param name="factor">Factor to divide coordinates of the specified vector by.</param>
        ///
        /// <returns>Returns new vector with all coordinates divided by the specified factor.</returns>
        public static Vector4 Divide(Vector4 vector, float factor)
        {
            return vector / factor;
        }
        /// <summary>
        /// Tests whether two specified vectors are equal.
        /// </summary>
        ///
        /// <param name="vector1">The left-hand vector.</param>
        /// <param name="vector2">The right-hand vector.</param>
        ///
        /// <returns>Returns <see langword="true" /> if the two vectors are equal or <see langword="false" /> otherwise.</returns>
        public static bool operator ==(Vector4 vector1, Vector4 vector2)
        {
            return vector1.X == vector2.X && vector1.Y == vector2.Y && vector1.Z == vector2.Z && vector1.W == vector2.W;
        }
        /// <summary>
        /// Tests whether two specified vectors are not equal.
        /// </summary>
        ///
        /// <param name="vector1">The left-hand vector.</param>
        /// <param name="vector2">The right-hand vector.</param>
        ///
        /// <returns>Returns <see langword="true" /> if the two vectors are not equal or <see langword="false" /> otherwise.</returns>
        public static bool operator !=(Vector4 vector1, Vector4 vector2)
        {
            return vector1.X != vector2.X || vector1.Y != vector2.Y || vector1.Z != vector2.Z || vector1.W != vector2.W;
        }
        /// <summary>
        /// Tests whether the vector equals to the specified one.
        /// </summary>
        ///
        /// <param name="vector">The vector to test equality with.</param>
        ///
        /// <returns>Returns <see langword="true" /> if the two vectors are equal or <see langword="false" /> otherwise.</returns>
        public bool Equals(Vector4 vector)
        {
            return vector.X == this.X && vector.Y == this.Y && vector.Z == this.Z && vector.W == this.W;
        }
        /// <summary>
        /// Tests whether the vector equals to the specified object.
        /// </summary>
        ///
        /// <param name="obj">The object to test equality with.</param>
        ///
        /// <returns>Returns <see langword="true" /> if the vector equals to the specified object or <see langword="false" /> otherwise.</returns>
        public override bool Equals(object obj)
        {
            return obj is Vector4 && this.Equals((Vector4)obj);
        }
        /// <summary>
        /// Returns the hashcode for this instance.
        /// </summary>
        ///
        /// <returns>A 32-bit signed integer hash code.</returns>
        public override int GetHashCode()
        {
            return this.X.GetHashCode() + this.Y.GetHashCode() + this.Z.GetHashCode() + this.W.GetHashCode();
        }
        /// <summary>
        /// Normalizes the vector by dividing it’s all coordinates with the vector's norm.
        /// </summary>
        ///
        /// <returns>Returns the value of vectors’ norm before normalization.</returns>
        public float Normalize()
        {
            float num = (float)Math.Sqrt((double)(this.X * this.X + this.Y * this.Y + this.Z * this.Z + this.W * this.W));
            float num2 = 1f / num;
            this.X *= num2;
            this.Y *= num2;
            this.Z *= num2;
            this.W *= num2;
            return num;
        }
        /// <summary>
        /// Inverse the vector.
        /// </summary>
        ///
        /// <returns>Returns a vector with all coordinates equal to 1.0 divided by the value of corresponding coordinate
        /// in this vector (or equal to 0.0 if this vector has corresponding coordinate also set to 0.0).</returns>
        public Vector4 Inverse()
        {
            return new Vector4((this.X == 0f) ? 0f : (1f / this.X), (this.Y == 0f) ? 0f : (1f / this.Y), (this.Z == 0f) ? 0f : (1f / this.Z), (this.W == 0f) ? 0f : (1f / this.W));
        }
        /// <summary>
        /// Calculate absolute values of the vector.
        /// </summary>
        ///
        /// <returns>Returns a vector with all coordinates equal to absolute values of this vector's coordinates.</returns>
        public Vector4 Abs()
        {
            return new Vector4(Math.Abs(this.X), Math.Abs(this.Y), Math.Abs(this.Z), Math.Abs(this.W));
        }
        /// <summary>
        /// Calculates dot product of two vectors.
        /// </summary>
        ///
        /// <param name="vector1">First vector to use for dot product calculation.</param>
        /// <param name="vector2">Second vector to use for dot product calculation.</param>
        ///
        /// <returns>Returns dot product of the two specified vectors.</returns>
        public static float Dot(Vector4 vector1, Vector4 vector2)
        {
            return vector1.X * vector2.X + vector1.Y * vector2.Y + vector1.Z * vector2.Z + vector1.W * vector2.W;
        }
        /// <summary>
        /// Converts the vector to a 3D vector.
        /// </summary>
        ///
        /// <returns>Returns 3D vector which has X/Y/Z coordinates equal to X/Y/Z coordinates
        /// of this vector divided by <see cref="F:Rc.Framework.RMath.Math.Vector4.W" />.</returns>
        public Vector3 ToVector3()
        {
            return new Vector3(this.X / this.W, this.Y / this.W, this.Z / this.W);
        }
    }
}
