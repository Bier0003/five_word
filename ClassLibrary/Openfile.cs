namespace five_word.Library

{
    public class Openfile
    {
        private string _File;
        
        public Openfile(string fileName)  // constructor method for class
        {                                   // able to support file change
            _File = fileName;
        }

        public Stream GetFileStream()
        {
            return new FileStream(_File, FileMode.Open);
        }
    }
}
 





