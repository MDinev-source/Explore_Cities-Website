namespace ExploreCities.Data.Models
{
    using ExploreCities.Data.Models.Discussions;

    public class UserDiscussion
    {
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public string DiscussionId { get; set; }

        public Discussion Discussion { get; set; }
    }
}
