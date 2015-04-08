using System.IO;

namespace WEBUIautomation.Utils
{
    public static class DirectoryHelper
    {
        public static void ForceDelete(string path)
        {

            if (!Directory.Exists(path))
            {
                return;
            }

            var baseFolder = new DirectoryInfo(path);

            foreach (var item in baseFolder.EnumerateDirectories("*", SearchOption.AllDirectories))
            {
                item.Attributes = ResetAttributes(item.Attributes);
            }

            foreach (var item in baseFolder.EnumerateFiles("*", SearchOption.AllDirectories))
            {
                item.Attributes = ResetAttributes(item.Attributes);
            }

            baseFolder.Delete(true);
        }

        #region Helpers

        private static FileAttributes ResetAttributes(FileAttributes attributes)
        {
            return attributes & ~(FileAttributes.Archive | FileAttributes.ReadOnly | FileAttributes.Hidden);
        }

        #endregion
    }
}
