using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam.ViTube
{
    public class ViTubeRepository : IViTubeRepository
    {
        private Dictionary<string, User> usersById = new Dictionary<string, User>();
        private Dictionary<string, Video> videosById = new Dictionary<string, Video>();

        public bool Contains(User user)
        {
            return this.usersById.ContainsKey(user.Id);
        }

        public bool Contains(Video video)
        {
            return this.videosById.ContainsKey(video.Id);
        }

        public void DislikeVideo(User user, Video video)
        {
            if (!this.usersById.ContainsKey(user.Id) || !this.videosById.ContainsKey(video.Id))
            {
                throw new ArgumentException();
            }

            this.videosById[video.Id].Dislikes++;
            this.usersById[user.Id].Voted++;
        }

        public IEnumerable<User> GetPassiveUsers()
        {
            //return this.usersById.Values.Where(x => x.Voted == 0).Where(x => x.Watched == 0);
            return this.usersById.Values.Where(x => x.Voted == 0 && x.Watched == 0);
        }

        public IEnumerable<User> GetUsersByActivityThenByName()
        {   
            return this.usersById.Values
                .OrderByDescending(x => x.Watched)
                .ThenByDescending(x => x.Voted)
                .ThenBy(x => x.Username);
        }

        public IEnumerable<Video> GetVideos()
        {
            return this.videosById.Values;
        }

        public IEnumerable<Video> GetVideosOrderedByViewsThenByLikesThenByDislikes()
        {
            return videosById.Values
                .OrderByDescending(x => x.Views)
                .ThenByDescending(x => x.Likes)
                .ThenBy(x => x.Dislikes);
        }

        public void LikeVideo(User user, Video video)
        {
            if (!this.usersById.ContainsKey(user.Id) || !this.videosById.ContainsKey(video.Id))
            {
                throw new ArgumentException();
            }

            this.videosById[video.Id].Likes++;
            this.usersById[user.Id].Voted++;
        }

        public void PostVideo(Video video)
        {
            if (!this.videosById.ContainsKey(video.Id))
            {
                this.videosById.Add(video.Id, video);
            }
        }

        public void RegisterUser(User user)
        {
            if (!this.usersById.ContainsKey(user.Id))
            {
                this.usersById.Add(user.Id, user);
            }
        }

        public void WatchVideo(User user, Video video)
        {
            if (!this.usersById.ContainsKey(user.Id) || !this.videosById.ContainsKey(video.Id))
            {
                throw new ArgumentException();
            }

            this.videosById[video.Id].Views++;
            this.usersById[user.Id].Watched++;
        }
    }
}
