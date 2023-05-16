using Model;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ViewModel
{
    public class MainWindowViewModel : ViewModelBase, IDisposable
    {
        private ModelAbstractApi ModelLayer;
        private ObservableCollection<IModelBall> ModelBallsList;
        private int ballCount;

        public string BallCount
        {
            get { return Convert.ToString(this.ballCount); }
            set
            {
                this.ballCount = Convert.ToInt32(value);
                RaisePropertyChanged("BallCount");
            }
        }

        public ObservableCollection<IModelBall> SGModelBallsList
        {
            get { return ModelBallsList; }
            set
            {
                if (value.Equals(this.ModelBallsList)) return;
                ModelBallsList = value;
            }
        }


        public ICommand Sig { get; set; }


        public MainWindowViewModel(ModelAbstractApi ModelApi = null)
        {
            Sig = new RelayCommand(start);
            this.ModelLayer = ModelAbstractApi.CreateApi();
        }

        public MainWindowViewModel() : this(null)
        {
        }


        private void start()
        {
            if (SGModelBallsList != null)
            {
                Dispose();
                SGModelBallsList.Clear();
            }

            ModelLayer.Start(ballCount);
            SGModelBallsList = ModelLayer.GetModelBalls();
            RaisePropertyChanged("SGModelBallsList");
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ModelLayer.Dispose();
        }

        public void Dispose()
        {
            ModelLayer.Dispose();
        }
    }
}