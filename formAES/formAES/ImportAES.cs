using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace formAES
{
    class ImportAES
    {
        [DllImport("AES.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "?generateKey@@YAPAEXZ")]
        unsafe public static extern byte* generateKey();

        [DllImport("AES.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "?setKey@@YAXPAE@Z")]
        unsafe public static extern void setKey(byte* key);

        [DllImport("AES.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "?encrypt@@YAXPAEH_N@Z")]
        unsafe public static extern byte* encrypt(byte* bytes, int count_blocks, bool isMixing = false);

        [DllImport("AES.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "?decrypt@@YAXPAEH_N@Z")]
        unsafe public static extern byte* decrypt(byte* bytes, int count_blocks, bool isMixing = false);
    }
}
