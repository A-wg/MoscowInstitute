using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using Newtonsoft.Json;
using MoscowInstitute.DomainObjects;
using MoscowInstitute.InfrastructureServices.Gateways.Database;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.DependencyInjection;

namespace MoscowInstitutes.WebService.InfrastructureServices.Gateways
{
    public class GetJsonAndParse
    {
        void ParseAndPush()
        {
            WebClient client = new WebClient();
            client.Encoding = Encoding.UTF8;
            string result = client.DownloadString("https://apidata.mos.ru/v1/datasets/2263/rows?$top=10&api_key=c941a998bbb9e1e374fc2d7a33f61ed0");
            List<ResultFromServer> resultServer = JsonConvert.DeserializeObject<List<ResultFromServer>>(result);
            using (var context = new MInstituteContext())
            {
                foreach (var item in resultServer)
                {
                    MoscowInstitute.DomainObjects.MoscowInstitute moscowinstitute = new MoscowInstitute.DomainObjects.MoscowInstitute();
                    moscowinstitute.ShortName = item.Cells.ShortName;
                    moscowinstitute.WebSite = item.Cells.WebSite;
                    moscowinstitute.ChiefName = item.Cells.ChiefName;
                    moscowinstitute.LegalAddress = item.Cells.LegalAddress;
                    context.MoscowInstitutes.Add(moscowinstitute);
                    context.SaveChanges();
                }
            }
            //Console.WriteLine(resultServer.Cells.AdmArea);
        }
    }
}
