using System;

namespace Exam.ViTube
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var video = new Video("1", "asd", 1.34, 0, 0, 0);
            var user = new User("1", "slav");
            var user1 = new User("2", "pipi");

            ViTubeRepository viTube = new ViTubeRepository();

            viTube.PostVideo(video);
            viTube.RegisterUser(user);
            viTube.RegisterUser(user1);

            viTube.WatchVideo(user, video);
            viTube.LikeVideo(user, video);

            viTube.GetPassiveUsers();
           
        }
    }
}
