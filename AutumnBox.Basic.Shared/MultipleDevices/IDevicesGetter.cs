/* =============================================================================*\
*
* Filename: IDevicesGetter.cs
* Description: 
*
* Version: 1.0
* Created: 9/27/2017 02:45:52(UTC+8:00)
* Compiler: Visual Studio 2017
* 
* Author: zsh2401
* Company: I am free man
*
\* =============================================================================*/

using AutumnBox.Basic.Device;
using System.Collections.Generic;

namespace AutumnBox.Basic.MultipleDevices
{
    /// <summary>
    /// �豸��ȡ��
    /// </summary>
    public interface IDevicesGetter
    {
        /// <summary>
        /// ��ȡ�豸
        /// </summary>
        /// <returns></returns>
        IEnumerable<IDevice> GetDevices();
    }
}
