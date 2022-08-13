using Bot_AthenaUnesp;
using Bot_Biblioteca_Selenium.Interfaces;
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
        private readonly IDocWriter _docwriter;

        public Worker(ILogger<Worker> logger, IService service, IDocWriter docwriter)
        {
            _logger = logger;
            _service = service;
            _docwriter = docwriter;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {

                //_logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                _docwriter.CreateData();
                Data data = _docwriter.Read();
                _logger.LogInformation("Iniciando renovação");
                
                var resultService = _service.Execute(data.User, data.Password);
                if (resultService != 0)
                {
                    _logger.LogInformation("Timeout, tentando de novo");
                    await Task.Delay(1000, stoppingToken);
                }
                else
                {
                    _logger.LogInformation("Renovado");
                    await Task.Delay(43200000, stoppingToken);
                }

            }
        }
     
    }
}
