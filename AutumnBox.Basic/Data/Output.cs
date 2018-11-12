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
namespace AutumnBox.Basic.Data
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// �����װ��
    /// </summary>
    public class Output : IEquatable<Output>
    {
        /// <summary>
        /// ����������ֶ�Ϊֻ��
        /// </summary>
        public static readonly Output Empty = new Output(String.Empty, String.Empty, String.Empty);
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
            Out = "";
            Error = "";
            All = "";
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
        /// �Ƚ�
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return Equals(obj as Output);
        }

        /// <summary>
        /// �Ƚ�
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Output other)
        {
            return other != null &&
                   //EqualityComparer<string[]>.Default.Equals(LineAll, other.LineAll) &&
                   //EqualityComparer<string[]>.Default.Equals(LineOut, other.LineOut) &&
                   //EqualityComparer<string[]>.Default.Equals(LineError, other.LineError) &&
                   All == other.All &&
                   Out == other.Out &&
                   Error == other.Error;
        }

        /// <summary>
        /// ��ȡHashCode
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            var hashCode = -1661239530;
            //hashCode = hashCode * -1521134295 + EqualityComparer<string[]>.Default.GetHashCode(LineAll);
            //hashCode = hashCode * -1521134295 + EqualityComparer<string[]>.Default.GetHashCode(LineOut);
            //hashCode = hashCode * -1521134295 + EqualityComparer<string[]>.Default.GetHashCode(LineError);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(All);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Out);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Error);
            return hashCode;
        }

        /// <summary>
        /// �Ƚ�
        /// </summary>
        /// <param name="output1"></param>
        /// <param name="output2"></param>
        /// <returns></returns>
        public static bool operator ==(Output output1, Output output2)
        {
            return EqualityComparer<Output>.Default.Equals(output1, output2);
        }

        /// <summary>
        /// ����
        /// </summary>
        /// <param name="output1"></param>
        /// <param name="output2"></param>
        /// <returns></returns>
        public static bool operator !=(Output output1, Output output2)
        {
            return !(output1 == output2);
        }

        /// <summary>
        /// ��ʽת��
        /// </summary>
        /// <param name="value"></param>
        public static implicit operator string(Output value)
        {
            return value.ToString();
        }
    }
}
