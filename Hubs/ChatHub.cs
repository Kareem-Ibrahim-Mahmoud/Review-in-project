using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace Financial_Stock.Hubs
{
    public class ChatHub : Hub
    {

        public void NewMassage(string name, string massage)
        {
            //دي لو عاوز تبعت للكل 
            Clients.All.SendAsync("NewMassageNotfiay",name, massage);

        }

        public void NewMassage2(string name ,string massage, List<string>cid)
        {

            //هنا مش هيبعت لكل الناس
            Clients.Clients(cid).SendAsync("NewMassageNotfiay", name, massage);
        }

        [Authorize]
        public override Task OnConnectedAsync()
        {
            //my own logicلو حد كونيكتيد هعوز ابعت لكل الناس انه هو كونيكتيد 
            string name = Context.User.Identity.Name;

            Clients.All.SendAsync("NewUser",name,Context.ConnectionId);



            return base.OnConnectedAsync();
        }



    }
}
