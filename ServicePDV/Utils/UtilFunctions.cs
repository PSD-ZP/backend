using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace ServicePDV.Utils
{
    public static class UtilFunctions
    {

        public static string changePngDimensionsInUrl(string url, int newSize)
        {
            return url.Replace("64x64", String.Format("{0}x{0}", newSize));
        }

    }
}
