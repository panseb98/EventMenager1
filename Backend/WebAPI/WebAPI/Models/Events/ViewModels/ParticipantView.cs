using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models.Authorization.Dto;

namespace WebAPI.Models.Events.ViewModels
{
    public class ParticipantView
    {
        public int Id { get; set; }
        public UserToList User { get; set; }
        public List<ReceiptItemVM> ReceiptItems { get; set; }
        public ParticipantView(Participant participants)
        {
            User = new UserToList();
            /*var s = participants.Select(x => new ParticipantView() 
                { UserName = x.User.Name, 
                  UserSurname = x.User.Surname, 
                  ReceiptItems = x.Items
                    .Select(x => new ReceiptItemVM() { 
                        Amount = x.Amount, 
                        Price = x.Price, 
                        ProdName = x.ProductName })
                    .ToList() }).First();
             */
            User.Name = participants.User.Name;
            User.Surname = participants.User.Surname;
            User.City = participants.User.City;
            Id = participants.Id;
            User.UserId = participants.User.Id;
            ReceiptItems = participants.Items.Select(x => new ReceiptItemVM() { Amount = x.Amount, Price = x.Price, ProdName = x.ProductName, Id = x.Id, ParticipantId = x.ParticipantId }).ToList();
        }
        public ParticipantView()
        {

        }
    }
}
