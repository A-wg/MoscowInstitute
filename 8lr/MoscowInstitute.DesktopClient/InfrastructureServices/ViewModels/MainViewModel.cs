using MoscowInstitute.ApplicationServices.GetInstituteListUseCase;
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
        private readonly IGetInstituteListUseCase _getInstituteListUseCase;

        public MainViewModel(IGetInstituteListUseCase getInstituteListUseCase)
            => _getInstituteListUseCase = getInstituteListUseCase;

        private Task<bool> _loadingTask;
        private Institute _currentInstitute;
        private ObservableCollection<Institute> _institutes;

        public event PropertyChangedEventHandler PropertyChanged;

        public Institute CurrentInstitute
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
            bool result = await _getInstituteListUseCase.Handle(GetInstituteListUseCaseRequest.CreateAllInstitutesRequest(), outputPort);
            if (result)
            {
                Institutes = new ObservableCollection<Institute>(outputPort.Institutes);
            }
            return result;
        }

        public ObservableCollection<Institute> Institutes
        {
            get
            {
                if (_loadingTask == null)
                {
                    _loadingTask = LoadInstitutes();
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

        private class OutputPort : IOutputPort<GetInstituteListUseCaseResponse>
        {
            public IEnumerable<Institute> Institutes { get; private set; }

            public void Handle(GetInstituteListUseCaseResponse response)
            {
                if (response.Success)
                {
                    Institutes = new ObservableCollection<Institute>(response.Institutes);
                }
            }
        }
    }
}
