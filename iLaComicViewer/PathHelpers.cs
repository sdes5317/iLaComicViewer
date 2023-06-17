using System.IO;
using System.Linq;

namespace iLaComicViewer
{
    internal static class PathHelpers
    {

        internal static string[] ResolveFolderOrFilePaths(string[] paths)
        {
            var isSingleAndIsDirectory = paths.Length == 1 && (File.GetAttributes(paths.First()) & FileAttributes.Directory) > 0;
            if (isSingleAndIsDirectory)
            {
                paths = Directory.GetFiles(paths.First());
            }

            return paths;
        }
    }
}