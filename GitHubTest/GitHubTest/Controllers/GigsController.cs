﻿using GitHubTest.Models;
using GitHubTest.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Web.Mvc;

namespace GitHubTest.Controllers
{
    public class GigsController : Controller
    {
        private ApplicationDbContext _context;

        public GigsController()
        {
            _context = new ApplicationDbContext();
        }


        // GET: Gigs
        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new GigFormViewModel
            {
                Genres = _context.Genres.ToList()
            };
            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(GigFormViewModel viewModel)
        {
         var gig = new Gig
         {
             ArtistId = User.Identity.GetUserId(),
             Venue = viewModel.Venue,
             GenreId = viewModel.Genre,
             DateTime = viewModel.DateTime 
         };

         _context.Gigs.Add(gig);
         _context.SaveChanges();
         return RedirectToAction("Index", "Home");
        }
    }
}