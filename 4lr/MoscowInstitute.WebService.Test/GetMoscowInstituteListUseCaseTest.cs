using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using MoscowInstitute.ApplicationServices.Repositories;
using MoscowInstitute.ApplicationServices.Ports;
using MoscowInstitute.ApplicationServices.GetInstituteListUseCase;
using Xunit;
using MoscowInstitute.DomainObjects;

namespace MoscowInstitute.WebService.Tests
{
    public class GetMoscowInstituteListUseCaseTest
    {
        private InMemoryInstituteRepository CreateRoteRepository()
        {
            var repo = new InMemoryInstituteRepository(new List<Institute> {
                new Institute { Id = 1, NameInstitute = "ГБОУ ДО ДТДМ «Хорошево»", Site = "dtim.mskobr.ru", 
                    Address = "123154, ГОРОД МОСКВА, УЛИЦА МАРШАЛА ТУХАЧЕВСКОГО, 20, 1", Director = "Ледовская Татьяна Леонидовна"},
                new Institute { Id = 2, NameInstitute = "ГБУ «Лаборатория путешествий»", Site = "lab-putesh.mskobr.ru  ",
                    Address = "109147, г. Москва, ул. Нижегородская, д. 3  ", Director ="Шпаро Матвей Дмитриевич"},
                new Institute { Id = 3, NameInstitute = "ГБПОУ колледж «Царицыно»", Site = "collegetsaritsyno.mskobr.ru",
                    Address = "115569, г. Москва, Шипиловский проезд, дом 37, корпус 1", Director ="Седова Наталья Николаевна"},
                new Institute { Id = 4, NameInstitute = "ГБОУДО «ДТДиМ «Преображенский»", Site = "dtdimvouo.mskobr.ru",
                    Address = "107553, Москва, ул. Большая Черкизовская, д. 15 ", Director ="Коминова Елена Борисовна"},
            });
            return repo;
        }

        [Fact]
        public void TestGetAllInstitutes()
        {
            var useCase = new GetInstituteListUseCase(CreateRoteRepository());
            var outputPort = new OutputPort();

            Assert.True(useCase.Handle(GetInstituteListUseCaseRequest.CreateAllInstitutesRequest(), outputPort).Result);
            Assert.Equal<int>(4, outputPort.Institute.Count());
            Assert.Equal(new long[] { 1, 2, 3, 4 }, outputPort.Institute.Select(o => o.Id));
        }

        [Fact]
        public void TestGetAllInstituteFromEmptyRepository()
        {
            var useCase = new GetInstituteListUseCase(new InMemoryInstituteRepository());
            var outputPort = new OutputPort();

            Assert.True(useCase.Handle(GetInstituteListUseCaseRequest.CreateAllInstitutesRequest(), outputPort).Result);
            Assert.Empty(outputPort.Institute);
        }

        [Fact]
        public void TestGetInstitute()
        {
            var useCase = new GetInstituteListUseCase(CreateRoteRepository());
            var outputPort = new OutputPort();

            Assert.True(useCase.Handle(GetInstituteListUseCaseRequest.CreateInstituteRequest(2), outputPort).Result);
            Assert.Single(outputPort.Institute, r => 2 == r.Id);
        }

        [Fact]
        public void TestTryGetNotExistingInstitute()
        {
            var useCase = new GetInstituteListUseCase(CreateRoteRepository());
            var outputPort = new OutputPort();

            Assert.True(useCase.Handle(GetInstituteListUseCaseRequest.CreateInstituteRequest(999), outputPort).Result);
            Assert.Empty(outputPort.Institute);
        }

    }

    class OutputPort : IOutputPort<GetInstituteListUseCaseResponse>
    {
        public IEnumerable<Institute> Institute { get; private set; }

        public void Handle(GetInstituteListUseCaseResponse response)
        {
            Institute = response.Institutes;
        }
    }

}
