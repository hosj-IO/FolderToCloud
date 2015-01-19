using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using FolderToCloud.DataClasses;
using FolderToCloud.Properties;

namespace FolderToCloud.Helpers
{
    public static class Utils
    {
        public static T FromXML<T>(string xml)
        {
            using (StringReader stringReader = new StringReader(xml))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                return (T)serializer.Deserialize(stringReader);
            }
        }

        public static string ToXML<T>(T obj)
        {
            using (StringWriter stringWriter = new StringWriter(new StringBuilder()))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                xmlSerializer.Serialize(stringWriter, obj);
                return stringWriter.ToString();
            }
        }

        /// <summary>
        /// Executes commands needed to make a link.
        /// </summary>
        /// <param name="link">The link.</param>
        /// <param name="shouldMoveBeDone">Boolean that decides whether a move of the local folder has to be done.</param>
        public static void ExecuteLinkCommands(Link link, bool shouldMoveBeDone)
        {
            if (shouldMoveBeDone)
            {
                //Rename the local path to make the Link creation possible
                Directory.Move(link.LocalPath, link.ModifiedLocalPath);
            }
            else
            {
                Directory.Delete(link.LocalPath);
            }

            //Create the link
            string command = string.Format(Resources.mkLinkCommand, link.LocalPath, link.CloudPath);
            System.Diagnostics.Process.Start(Resources.CmdProcessName, command);

            if (shouldMoveBeDone)
            {
                //Move content of the modified Path to the Cloudpath
                if (CopyFolderContents(link.ModifiedLocalPath, link.CloudPath))
                {
                    //Remove the modified folder.
                    Directory.Delete(link.ModifiedLocalPath, true);
                }
            }
        }

        /// <summary>
        /// Copies the folder contents.
        /// </summary>
        /// <param name="sourcePath">The source path.</param>
        /// <param name="destinationPath">The destination path.</param>
        /// <returns></returns>
        /// <remarks>http://www.codeproject.com/Tips/278248/Recursively-Copy-folder-contents-to-another-in-Csh</remarks>
        public static bool CopyFolderContents(string sourcePath, string destinationPath)
        {
            sourcePath = sourcePath.EndsWith(@"\") ? sourcePath : sourcePath + @"\";
            destinationPath = destinationPath.EndsWith(@"\") ? destinationPath : destinationPath + @"\";

            try
            {
                if (Directory.Exists(sourcePath))
                {
                    if (Directory.Exists(destinationPath) == false)
                    {
                        Directory.CreateDirectory(destinationPath);
                    }

                    foreach (string files in Directory.GetFiles(sourcePath))
                    {
                        FileInfo fileInfo = new FileInfo(files);
                        fileInfo.CopyTo(string.Format(@"{0}\{1}", destinationPath, fileInfo.Name), true);
                    }

                    foreach (string drs in Directory.GetDirectories(sourcePath))
                    {
                        DirectoryInfo directoryInfo = new DirectoryInfo(drs);
                        if (CopyFolderContents(drs, destinationPath + directoryInfo.Name) == false)
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Determines whether the string [path] is a valid path.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns></returns>
        public static bool IsValidPathString(string path)
        {
            if (Directory.Exists(path))
                return true;
            return false;
        }

        /// <summary>
        /// Determines whether both paths are child or parent of one an other.
        /// </summary>
        /// <param name="localPath">The local path.</param>
        /// <param name="cloudPath">The cloud path.</param>
        /// <returns></returns>
        public static bool IsLocalOrCloudNotParentNorChild(string localPath, string cloudPath)
        {
            if (!IsChildOfParent(localPath, cloudPath))
                if (!IsChildOfParent(cloudPath, localPath))
                    return true;
            return false;
        }

        /// <summary>
        /// Determines whether [child path is a child of parent] [the specified child path].
        /// </summary>
        /// <param name="childPath">The child path.</param>
        /// <param name="parentPath">The parent path.</param>
        /// <returns></returns>
        public static bool IsChildOfParent(string childPath, string parentPath)
        {
            string childPathFull = Path.GetFullPath(childPath).ToUpperInvariant();
            string parentPathFull = Path.GetFullPath(parentPath).ToUpperInvariant();

            if (childPathFull.StartsWith(parentPathFull))
                return true;
            return false;
        }

        /// <summary>
        /// Determines whether [is directory empty] [the specified path].
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns></returns>
        public static bool IsDirectoryEmpty(string path)
        {
            return !Directory.EnumerateFileSystemEntries(path).Any();
        }

    }
}
