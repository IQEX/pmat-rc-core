﻿#if WIN32
namespace RC.Framework.Native.Win32.API
{
    using System;
    /// <summary>
    /// Values for SetWindowPos call.
    /// </summary>
    public static class HWndValues
    {
        /// <summary>
        /// Places the window at the bottom of the Z order. If the hWnd parameter identifies a topmost window, the window loses its topmost status and is placed at the bottom of all other windows.
        /// </summary>
        public static readonly IntPtr HWND_BOTTOM = new IntPtr(1);

        /// <summary>
        /// Places the window above all non-topmost windows (that is, behind all topmost windows). This flag has no effect if the window is already a non-topmost window.
        /// </summary>
        public static readonly IntPtr HWND_NOTOPMOST = new IntPtr(-2);
        
        /// <summary>
        /// Places the window at the top of the Z order.
        /// </summary>
        public static readonly IntPtr HWND_TOP = new IntPtr(0);

        /// <summary>
        /// Places the window above all non-topmost windows. The window maintains its topmost position even when it is deactivated.
        /// </summary>
        public static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);

    }
}
#endif