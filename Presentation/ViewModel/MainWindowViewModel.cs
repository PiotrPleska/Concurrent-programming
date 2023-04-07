using System;
using System.Collections.ObjectModel;
using Data;
using Model;

namespace ViewModel
{
    public class MainWindowViewModel : ViewModelBase, IDisposable
    {

        public MainWindowViewModel()
        {
            ModelLayer = ModelAbstractAPI.CreateApi();
            ModelLayer.Start();
        }

        public ObservableCollection<IBall> Balls { get; } = new ObservableCollection<IBall>();


        public void Dispose()
        {
            ModelLayer.Dispose();
        }


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

    }
}