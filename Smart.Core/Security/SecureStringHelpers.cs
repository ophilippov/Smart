﻿using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Smart.Core
{
    /// <summary>
    /// Helpers for the <see cref="SecureString"/> class
    /// </summary>
    public static class SecureStringHelpers
    {
        /// <summary>
        /// Unsecures a <see cref="SecureString"/> to plain text
        /// </summary>
        /// <param name="secureString">The secure string</param>
        /// <returns></returns>
        public static string Unsecure(this SecureString secureString)
        {
            //Make sure we have a secure string
            if (secureString == null) return string.Empty;

            //Get a pointer for an unsecure sting in memory
            var unmanagedString = IntPtr.Zero;

            try
            {
                //Unsecures this string
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(secureString);
                return Marshal.PtrToStringUni(unmanagedString);
            }
            finally
            {
                //Clean up any memory allocation
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }
        }
    }
}
