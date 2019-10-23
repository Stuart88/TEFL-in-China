using System;
using System.Windows;
using System.Windows.Controls;
using static TEFL_App.Views.General.SettingsPageTextClass;

namespace TEFL_App.Views.General
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Page
    {
        #region Private Fields

        private Action AfterSaveComplete;
        private DataLayer.DbAppSettings AppSettingsToSave = App.Settings;

        #endregion Private Fields

        #region Public Constructors

        public Settings(Action afterSaveComplete)
        {
            InitializeComponent();
            SetLanguage();

            AfterSaveComplete = afterSaveComplete;

            languageComboBox.SelectedItem = App.Settings.CultureInfo switch
            {
                Helpers.Enums.Language.English => langItemEn,
                Helpers.Enums.Language.Chinese => langItemZh,
                _ => langItemZh,
            };
        }

        #endregion Public Constructors

        #region Public Properties

        public SettingsPageText PageText { get; set; }

        #endregion Public Properties

        #region Private Methods

        private void ComboBox_Selected(object sender, RoutedEventArgs e)
        {
            AppSettingsToSave.CultureInfo = (((ComboBox)sender).SelectedItem as ComboBoxItem).Tag switch
            {
                "English" => Helpers.Enums.Language.English,
                "Chinese" => Helpers.Enums.Language.Chinese,
                _ => Helpers.Enums.Language.Chinese
            };
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            DataLayer.DbContext.UpdateAppSettings(AppSettingsToSave);

            SetLanguage();

            AfterSaveComplete();

            Helpers.Functions.ShowMessageDialog("", PageText.SavedSuccess);
        }

        private void SetComponentsText()
        {
            saveBtn.Content = PageText.Save;
            languageLabel.Content = PageText.Language;
        }

        private void SetLanguage()
        {
            PageText = App.Settings.CultureInfo == Helpers.Enums.Language.English
                ? SettingsPageTextEn
            : SettingsPageTextZH;

            SetComponentsText();
        }

        #endregion Private Methods
    }

    public sealed class SettingsPageTextClass
    {
        #region Internal Fields

        internal static SettingsPageText SettingsPageTextEn = new SettingsPageText
        {
            Save = "Save",
            SavedSuccess = "Settings saved!",
            Language = "Language"
        };

        internal static SettingsPageText SettingsPageTextZH = new SettingsPageText
        {
            Save = "保存",
            SavedSuccess = "成功！",
            Language = "语言"
        };

        #endregion Internal Fields

        #region Public Classes

        public class SettingsPageText
        {
            #region Public Properties

            public string Language { get; set; }
            public string Save { get; set; }
            public string SavedSuccess { get; set; }

            #endregion Public Properties
        }

        #endregion Public Classes
    }
}