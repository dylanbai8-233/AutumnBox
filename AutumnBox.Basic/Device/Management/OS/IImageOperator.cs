﻿/*************************************************
** auth： zsh2401@163.com
** date:  2018/8/29 4:40:55 (UTC +8:00)
** desc： ...
*************************************************/
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutumnBox.Basic.Device.Management.OS
{
    public interface IImageOperator
    {
        void FlashRecovery(FileInfo fileOnPC);
        void FlashBoot(FileInfo fileOnPC);
    }
}
