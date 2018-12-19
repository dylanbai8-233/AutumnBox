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

namespace AutumnBox.GUI.Util.OS
{
    internal static class NativeMethods
    {
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

        #region HelpButtonHelper
        [DllImport("user32.dll")]
        public static extern uint GetWindowLong(IntPtr hwnd, int index);

        [DllImport("user32.dll")]
        public static extern int SetWindowLong(IntPtr hwnd, int index, uint newStyle);

        [DllImport("user32.dll")]
        public static extern bool SetWindowPos(IntPtr hwnd, IntPtr hwndInsertAfter, int x, int y, int width, int height, uint flags);
        #endregion
    }
}
