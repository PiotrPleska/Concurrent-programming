using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Data;
using Logic;
using Model;

namespace ViewModel
{
    public class MainWindowViewModel : ViewModelBase, IDisposable
    {

        private ModelAbstractAPI ModelLayer;
        private ObservableCollection<ModelBall> ModelBallsList;
        public ObservableCollection<ModelBall> SGModelBallsList
        {
            get { return ModelBallsList; }
            set
            {
                if (value.Equals(this.ModelBallsList)) return;
                ModelBallsList = value;
                RaisePropertyChanged("SGModelBallList");
            }
        }


        public ICommand Sig
        {
            get;
            set;
        }


        public MainWindowViewModel(ModelAbstractAPI ModelApi = null)
        {
            Sig = new RelayCommand(start);
            this.ModelLayer = ModelAbstractAPI.CreateApi();

        }

        public MainWindowViewModel() : this(null) { }


        private void start()
        {
            if(SGModelBallsList != null) 
            {
                SGModelBallsList.Clear();
            }
            ModelLayer.Start();
            SGModelBallsList = ModelLayer.GetModelBalls();
            RaisePropertyChanged("SGModelBallsList");
        }

        public void Dispose()
        {
            ModelLayer.Dispose();
        }





    }
}