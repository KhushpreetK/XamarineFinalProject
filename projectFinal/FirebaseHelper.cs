using System;
using Firebase.Database;
using Firebase.Database.Query;
using System.Linq;
using System.Collections.Generic;
using projectFinal.Model;
using System.Threading.Tasks;

namespace projectFinal
{
    public class FirebaseHelper
    {
        FirebaseClient firebase = new FirebaseClient("https://xamarinepfinalquiz2021-default-rtdb.firebaseio.com/");

        public async void AddScore()
        {
          await  firebase.Child("Score").Child(Global.name).PostAsync(new Score { category = Global.type, finalScore = Global.score });
        }

        public async Task<List<Score>> getScore(string username)
        {
            return (await firebase.Child("Score").Child(Global.name).OnceAsync<Score>()).Select(x => new Score {

                category = x.Object.category,
                finalScore = x.Object.finalScore
            }).ToList();
        }

    }

    
}
