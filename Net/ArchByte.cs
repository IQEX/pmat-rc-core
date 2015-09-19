﻿// =====================================//==============================================================//
//                                      //                                                              //
// Source="root\\Net\\AtchByte.cs"      //             Copyright © Of Fire Twins Wesp 2015              //
// Author= {"Callada", "Another"}       //                                                              //
// Project="Rc.Framework"               //                  Alise Wesp & Yuuki Wesp                     //
// Version File="4.0"                   //                                                              //
// License="root\\LICENSE"              //                                                              //
// LicenseType="MIT"                    //                                                              //
// =====================================//==============================================================//
using System;
using System.IO;
using System.Text;

namespace Rc.Framework.Net
{
    public class ArchByteBox
    {
        protected MemoryStream nMStream;
        protected int Index = 0;
        protected ArchByteBox(Byte[] bt)
        {
            nMStream = new MemoryStream(bt);
        }
        protected ArchByteBox()
        {
            nMStream = new MemoryStream();
        }
        public static IArchByteBoxWriter InvokeWriter()
        {
            return new ArchByteBoxWriter();
        }
        public static IArchByteBoxReader InvokeReader(Byte[] bt)
        {
            return new ArchByteBoxReader(bt);
        }
    }
    public class ArchByteBoxWriter : ArchByteBox, IArchByteBoxWriter
    {
        internal ArchByteBoxWriter() : base()
        { }
        void IArchByteBoxWriter.wString(string str)
        {
            if (str.Length > short.MaxValue - 1)
                throw new Exception("Length > short.MaxValue");
            Byte[] @Byte = Encoding.UTF8.GetBytes(str);
            ((IArchByteBoxWriter)this).wShort((short)@Byte.Length);
            nMStream.Write(@Byte, 0, @Byte.Length);
        }
        void IArchByteBoxWriter.wShort(short sht)
        {
            Byte[] @Byte = BitConverter.GetBytes(sht);
            nMStream.Write(@Byte, 0, @Byte.Length);
        }
        void IArchByteBoxWriter.wByte(byte[] data)
        {
            if (data.Length > short.MaxValue / 2 - 1)
                throw new Exception("Length > short.MaxValue / 2");
            ((IArchByteBoxWriter)this).wShort((short)data.Length);
            nMStream.Write(data, 0, data.Length);
        }
        byte[] IArchByteBoxWriter.GetAll()
        {
            return nMStream.ToArray();
        }
        void IArchByteBoxWriter.wFloat(float flt)
        {
            Byte[] @Byte = BitConverter.GetBytes(flt);
            nMStream.Write(@Byte, 0, @Byte.Length);
        }
        void IArchByteBoxWriter.wLong(long lng)
        {
            Byte[] @Byte = BitConverter.GetBytes(lng);
            nMStream.Write(@Byte, 0, @Byte.Length);
        }
        void IArchByteBoxWriter.wGUID(Guid g)
        {
            nMStream.Write(g.ToByteArray(), 0, g.ToByteArray().Length);
        }
        IArchByteBoxWriter IArchByteBoxWriter.Clone()
        {
            return (IArchByteBoxWriter)this.MemberwiseClone();
        }
        void IArchByteBoxWriter.wDateTime(DateTime DT)
        {
            Byte[] @Byte = BitConverter.GetBytes(DT.Ticks);
            nMStream.Write(@Byte, 0, @Byte.Length);
        }
        void IArchByteBoxWriter.wInt(int it)
        {
            Byte[] @Byte = BitConverter.GetBytes(it);
            nMStream.Write(@Byte, 0, @Byte.Length);
        }
        void IArchByteBoxWriter.wULong(ulong ulng)
        {
            Byte[] @Byte = BitConverter.GetBytes(ulng);
            nMStream.Write(@Byte, 0, @Byte.Length);
        }
    }
    public class ArchByteBoxReader : ArchByteBox, IArchByteBoxReader
    {
        internal ArchByteBoxReader(byte[] bt) : base(bt)
        { }
        string IArchByteBoxReader.rString()
        {
            Byte[] @Byte = new byte[((IArchByteBoxReader)this).rShort()];
            nMStream.Read(@Byte, 0, @Byte.Length);
            return Encoding.UTF8.GetString(@Byte);
        }
        short IArchByteBoxReader.rShort()
        {
            byte[] @Byte = new byte[sizeof(short)];
            nMStream.Read(@Byte, 0, sizeof(short));
            return BitConverter.ToInt16(@Byte, 0);
        }
        byte[] IArchByteBoxReader.rByte()
        {
            Byte[] @Byte = new byte[((IArchByteBoxReader)this).rShort()];
            nMStream.Read(@Byte, 0, @Byte.Length);
            return @Byte;
        }
        float IArchByteBoxReader.rFloat()
        {
            byte[] @Byte = new byte[sizeof(float)];
            nMStream.Read(@Byte, 0, sizeof(float));
            return BitConverter.ToSingle(@Byte, 0);
        }
        int IArchByteBoxReader.rInt()
        {
            byte[] @Byte = new byte[sizeof(int)];
            nMStream.Read(@Byte, 0, sizeof(int));
            return BitConverter.ToInt32(@Byte, 0);
        }
        long IArchByteBoxReader.rLong()
        {
            byte[] @Byte = new byte[sizeof(long)];
            nMStream.Read(@Byte, 0, sizeof(long));
            return BitConverter.ToInt64(@Byte, 0);
        }
        Guid IArchByteBoxReader.rGUID()
        {
            byte[] @Byte = new byte[Guid.Empty.ToByteArray().Length];
            nMStream.Read(@Byte, 0, Guid.Empty.ToByteArray().Length);
            return new Guid(@Byte);
        }
        IArchByteBoxReader IArchByteBoxReader.Clone()
        {
            return (IArchByteBoxReader)this.MemberwiseClone();
        }
        DateTime IArchByteBoxReader.rDateTime()
        {
            byte[] @Byte = new byte[sizeof(long)];
            nMStream.Read(@Byte, 0, sizeof(long));
            return new DateTime(BitConverter.ToInt64(@Byte, 0));
        }
        ulong IArchByteBoxReader.rULong()
        {
            byte[] @Byte = new byte[sizeof(ulong)];
            nMStream.Read(@Byte, 0, sizeof(ulong));
            return BitConverter.ToUInt64(@Byte, 0);
        }
    }
}