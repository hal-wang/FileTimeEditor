using MahApps.Metro.Controls;
using System.IO;
using System.Windows;

namespace FileTimeEditor
{
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SelectButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (CreateTime.SelectedDateTime == null && UpdateTime.SelectedDateTime == null)
            {
                MessageBox.Show(this, "请至少选择一个时间", "请选择", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var openFileDialog = new Microsoft.Win32.OpenFileDialog()
            {
                Filter = "All files (*.*)|*.*",
                Multiselect = true,
            };
            var result = openFileDialog.ShowDialog();
            if (result != true)
            {
                return;
            }
            var files = openFileDialog.FileNames;
            if (files.Length == 0) return;

            UpdateFilesTime(files);

            MessageBox.Show(this, "设置完成", "完成", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void UpdateFilesTime(string[] files)
        {
            var createTime = CreateTime.SelectedDateTime;
            var updateTime = UpdateTime.SelectedDateTime;

            foreach (var file in files)
            {
                if (updateTime != null)
                {
                    File.SetLastWriteTime(file, updateTime.Value);
                }
                if (createTime != null)
                {
                    File.SetCreationTime(file, createTime.Value);
                }
            }
        }
    }
}
