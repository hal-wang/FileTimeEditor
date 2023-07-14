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
            var createTime = CreateTime.SelectedDateTime;
            var updateTime = UpdateTime.SelectedDateTime;

            if (createTime == null && updateTime == null)
            {
                MessageBox.Show(this, "请至少选择创建时间或更新时间", "请选择", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var openFileDialog = new Microsoft.Win32.OpenFileDialog()
            {
                Filter = "All files (*.*)|*.*"
            };
            var result = openFileDialog.ShowDialog();
            if (result != true)
            {
                return;
            }
            var file = openFileDialog.FileName;

            if (updateTime != null)
            {
                File.SetLastWriteTime(file, updateTime.Value);
            }
            if (createTime != null)
            {
                File.SetCreationTime(file, createTime.Value);
            }

            MessageBox.Show(this, "设置完成", "完成", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
