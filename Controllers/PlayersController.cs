
// Get: /players/
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MvcPlayers.Models;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mvcplayers.Controllers
{
    public class PlayersController : Controller
    {
        private static List<Players> Players = new List<Players> {
            new Players() {Nummer= 35, Namn = "Jacob Widell Zetterström", FödelseDatum = new DateTime(2015, 12, 25), Assist = 1, Mål = 0, Skadad = false},
            new Players() {Nummer= 6, Namn = "Edvin", FödelseDatum = new DateTime(2001, 01, 06), Assist = 100, Mål = 1000000, Skadad = true}
        };


        public IActionResult Index()
        {
            
            if (HttpContext.Session.GetString("Username") == null)
            {
                return RedirectToAction("Index", "Login");
            }
         
            return View(Players);
        }

        [HttpGet]
        public IActionResult Create()
        {
            Players player = new Players() {};

            return View();
        }
        [HttpGet]
        public IActionResult IsPlayer()
        {
            foreach (var item in Players)
            {
                if (HttpContext.Session.GetString("Username") == item.Namn)
                {
                    return View(); 
                }
            }
            return RedirectToAction("Index", "Players");
        }

        [HttpPost]
        public IActionResult Create(Players player)
        {
            Players.Add(player);

            return RedirectToAction("Index", "Players");
        }

        [HttpGet]
        public IActionResult Edit(int Nummer)
        {
            var pl = Players.Where(s => s.Nummer == Nummer).FirstOrDefault();

            return View(pl);
        }

        [HttpPost]
        public IActionResult Edit(Players player)
        {
            var updatePlayer = Players.FirstOrDefault(p => p.Nummer == player.Nummer);

            if (updatePlayer != null)
            {
                // Update the properties of the existing player with the new values
                updatePlayer.Namn = player.Namn;
                updatePlayer.FödelseDatum = player.FödelseDatum;
                updatePlayer.Mål = player.Mål;
                updatePlayer.Assist = player.Assist;
            }


            return RedirectToAction("Index", "Players"); // Use a relative path
        }

        [HttpGet]
        public IActionResult Details(int Nummer)
        {
            var player = Players.FirstOrDefault(p => p.Nummer == Nummer);

            if (player != null)
            {
                return View(player);
            }
            else
            {
                return NotFound(); // Return a 404 response if the player is not found
            }
        }


        [HttpGet]
        public IActionResult Delete(int Nummer)
        {
            var playerToDelete = Players.FirstOrDefault(p => p.Nummer == Nummer);

            if (playerToDelete != null)
            {
                return View(playerToDelete);
            }
            else
            {
                return NotFound(); // Player not found, return a 404 response
            }
        }


        [HttpPost]
        public IActionResult DeleteConfirmed(int Nummer)
        {
            var playerToDelete = Players.FirstOrDefault(p => p.Nummer == Nummer);

            if (playerToDelete != null)
            {
                Players.Remove(playerToDelete);
                return RedirectToAction("Index", "Players"); // Redirect to the list view
            }
            else
            {
                return NotFound(); // Player not found, return a 404 response
            }
        }



    }
}