using BangGiaChungKhoan.Repositories;
using Microsoft.AspNetCore.SignalR;

namespace BangGiaChungKhoan.Hubs
{
    public class BangGiaHub : Hub
    {
        BangGiaRepository bangGiaRepository;

        public BangGiaHub(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("BangGiaConnection");
            bangGiaRepository = new BangGiaRepository(connectionString);
        }

        public async Task SendPrices()
        {
            var prices = bangGiaRepository.GetPrices();
            await Clients.All.SendAsync("ReceivedPrices", prices);
        }
    }
}
