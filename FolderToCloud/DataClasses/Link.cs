using System.IO;

namespace FolderToCloud.DataClasses
{
    /// <summary>
    /// Link Class which contains all information needed to create links
    /// </summary>
    public class Link
    {

        #region Constructors
        public Link()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Link"/> class.
        /// </summary>
        /// <param name="cloudPath">The cloud path.</param>
        /// <param name="localPath">The local path.</param>
        public Link(string cloudPath, string localPath)
        {
            CloudPath = cloudPath;
            LocalPath = localPath;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the cloud path.
        /// </summary>
        /// <value>
        /// The cloud path.
        /// </value>
        public string CloudPath { get; set; }

        /// <summary>
        /// Gets or sets the local path.
        /// </summary>
        /// <value>
        /// The local path.
        /// </value>
        public string LocalPath
        {
            get { return _localPath; }
            set
            {
                _localPath = value;
                //Set ModifiedLocalPath
                //TODO move this to modifiedLocalPath
                string directoryName = new DirectoryInfo(value).Name;
                string parentPath = Directory.GetParent(value).FullName;
                ModifiedLocalPath = parentPath + "\\_" + directoryName;
            }
        }

        /// <summary>
        /// Gets or sets the modified local path needed to move files.
        /// </summary>
        /// <value>
        /// The modified local path.
        /// </value>
        public string ModifiedLocalPath { get; set; }
        #endregion

        #region Private Properties
        private string _localPath;
        #endregion

        #region Methods
        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return "Local path: " + LocalPath + " is linked to the cloud path: " + CloudPath;
        }

        public string ToShortString()
        {
            DirectoryInfo localInfo = new DirectoryInfo(LocalPath);
            DirectoryInfo cloudInfo = new DirectoryInfo(CloudPath);
            return "Local Folder: " + localInfo.Name + " Cloud Folder:" + cloudInfo.Name;
        }
        #endregion
    }
}
