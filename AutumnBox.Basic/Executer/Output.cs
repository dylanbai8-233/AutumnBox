/* =============================================================================*\
*
* Filename: OutputData.cs
* Description: 
*
* Version: 1.0
* Created: 9/15/2017 16:01:48(UTC+8:00)
* Compiler: Visual Studio 2017
* 
* Author: zsh2401
* Company: I am free man
*
\* =============================================================================*/
namespace AutumnBox.Basic.Executer
{
    using AutumnBox.Basic.Util;
    using AutumnBox.Support.Log;
    using System;
    /// <summary>
    /// �����װ��
    /// </summary>
    public class Output : IPrintable
    {
        /// <summary>
        /// ���е����
        /// </summary>
        public string[] LineAll { get; private set; }

        /// <summary>
        /// ���еı�׼���
        /// </summary>
        public string[] LineOut { get; private set; }

        /// <summary>
        /// ���еı�׼����
        /// </summary>
        public string[] LineError { get; private set; }

        /// <summary>
        /// ���е����
        /// </summary>
        public string All { get; protected set; }

        /// <summary>
        /// ���еı�׼���
        /// </summary>
        public string Out { get; protected set; }
        /// <summary>
        /// ���еı�׼����
        /// </summary>
        public string Error { get; protected set; }

        /// <summary>
        /// �ж�������Ƿ����ĳ���ַ���
        /// </summary>
        /// <param name="str">�ַ���</param>
        /// <param name="ignoreCase">�Ƿ���Դ�Сд</param>
        /// <returns></returns>
        public bool Contains(string str, bool ignoreCase = true)
        {
            if (ignoreCase)
            {
                return All.ToLower().Contains(str.ToLower());
            }
            else
            {
                return All.Contains(str);
            }
        }

        /// <summary>
        /// ��ȡ�������������
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return All.ToString();
        }

        /// <summary>
        /// ����һ���յ�Output����
        /// </summary>
        public Output()
        {
            this.Out = "";
            this.Error = "";
            this.All = "";
        }

        /// <summary>
        /// ����
        /// </summary>
        /// <param name="all">��������</param>
        /// <param name="stdOutput">��׼���</param>
        /// <param name="stdError">��׼����</param>
        public Output(string all, string stdOutput, string stdError = "")
        {
            All = all;
            Out = stdOutput;
            Error = stdError;
            LineAll = all.Split(Environment.NewLine.ToCharArray());
            LineOut = stdOutput.Split(Environment.NewLine.ToCharArray());
            LineError = stdError.Split(Environment.NewLine.ToCharArray());
        }

        /// <summary>
        /// �Կɶ����tag������,����log
        /// </summary>
        /// <param name="tagOrSender"></param>
        /// <param name="printOnRelease"></param>
        public virtual void PrintOnLog(object tagOrSender, bool printOnRelease = false)
        {
            if (printOnRelease)
            {
                Logger.Info(tagOrSender, $"{this.GetType().Name}.PrintOnLog():{Environment.NewLine}{ToString()}");
            }
            else
            {
                Logger.Debug(tagOrSender, $"{this.GetType().Name}.PrintOnLog():{Environment.NewLine}{ToString()}");
            }
        }

        /// <summary>
        /// �Կɶ����tag������,��ӡ�ڿ���̨
        /// </summary>
        /// <param name="tagOrSender"></param>
        public virtual void PrintOnConsole(object tagOrSender)
        {
            Console.WriteLine($"{tagOrSender} {this.GetType().Name}.PrintOnConsole():{Environment.NewLine}{ToString()}");
        }

        /// <summary>
        /// ��ӡ������̨
        /// </summary>
        [Obsolete("Plz use PrintOnConsole(bool printOnRelease=false) to instead", true)]
        public void PrintOnConsole()
        {
            Console.WriteLine($"{this.GetType().Name}.PrintOnConsole(): {this.ToString()}");
        }

        /// <summary>
        /// ��ӡ��log
        /// </summary>
        /// <param name="printOnRelease"></param>
        [Obsolete("Plz use PrintOnLog(object tagOrSender,bool printOnRelease=false) to instead", true)]
        public void PrintOnLog(bool printOnRelease = false)
        {
            if (printOnRelease)
            {
                Logger.Info(this, $"PrintOnLog():{Environment.NewLine}{ToString()}");
            }
            else
            {
                Logger.Debug(this, $"PrintOnLog():{Environment.NewLine}{ToString()}");
            }
        }
    }
}
