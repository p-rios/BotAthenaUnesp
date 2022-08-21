using Bot_Biblioteca_Selenium.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Xml;

namespace Bot_Biblioteca_Selenium
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
            var dedocedPassword = _encoder.Decrypt(data.Password);
            Data decodedData = new Data() { User = data.User, Password = dedocedPassword };
            return decodedData;
        }
        
    }
}
