using App.Core.Abstracts;
using App.Core.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace App.Core.Services
{
    public class UserService : IUserService
    {
        private readonly ILogger _log;
        public UserService(ILogger<UserService> log)
        {
            _log = log;
        }

        public Task PostUserAsync(User user)
        {
            //вынести в apps
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "queue",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                string jsonData = JsonConvert.SerializeObject(user);
                var body = Encoding.UTF8.GetBytes(jsonData);

                channel.BasicPublish(exchange: "",
                                     routingKey: "queue",
                                     basicProperties: null,
                                     body: body);

                _log.LogInformation("Данные пользователя отправлены.");
            }

            return Task.CompletedTask;
        }
    }
}
