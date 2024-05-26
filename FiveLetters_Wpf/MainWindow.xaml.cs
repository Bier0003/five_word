using five_word.Library;
using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
namespace FiveLetters_Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string openFileDialog;
        private ObservableCollection<string> openFiles;
        public string fileName;

        public object FilePathTextBox { get; private set; }
        public string FileName { get; private set; }

        public MainWindow()
        {
            InitializeComponent();

        }
       
        private object _File;

        public class UploadFile()
        {
            public string FileName { get; set; }
            public string FilePath { get; set; }
        }
        

        public void UploadButton_Click(object sender, RoutedEventArgs e)
        {

            {
                try
                {
                    CombinationBox.Text = "";
                    MillisecondBox.Text = "";
                    WordCombinationList.Items.Clear();

                    Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
                    if (openFileDialog.ShowDialog() == true)
                    {
                        string fileName = openFileDialog.FileName;


                        MessageBox.Show("File opened successfully.");
                        FilePathText.Text = fileName;
                        var openFile = new Openfile(FilePathText.Text);
                        var wordLoader = new ValidWordLoader();
                        var wordSorter = new WordSorter();

                        var stopWatch = Stopwatch.StartNew();
                        var loadedWords = wordLoader.ReadFileFromFileStream(openFile.GetFileStream());
                        var sortedWords = wordSorter.FilterWords(loadedWords);
                        var matchedWords = wordSorter.MatchWord(sortedWords);
                        stopWatch.Stop();

                        CombinationBox.Text = matchedWords.Count.ToString();
                        MillisecondBox.Text = stopWatch.ElapsedMilliseconds.ToString();
                        foreach (var matchedWordList in matchedWords)
                            WordCombinationList.Items.Add(String.Join(" ", matchedWordList));
                    }
                    else
                    {
                        MessageBox.Show("No file selected.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }


        }


        private OpenFileDialog Openfile(object fileName)
        {
            throw new NotImplementedException();
        }

        

        private void Button_Save_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            var saveFileDialogValue = saveFileDialog.ShowDialog();
            if (saveFileDialogValue.HasValue && saveFileDialogValue.Value)
            {
                var filename = saveFileDialog.FileName;
                List<string> words = new List<string>();
                foreach(var item in WordCombinationList.Items)
                    words.Add(item.ToString());
                File.WriteAllLines(filename, words);
                MessageBox.Show("File saved successfully.");
            }
        }

        private void CombinationBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }
          public int Run()
        {
            var words = ReadFileFromFile(_File);
            List<string> validWords = FilterWords(words);

            Result(validWords);

            var wordpairs = MatchWord(validWords); //declar wordpair
            //Console.WriteLine($"\nFund {wordpairs} combinations");

            return wordpairs;
        }

        private int MatchWord(List<string> validWords)
        {
            throw new NotImplementedException();
        }

        private List<string> FilterWords(List<string> words)
        {
            throw new NotImplementedException();
        }

        private void Result(List<string> validWords)
        {
            throw new NotImplementedException();
        }

        private List<string> ReadFileFromFile(object file)
        {
            throw new NotImplementedException();
        }
    }
}






