using System.Windows.Forms;

namespace WinForms.Utils
{
    public static class UI
    {
        #region infromation message 
        private const string InformationMessage = "Загальне :\n" +
                "\tДля того щоб намалювати коло, напишіть\n" +
                "\tрадіус у віконці і клацніть лівою кнопкою\n" +
                "\tпо полотні. Виберіть її колір у спливаючому \n" +
                                                   "\tвікні.\n" +
                "\tВибравши фігуру з списку Shapes, \n" +
                "\tклацнувши на будь-яку точку на полотні ви\n" +
                "\tзможете його пересунути. \n" +
                "File :\n" +
                "\tЩоб зберегти малюнок нажміть кнопку 'Save'.\n" +
                "\tЩоб створити новий малюнок нажміть кнопку 'New'.\n" +
                "\tЩоб відкрити якусь зі своїх робіт, нажміть кнопку 'Open'\n" +
                "\tі виберіть відповідний файл.\n" +
                 "Shapes :\n" +
                "\tУ вас буде список вами намальованих фігур.\n";

        #endregion

        public static DialogResult CreateInformationWindow()
        {
            const string caption = "Information box";
            const MessageBoxButtons buttons = MessageBoxButtons.OK;

            return MessageBox.Show(InformationMessage, caption, buttons);
        }

        public static SaveFileDialog CreateSaveFile()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                RestoreDirectory = true,
                DefaultExt = "xml",
                CheckPathExists = true,
                Title = @"Save",
                ValidateNames = true
            };

            return saveFileDialog;
        }

        public static OpenFileDialog CreateOpenFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = @"(*.xml)|*.xml",
                RestoreDirectory = true,
                CheckFileExists = true,
                CheckPathExists = true,
                Title = @"Choose file"
            };

            return openFileDialog;
        }


    }
}
