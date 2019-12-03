using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_BU.Models
{
    public class Datos
    {
        //public Pr_vac[] Arr { get; set; }
        private static readonly IList<Pr_vac> _games = new List<Pr_vac>();
         public IEnumerable<Pr_vac> Games => _games;

        //public GameState GetGame(int id) => _games.FirstOrDefault(g => g.Id == id);

        public static Pr_vac CreateNewGame(ICollection<Pr_vac> vac )
        {
            int id = _games.Count + 1;
            var game = new Pr_vac(id);
            _games.Add(game);

            foreach (var item in vac)
            {

                vac.Add(item);

            }
            return game;

        
        }

        //public bool DeleteGame(int id)
        //{
        //    var game = _games.FirstOrDefault(g => g.Id == id);

        //    return game != null && _games.Remove(game);
        //}
    }
}

