namespace Task3
{
    using System.IO;

    public class File
    {
        private string name;
        private long size;

        public File(string fileName, long sizeInBytes)
        {
            this.Name = fileName;
            this.Size = sizeInBytes;
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public long Size
        {
            get
            {
                return this.size;
            }
            set
            {
                this.size = value;
            }
        }
    }
}
