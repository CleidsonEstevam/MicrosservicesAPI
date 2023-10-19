using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using ServiceWeb.OrderAPI.Repository;
using System.Text.Json;
using System.Text;
using ServiceWeb.OrderAPI.DTO.Messages;
using ServiceWeb.OrderAPI.Model;

namespace ServiceWeb.OrderAPI.MessageConsumer
{
    public class RabbitMQCheckoutConsumer : BackgroundService
    {
        private readonly OrderRepository _repository;
        private IConnection _connection;
        private IModel _channel;
        //private IRabbitMQMessageSender _rabbitMQMessageSender;

        public RabbitMQCheckoutConsumer(OrderRepository repository)
        {
            _repository = repository;
            var factory = new ConnectionFactory
            {
                HostName = "localhost",
                UserName = "guest",
                Password = "guest"
            };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare(queue: "checkoutqueue", false, false, false, arguments: null);
        }
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();

            var consumer = new EventingBasicConsumer(_channel);
            
            consumer.Received += (chanel, evt) =>
            {
                var content = Encoding.UTF8.GetString(evt.Body.ToArray());
                CheckoutHeaderDTO dto = JsonSerializer.Deserialize<CheckoutHeaderDTO>(content);
                ProcessOrder(dto).GetAwaiter().GetResult();
                _channel.BasicAck(evt.DeliveryTag, false);
            };


            _channel.BasicConsume("checkoutqueue", false, consumer);
            return Task.CompletedTask;

        }
        private async Task ProcessOrder(CheckoutHeaderDTO dto)
        {
            OrderHeader order = new()
            {
                UserId = dto.UserId,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                OrderDetails = new List<OrderDetail>(),
                CardNumber = dto.CardNumber,
                CVV = dto.CVV,
                ExpiryMonthYear = dto.ExpiryMonthYear,
                DateOrder = DateTime.Now,
                PurchaseAmount = dto.PurchaseAmount,
                PaymentStatus = 0
            };

            foreach (var datails in dto.OrderDetails) 
            {
                OrderDetail detail = new()
                {
                    ProductCode = datails.ProductCode,
                    ProductName = datails.ProductName,
                    Price = datails.Price,
                    Count = datails.Count,
                };
                order.CartTotalItens += detail.Count;
                order.OrderDetails.Add(detail);
            }

            await _repository.AddOrder(order);
        }
    }
}
