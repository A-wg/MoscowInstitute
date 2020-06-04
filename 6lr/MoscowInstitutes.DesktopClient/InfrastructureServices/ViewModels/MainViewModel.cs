using MoscowInstitute.ApplicationServices.GetMInstituteListUseCase;
using MoscowInstitute.ApplicationServices.Ports;
using MoscowInstitute.DomainObjects;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;

namespace MoscowInstitute.DesktopClient.InfrastructureServices.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly IGetMInstituteListUseCase _getInstituteListUseCase;

        public MainViewModel(IGetMInstituteListUseCase getInstituteListUseCase)
            => _getInstituteListUseCase = getInstituteListUseCase;

        private bool _loadingTask;
        private DomainObjects.MoscowInstitute _currentInstitute;
        private ObservableCollection<DomainObjects.MoscowInstitute> _institutes;

        public event PropertyChangedEventHandler PropertyChanged;

        public DomainObjects.MoscowInstitute CurrentInstitute
        {
            get => _currentInstitute; 
            set
            {
                if (_currentInstitute != value)
                {
                    _currentInstitute = value;
                    OnPropertyChanged(nameof(CurrentInstitute));
                }
            }
        }

        private async Task<bool> LoadInstitutes()
        {
            var outputPort = new OutputPort();
            bool result = await _getInstituteListUseCase.Handle(GetMInstituteListUseCaseRequest.CreateAllMInstitutesRequest(), outputPort);
            if (result)
            {
                _loadingTask = true;
                Institutes = new ObservableCollection<DomainObjects.MoscowInstitute>(outputPort.Institutes);
                return result;
            }
            return result;
        }

        public ObservableCollection<DomainObjects.MoscowInstitute> Institutes
        {
            get 
            {
                if (_loadingTask == false)
                {
                    _ = LoadInstitutes();
                }
                
                return _institutes; 
            }
            set
            {
                if (_institutes != value)
                {
                    _institutes = value;
                    OnPropertyChanged(nameof(Institutes));
                }
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
           PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private class OutputPort : IOutputPort<GetMInstituteListUseCaseResponse>
        {
            public IEnumerable<DomainObjects.MoscowInstitute> Institutes { get; private set; }

            public void Handle(GetMInstituteListUseCaseResponse response)
            {
                if (response.Success)
                {
                    Institutes = new ObservableCollection<DomainObjects.MoscowInstitute>(response.MoscowInstitute);
                }
            }
        }
    }
}
