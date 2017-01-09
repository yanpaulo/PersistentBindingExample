using System.ComponentModel;

namespace PersistentBindingExample
{
    //Para enviar notificações de propriedade alterada, uma classe de modelo
    //precisa implementar a interface INotifyPropertyChanged e invocar o manipulador de evento PropertyChanged
    //sempre que uma propriedade for alterada.
    public class MainViewModel : INotifyPropertyChanged
    {
        //Atributos com valores padrão.
        private string _text = "Sem Texto";
        private int _selectedItemIndex = -1;
        private bool _checkBoxChecked = false;
        public string[] ComboBoxItems { get; set; } = new[] { "Item1", "Item2", "Item3", "Item4" };

        //Manipulador de evento
        public event PropertyChangedEventHandler PropertyChanged;
        
        public string Text
        {
            get { return _text; }
            set { _text = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Text")); }
        }

        public int SelectedItemIndex
        {
            get { return _selectedItemIndex; }
            set { _selectedItemIndex = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SelectedItemIndex")); }
        }

        public bool CheckBoxChecked
        {
            get { return _checkBoxChecked; }
            set { _checkBoxChecked = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CheckBoxChecked")); }
        }

    } 
}