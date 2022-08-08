using Bot_AthenaUnesp;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


namespace Bot_Biblioteca_Selenium
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IService _service;
      
        public Worker(ILogger<Worker> logger, IService service)
        {
            _logger = logger;
            _service = service;
       
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                //_logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                Console.WriteLine("Digite o Usuário (sem @unesp):");
                string login = Console.ReadLine();
                Console.WriteLine("Digite a senha:");
                Console.ReadKey(true);
                string senha = Console.ReadLine();
                _service.Execute(login, senha);
                await Task.Delay(86400, stoppingToken);
            }
        }
        public override Task StartAsync(CancellationToken cancellationToken)
        {
            //_logger.LogInformation("Iniciado renovação");
            return base.StartAsync(cancellationToken);
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Renovado");
            return base.StopAsync(cancellationToken);

        }
    }
}
