using MahApps.Metro.Controls;

namespace FileTimeEditor
{
    public class CustomDateTimePicker : DateTimePicker
    {
        protected override string GetValueForTextBox()
        {
            return SelectedDateTime?.ToString("yyyy-MM-dd HH:mm:ss");
        }
    }
}
