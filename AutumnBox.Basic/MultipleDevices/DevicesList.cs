/* =============================================================================*\
*
* Filename: DevicesList.cs
* Description: 
*
* Version: 1.0
* Created: 9/16/2017 03:48:19(UTC+8:00)
* Compiler: Visual Studio 2017
* 
* Author: zsh2401
* Company: I am free man
*
\* =============================================================================*/
using AutumnBox.Basic.Device;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AutumnBox.Basic.MultipleDevices
{
    /// <summary>
    /// �豸�б�
    /// </summary>
    public class DevicesList : List<DeviceBasicInfo>, IEquatable<DevicesList>
    {

        /// <summary>
        /// ����豸�б��Ƿ����ĳ̨�豸
        /// </summary>
        /// <param name="devInfo">�豸��Ϣ</param>
        /// <returns></returns>
        public new bool Contains(DeviceBasicInfo devInfo)
        {
            var haves = from _devInfo in this
                        where _devInfo == devInfo
                        select _devInfo;
            return haves.Count() > 0;
        }
        /// <summary>
        /// ���豸�б���кϲ�
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static DevicesList operator +(DevicesList left, DevicesList right)
        {
            var tmp = new DevicesList();
            tmp.AddRange(left);
            tmp.AddRange(right);
            return tmp;
        }
        /// <summary>
        /// �ж������豸�б�������Ƿ�һ��
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(DevicesList left, DevicesList right)
        {
            return left.Equals(right);
        }
        /// <summary>
        /// �ж������豸�б�������Ƿ�һ��
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(DevicesList left, DevicesList right)
        {
            return !(left == right);
        }
        /// <summary>
        /// �ж��б������Ƿ�һ��
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(DevicesList other)
        {
            if (Count != other.Count) return false;
            foreach (DeviceBasicInfo info in this)
            {
                if (!other.Contains(info)) return false;
            }
            return true;
        }
        /// <summary>
        /// �ж������Ƿ�һ��
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj is DevicesList)
            {
                return base.Equals((DevicesList)obj);
            }
            else
            {
                return base.Equals(obj);
            }
        }

#pragma warning disable CS1591 // ȱ�ٶԹ����ɼ����ͻ��Ա�� XML ע��
        public override int GetHashCode()
#pragma warning restore CS1591 // ȱ�ٶԹ����ɼ����ͻ��Ա�� XML ע��
        {
            return base.GetHashCode();
        }
    }
}
