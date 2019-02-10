/* =============================================================================*\
*
* Filename: DevicesMonitor.cs
* Description: 
*
* Version: 1.0
* Created: 8/18/2017 22:09:36(UTC+8:00)
* Compiler: Visual Studio 2017
* 
* Author: zsh2401
* Company: I am free man
*
\* =============================================================================*/
using AutumnBox.Basic.Device;
using AutumnBox.Logging;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AutumnBox.Basic.MultipleDevices
{
    /// <summary>
    /// �豸�β������
    /// </summary>
    public class DevicesMonitor
    {
        private static readonly ILogger logger;
        static DevicesMonitor()
        {
            logger = LoggerFactory.Auto<DevicesMonitor>();
        }
        /// <summary>
        /// �豸�β�ʱ��
        /// </summary>
        public event DevicesChangedHandler DevicesChanged;
        private CancellationTokenSource tokenSource;
        private bool isStarted = false;
        /// <summary>
        /// �����
        /// </summary>
        public int Interval { get; set; } = 2000;
        /// <summary>
        /// ��ʼ
        /// </summary>
        public void Start()
        {
            if (isStarted)
            {
                return;
            }
            Task.Run(() =>
            {
                tokenSource = new CancellationTokenSource();
                isStarted = true;
                try
                {
                    Loop();
                }
                catch (Exception ex)
                {
                    logger.Warn("Devices monitor error", ex);
                }
                isStarted = false; ;
            });
        }
        /// <summary>
        /// ѭ������豸��Ϣ
        /// </summary>
        private void Loop()
        {
            IDevicesGetter getter = new DevicesGetter();
            IEnumerable<IDevice> last = getter.GetDevices();
            DevicesChanged?.Invoke(this, new DevicesChangedEventArgs(last));
            IEnumerable<IDevice> _new = null;
            while (!tokenSource.Token.IsCancellationRequested)
            {
                _new = getter.GetDevices();
                if (!_new.DevicesEquals(last))
                {
                    last = _new;
                    DevicesChanged?.Invoke(this, new DevicesChangedEventArgs(last));
                }
                Thread.Sleep(Interval);
            }
        }
        /// <summary>
        /// ȡ��
        /// </summary>
        public void Cancel()
        {
            tokenSource.Cancel();
        }
    }
}
