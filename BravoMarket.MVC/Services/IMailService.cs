
using BravoMarket.DAL.Data;

namespace BravoMarket.MVC.Services
{
    public interface IMailService
    {
        Task SendPasswordResetEmailAsync(RequestEmail requestEmail);
    }
}







