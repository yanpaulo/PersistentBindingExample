using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PersistentBindingExample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string STATE_FILE_NAME  = "state.txt";
        private MainViewModel _viewModel;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MainViewModel model;
            //Se o arquivo já existir, carrega o arquivo e desserializa.
            if (File.Exists(STATE_FILE_NAME))
            {
                var fileText = File.ReadAllText(STATE_FILE_NAME);
                model = JsonConvert.DeserializeObject<MainViewModel>(fileText);
            }
            //Se não, apenas instancia o modelo, que virá com valores padrão.
            else
            {
                model = new MainViewModel();
            }

            //Se inscreve no evento PropertyChanged do modelo.
            //Métodos inscritos neste evento são notificados sempre que um valor qualquer é alterado.
            model.PropertyChanged += Model_PropertyChanged;

            //Atribui este modelo ao DataContext e ao local _viewModel.
            this.DataContext = this._viewModel = model;
        }

        //Método inscrito em PropertyChanged
        private void Model_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            //Converte _viewModel para json e salva no arquivo pré-configurado//Se o arquivo já existir, este será sobrescrito.
            File.WriteAllText(STATE_FILE_NAME, JsonConvert.SerializeObject(this._viewModel));
        }
    }

    
}
