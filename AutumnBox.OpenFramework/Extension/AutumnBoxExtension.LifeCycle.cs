﻿/*************************************************
** auth： zsh2401@163.com
** date:  2018/8/1 0:40:51 (UTC +8:00)
** desc： ...
*************************************************/
using AutumnBox.Basic.Device;
using AutumnBox.OpenFramework.Content;
using AutumnBox.OpenFramework.Open;

namespace AutumnBox.OpenFramework.Extension
{

    /// <summary>
    /// 标准的秋之盒拓展基类
    /// </summary>
    [ExtName("无名拓展")]
    [ExtName("Unknown extension", Lang = "en-us")]
    [ExtAuth("佚名")]
    [ExtAuth("Anonymous", Lang = "en-us")]
    [ExtDesc("...")]
    [ExtVersion(1, 0, 0)]
    [ExtRequiredDeviceStates(DeviceState.None)]
    [ExtMinApi(8)]
    [ExtTargetApi]
    [ExtRunAsAdmin(false)]
    [ExtRequireRoot(false)]
    [ExtOfficial(false)]
    //[ExtAppProperty("com.miui.fm","Fuck")]
    public abstract partial class AutumnBoxExtension : Context
    {
        /// <summary>
        /// 日志标签
        /// </summary>
        public override string LoggingTag => ExtName;
        /// <summary>
        /// 主函数
        /// </summary>
        public abstract int Main();
        /// <summary>
        /// 当用户要求终止时调用
        /// </summary>
        /// <returns></returns>
        public virtual bool OnStopCommand()
        {
            return true;
        }
    }
}
