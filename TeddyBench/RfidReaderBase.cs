using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TeddyBench.Proxmark3;

namespace TeddyBench
{
    public abstract class RfidReaderBase
    {
        [Flags]
        public enum eDeviceInfo
        {
            None = 0,
            BootromPresent = 1,
            OsImagePresent = 2,
            ModeBootrom = 4,
            ModeOs = 8,
            UnderstandStartFlash = 16
        }

        public event EventHandler<string> UidFound;
        public event EventHandler<string> DeviceFound;
        public event EventHandler<FlashRequestContext> FlashRequest;
        public event EventHandler<bool> FlashResult;

        //The event-invoking method that derived classes can override.
        protected virtual void OnUidFound(string e)
        {
            // Safely raise the event for all subscribers
            UidFound?.Invoke(this, e);
        }
        protected virtual void OnDeviceFound(string e)
        {
            // Safely raise the event for all subscribers
            DeviceFound?.Invoke(this, e);
        }
        protected virtual void OnFlashRequest(FlashRequestContext e)
        {
            // Safely raise the event for all subscribers
            FlashRequest?.Invoke(this, e);
        }
        protected virtual void OnFlashResult(bool e)
        {
            // Safely raise the event for all subscribers
            FlashResult?.Invoke(this, e);
        }

        public SerialPort Port { get; protected set; }
        public string CurrentPort { get; protected set; }
        public eDeviceInfo DeviceInfo = eDeviceInfo.None;

        public string HardwareType = "";
        public bool UnlockSupported = false;
        public float AntennaVoltage = 0.0f;
        public bool Connected = false;

        public virtual void Start() { }
        public virtual void Stop() { }

        internal virtual void EnterConsole() { }
        internal virtual void ExitConsole() { }

        internal virtual byte[] ReadMemory()
        {
            return null;
        }

        internal virtual void EmulateTag(byte[] data) { }

        public virtual void EnterBootloader(string fileName) { }
        internal virtual MeasurementResult MeasureAntenna(eMeasurementType type = eMeasurementType.Both)
        {
            return null;
        }
    }
}
