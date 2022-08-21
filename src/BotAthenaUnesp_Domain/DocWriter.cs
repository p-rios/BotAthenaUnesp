using BotAthenaUnesp_Domain.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#pragma warning disable CS8604 // Possible null reference argument.
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8601 // Possible null reference assignment.
namespace BotAthenaUnesp_Domain
{

    public class DocWriter : IDocWriter
    {
        private readonly IEncoder _encoder;

        public DocWriter(IEncoder encoder)
        {
            _encoder = encoder;
        }

        public void CreateData()
        {

            var fileExists = File.Exists(@".\data.json");
            if (fileExists == false)
            {
                Console.WriteLine("Usuário(sem @unesp.br): ");              
                string user = Console.ReadLine();
                Console.WriteLine("Senha: ");          
                string password = Console.ReadLine();

                var encodedPassword = _encoder.Encrypt(password);

                Data data = new Data() { User = user, Password = encodedPassword };
                File.WriteAllText(@".\data.json", JsonConvert.SerializeObject(data));
            }
        }
        public Data Read()
        {

            Data data = JsonConvert.DeserializeObject<Data>(File.ReadAllText(@".\data.json"));

            var decodedPassword = _encoder.Decrypt(data.Password);
            Data decodedData = new Data() { User = data.User, Password = decodedPassword };
            return decodedData;
        }

    }
}