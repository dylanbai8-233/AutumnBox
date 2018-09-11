/* =============================================================================*\
*
* Filename: NativeMethods.cs
* Description: 
*
* Version: 1.0
* Created: 10/6/2017 04:12:10(UTC+8:00)
* Compiler: Visual Studio 2017
* 
* Author: zsh2401
* Company: I am free man
*
\* =============================================================================*/
using System;
using System.Runtime.InteropServices;
using static AutumnBox.GUI.Util.UI.BlurHelper;

namespace AutumnBox.GUI.Util.OS
{
    internal static class NativeMethods
    {
        [DllImport("user32.dll")]
        internal static extern int SetWindowCompositionAttribute(IntPtr hwnd, ref WindowCompositionAttributeData data);
        [DllImport("kernel32.dll", EntryPoint = "SetProcessWorkingSetSize")]
        internal static extern int SetProcessWorkingSetSize(IntPtr process, int minSize, int maxSize);
        [DllImport("newdev.dll", SetLastError = true)]
        internal static extern bool DiInstallDriver
        (
        [In] IntPtr hwndParent,
        [In] string FullInfPath,
        [In] uint Flags,
        [Out] bool NeedReboot
        );
        /// �ú��������ɲ�ͬ�̲߳����Ĵ��ڵ���ʾ״̬
        /// </summary>
        /// <param name="hWnd">���ھ��</param>
        /// <param name="cmdShow">ָ�����������ʾ���鿴����ֵ�б������ShowWlndow������˵������</param>
        /// <returns>�������ԭ���ɼ�������ֵΪ���㣻�������ԭ�������أ�����ֵΪ��</returns>
        [DllImport("User32.dll")]
        public static extern bool ShowWindowAsync(IntPtr hWnd, int cmdShow);
        /// <summary>
        ///  �ú���������ָ�����ڵ��߳����õ�ǰ̨�����Ҽ���ô��ڡ���������ת��ô��ڣ���Ϊ�û��ĸ��ֿ��ӵļǺš�
        ///  ϵͳ������ǰ̨���ڵ��̷߳����Ȩ���Ը��������̡߳� 
        /// </summary>
        /// <param name="hWnd">�������������ǰ̨�Ĵ��ھ��</param>
        /// <returns>�������������ǰ̨������ֵΪ���㣻�������δ������ǰ̨������ֵΪ��</returns>
        [DllImport("User32.dll")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

    }
}
