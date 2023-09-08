using BravoMarket.DAL.Entities;

namespace BravoMarket.MVC.ViewModels
{
    public class ContactViewModel
    {
        public Contact Contact { get; set; }
        public Comment Comment { get; set; }

        public List<CommentType> CommentTypes { get; set; }
        public List<ClientFAQ> ClientFAQs { get; set; }
        public List<ClientFAQTitle> ClientFAQTitles { get; set; }
        public List<ClientFAQAnswer> ClientFAQAnswers{ get; set; }
        public List<ConsumerProtection> ConsumerProtections { get; set; }
        public List<ConsumerProtectionInfo> ConsumerProtectionInfos { get; set; }
    }
}
