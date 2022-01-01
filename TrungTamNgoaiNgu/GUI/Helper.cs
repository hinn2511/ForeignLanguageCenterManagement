using System.Windows;
using System.Windows.Forms;

namespace TrungTamNgoaiNgu.GUI
{
    public static class Helper
    {
        public static void ShowMessage(string message, string type)
        {
            System.Windows.MessageBox.Show(message, type, (MessageBoxButton)MessageBoxButtons.OK);
        }

        public static bool ShowConfirmDialog(string message, string type)
        {
            MessageBoxResult confirmResult = System.Windows.MessageBox.Show(message,type, MessageBoxButton.YesNo);

            if (confirmResult == MessageBoxResult.Yes)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
