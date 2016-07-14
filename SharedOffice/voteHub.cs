using Microsoft.AspNet.SignalR;
using SharedOffice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace SharedOffice
{
    public class voteHub : Hub
    {
        private static List<Posts> voteItems = new List<Posts>();

        public void VoteUp(int id)
        {
            // AddVote tabulates the vote         
            var post = AddVote(id, "up");
            // Clients.All.updateVoteResults notifies all clients that someone has voted and the page updates itself to relect that 
            Clients.All.updateVoteResults(id, post);         
        }

        public void VoteDown(int id)
        {
            var post = AddVote(id, "down");
            // Clients.All.updateVoteResults notifies all clients that someone has voted and the page updates itself to relect that 
            Clients.All.updateVoteResults(id, post);
        }

        private static Posts AddVote(int id, string type)
        {
            var post = voteItems.Find(x => x.ID == id);

            if (post != null)
            {
                if (type == "up")
                {
                    post.upVotes++;
                }
                else
                {
                    post.downVotes++;
                }
            }
            else
            {
                var newPost = new Posts
                {
                    ID = id,
                    upVotes = 0,
                    downVotes = 0,
                };

                if (type == "up")
                {
                    newPost.upVotes++;
                }
                else
                {
                    newPost.downVotes++;
                }
                voteItems.Add(newPost);
                return newPost;
            }
            return post;
        }

        public override Task OnConnected()
        {
            Clients.Caller.joinVoting(voteItems.ToList());
            return base.OnConnected();
        }

    }
}