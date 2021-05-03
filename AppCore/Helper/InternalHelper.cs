using System.Linq;
using System.Net.NetworkInformation;

namespace AppCore.Helper
{
    internal static class InternalHelper
    {
        public static string GetMachinecMacAddress()
        {
            var nics = NetworkInterface.GetAllNetworkInterfaces();
            var sMacAddress = string.Empty;
            foreach (var adapter in nics)
            {
                if (adapter.OperationalStatus != OperationalStatus.Up) continue;
                sMacAddress = string.Join("-",
                        (from z in adapter.GetPhysicalAddress().GetAddressBytes() select z.ToString("X2")).ToArray());
                if (sMacAddress != string.Empty)
                    break;
            }
            return sMacAddress;
        }
    }
}
