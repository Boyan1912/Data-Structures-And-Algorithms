namespace Task3
{
    using System;
    using System.IO;
    using System.Linq;

    public class Folder
    {
        private string name;
        private File[] files;
        private Folder[] childFolders;

        public Folder(string folderName)
        {
            this.Name = folderName;
            this.Files = new File[0];
            this.ChildFolders = new Folder[0];
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public File[] Files
        {
            get
            {
                return this.files;
            }
            set
            {
                try
                {
                    var di = new DirectoryInfo(this.Name);
                    var filesInfo = di.GetFiles();
                    this.files = new File[filesInfo.Length];

                    for (int i = 0; i < filesInfo.Length; i++)
                    {
                        this.files[i] = new File(filesInfo[i].Name, filesInfo[i].Length);
                    }
                }
                catch (UnauthorizedAccessException)
                {
                }
            }
        }

        public Folder[] ChildFolders
        {
            get { return this.childFolders; }

            set
            {
                try
                {
                    var folderNames = Directory.EnumerateDirectories(this.Name).ToList();

                    this.childFolders = new Folder[folderNames.Count];

                    for (int i = 0; i < folderNames.Count; i++)
                    {
                        this.childFolders[i] = new Folder(folderNames[i]);
                    }
                }
                catch (UnauthorizedAccessException)
                {
                }
            }
        }
    }
}
