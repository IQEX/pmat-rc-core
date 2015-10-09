﻿using Rc.Framework.Extension;
using Rc.Framework.Net;
using Rc.Framework.Net.NTCore;
using Rc.Framework.Yaml.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rc.Framework.Native.WMIClass
{
    /// <summary>
    /// Enum to Version Win32
    /// </summary>
    public enum Win32Type : short
    {
        /// <summary>
        /// 1993
        /// 3.1, 3.5, 3.51, 4.0
        /// </summary>
        WindowsNT = 0x1,
        /// <summary>
        /// 2000
        /// 5.0
        /// </summary>
        Windows2000,
        /// <summary>
        /// 2001
        /// 5.2
        /// </summary>
        WindowsXP,
        /// <summary>
        /// 2006
        /// 6.0
        /// </summary>
        WindowsVista,
        /// <summary>
        /// 2009
        /// 6.1
        /// </summary>
        Windows7,
        /// <summary>
        /// 2012
        /// 6.2
        /// </summary>
        Windows8,
        /// <summary>
        /// 2013
        /// 6.3
        /// </summary>
        Windows9, //! or Windows 8.1
        /// <summary>
        /// 2015
        /// 10.0
        /// </summary>
        Windows10,
    }
    /// <summary>
    /// Класс версии Windows
    /// </summary>
    [Serializable]
    [YamlSerialize(YamlSerializeMethod.Content)]
    public class Win32Version : NetworkObject
    {
        /// <summary>
        /// Версия
        /// </summary>
        public string Version;
        /// <summary>
        /// Сборка
        /// </summary>
        public string Build;
        /// <summary>
        /// Тип
        /// </summary>
        public Win32Type TypeWin;
        /// <summary>
        /// This class to Byte array
        /// </summary>
        /// <returns></returns>
        public override byte[] ToByte()
        {
            IArchByteBoxWriter writer = ArchByteBox.InvokeWriter();
            //@ Begin
            writer.wString(Version);
            writer.wString(Build);
            writer.wString(TypeWin.ToString());
            //@ End
            return writer.GetAll();
        }
        /// <summary>
        /// Byte Array to this class
        /// </summary>
        /// <param name="bitBox">Content class</param>
        public override void outByte(byte[] bitBox)
        {
            IArchByteBoxReader reader = ArchByteBox.InvokeReader(bitBox);
            //@ Begin
            Version = reader.rString();
            Build = reader.rString();
            TypeWin = reader.rString().ToEnum<Win32Type>();
            //@ End
        }
    }
}