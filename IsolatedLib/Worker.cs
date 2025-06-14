using System;
using SharedLib;

namespace IsolatedLib
{
    /// <summary>
    /// Must NOT be used in the main AppDomain.
    /// </summary>
    public class Worker : MarshalByRefObject, IWorker
    {
        public string DoWork(ISomeData sd)
        {
            var buffType = typeof(System.Buffers.ArrayPool<byte>);
            var memType = typeof(System.Memory<byte>);
            return $"OK - ComDotNetLib loaded.${Environment.NewLine}System.Buffers version: {buffType.Assembly.FullName}${Environment.NewLine}System.Memory version: {memType.Assembly.FullName}";
            return $"Isolated Worker running in AppDomain: {AppDomain.CurrentDomain.FriendlyName}";
        }
    }
}