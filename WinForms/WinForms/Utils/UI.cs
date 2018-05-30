using System.Windows.Forms;

namespace WinForms.Utils
{
    public static class UI
    {
        #region infromation message 
        private const string INFORMATION_MESSAGE = "Загальне :\n" +
                "\t1) Для того щоб намалювати фігуру, виберіть її\n" +
                "\tв меню" +
                "\tта виберіть її колір.\n" +
                "\t2) Клікніть по полотні.\n" +
                "\t3) У вас з'явиться вікно.\n" +
                "\t Введіть туди розміри чотирикутника.\n" +
                "\t4) Після того натисніть кнопку Send і у вас з'явиться\n" +
                "\t ваш чотирикутник.\n" +
                "\t5) Нажавши правою кнопкою миші по чотирекутнику ви\n" +
                "\t зможете його пересунути. Потрібно після цього \n" +
                "\t клікнути по пототні ще один раз правою кнопкою\n" +
                "\t і фігура пересуниться в цю точку\n" +
                "File :\n" +
                "\tЩоб зберегти малюнок нажміть кнопку 'Save'.\n" +
                "\tЩоб зберегти малюнок в форматі \n" +
                "\t картинки нажміть кнопку 'Save as'.\n" +
                "\tЩоб створити новий малюнок нажміть кнопку 'New'.\n" +
                "\tЩоб відкрити якусь зі своїх робіт, нажміть кнопку 'Open'\n" +
                "\tі виберіть відповідний файл.\n" +
                 "Shapes :\n" +
                "\tУ вас буде список вами намальованих фігур.\n" +
                "\tВи можете змінити її колір, посунути, або видалити.'\n";

        #endregion

        public static DialogResult CreateInformationWindow()
        {
            const string caption = "Information box";
            const MessageBoxButtons buttons = MessageBoxButtons.OK;

            return MessageBox.Show(INFORMATION_MESSAGE, caption, buttons);
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
