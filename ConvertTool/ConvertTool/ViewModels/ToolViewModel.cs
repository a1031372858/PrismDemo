using System;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.IO;
using Prism.Commands;
using Prism.Mvvm;
using System.Windows.Forms;
using Common.Events;
using Prism.Events;
using Common.Bases;

namespace ConvertTool.ViewModels
{
    public class ToolViewModel : ViewModelBase
    {
        private string _headerRegion = "HeaderRegion";

        public string HeaderRegion
        {
            set => SetProperty(ref _headerRegion, value);
            get => _headerRegion;
        }
        private string _csvFilePath;

        public string CsvFilePath
        {
            set => SetProperty(ref _csvFilePath, value);
            get => _csvFilePath;
        }
        public DelegateCommand PathSelectCommand { set; get; }

        public DelegateCommand CancelCommand { set; get; }

        public DelegateCommand FileOutputCommand { set; get; }

        protected override void RegisterProperties()
        {
            CsvFilePath = string.Empty;
        }

        protected override void RegisterCommands()
        {
            PathSelectCommand = new DelegateCommand(PathSelect);
            CancelCommand = new DelegateCommand(Cancel);
            FileOutputCommand = new DelegateCommand(FileOutput);
        }

        protected override void RegisterEvents()
        {
            EventAggregator.GetEvent<MessageEvent>().Subscribe(o =>
            {
                Console.WriteLine("111");
            });
        }

        private void FileOutput()
        {
            if (Directory.Exists(CsvFilePath))
            {
                var filePath = $@"{CsvFilePath}\User.csv";
                if (File.Exists(filePath))
                {
                    switch (MessageBox.Show("文件已存在，是否覆盖", "请确认", MessageBoxButtons.YesNoCancel))
                    {
                        case DialogResult.None:
                            break;
                        case DialogResult.OK:
                            break;
                        case DialogResult.Cancel:
                            return;
                        case DialogResult.Abort:
                            break;
                        case DialogResult.Retry:
                            break;
                        case DialogResult.Ignore:
                            break;
                        case DialogResult.Yes:
                            File.Delete(filePath);
                            break;
                        case DialogResult.No:
                            return;
                        default:
                            return;
                    }
                }

                var fileStream = File.Create(filePath);
                using (fileStream)
                {
                    fileStream.Write(new byte[] { 1, 2, 3 }, 0, 1);
                }

                Process.Start(filePath);
            }

        }

        private void Cancel()
        {
            HeaderRegion = "111";
        }

        private void PathSelect()
        {
            var dialog = new FolderBrowserDialog();
            dialog.ShowDialog();
            Console.WriteLine(dialog.SelectedPath);
            CsvFilePath = dialog.SelectedPath;
        }
    }
}