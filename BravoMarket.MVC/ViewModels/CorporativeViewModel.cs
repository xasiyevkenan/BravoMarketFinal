using BravoMarket.DAL.Entities;

namespace BravoMarket.MVC.ViewModels
{
    public class CorporativeViewModel
    {
        public Corporative Corporative { get; set; }
        public CorporativeBanner CorporativeBanner { get; set; }
        public CorporativeClientService CorporativeClientService { get; set; }


        public List<CorporativeClientService> CorporativeClientServices { get; set; }
        public List<CommentType> CommentTypes{ get; set;}
    }
}
