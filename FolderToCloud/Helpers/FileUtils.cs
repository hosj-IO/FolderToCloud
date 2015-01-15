using System.Collections.Generic;
using System.IO;
using FolderToCloud.DataClasses;
using FolderToCloud.Properties;

namespace FolderToCloud.Helpers
{
    public static class FileUtils
    {
        /// <summary>
        /// Retrieves the links from file.
        /// </summary>
        /// <returns>The list of all the links in the current saved file.</returns>
        public static List<Link> RetrieveLinksFromFile()
        {
            List<Link> links = new List<Link>();
            //Retrieve links from the xml
            if (File.Exists(Resources.FileName))
            {
                string rawData = File.ReadAllText(Resources.FileName);
                //Convert rawData to a list of Links
                links = Utils.FromXML<List<Link>>(rawData);
            }
            return links;
        }

        /// <summary>
        /// Appends the link to file.
        /// </summary>
        /// <param name="link">The link.</param>
        /// <param name="links">The links.</param>
        public static void AppendLinkToFile(Link link, List<Link> links)
        {
            links.Add(link);
            WriteLinksToFile(links);
        }

        /// <summary>
        /// Writes the links to file.
        /// </summary>
        /// <param name="links">The links.</param>
        private static void WriteLinksToFile(List<Link> links)
        {
            string rawData = Utils.ToXML(links);
            File.WriteAllText(Resources.FileName, rawData);
        }

        /// <summary>
        /// Removes the link from file.
        /// </summary>
        /// <param name="link">The link.</param>
        /// <param name="links">The links.</param>
        public static void RemoveLinkFromFile(Link link, List<Link> links)
        {
            links.Remove(link);
            WriteLinksToFile(links);
        }

        /// <summary>
        /// Removes the link.
        /// </summary>
        /// <param name="link">The link.</param>
        /// <param name="links">Link Collection</param>
        public static void RemoveLink(Link link, List<Link> links)
        {
            Directory.Delete(link.LocalPath);
            RemoveLinkFromFile(link, links);

        }
    }
}
