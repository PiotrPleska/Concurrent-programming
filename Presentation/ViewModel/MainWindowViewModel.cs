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
        public ObservableCollection<ModelBall> ModelBallsList;
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
            if (ModelApi == null)
            {
                this.ModelLayer = ModelAbstractAPI.CreateApi();
            }
            else
            {
                this.ModelLayer = ModelApi;
            }
        }

        public MainWindowViewModel() : this(null) { }

        private void start()
        {
            ModelLayer.Start();
            SGModelBallsList = ModelLayer.GetModelBalls();
        }


        public void Dispose()
        {
            ModelLayer.Dispose();
        }



       

    }
}