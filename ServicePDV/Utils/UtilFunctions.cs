namespace ServicePDV.Utils
{
    public static class UtilFunctions
    {
        public static string changeDimensionOfPNG(string imagePath, int newWidth, int newHeight)
        {
            return imagePath.Replace("64x64", String.Format("{0}x{1}", newWidth, newHeight));
        }
    }
}
