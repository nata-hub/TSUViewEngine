﻿using System;

using System.Collections.Generic;

using System.Linq;

using System.Security.Cryptography;

using System.Threading.Tasks;

using Microsoft.AspNetCore.Identity;

using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Mvc.ModelBinding;

using TSUViewEngine.Models;



namespace TSUViewEngine.Controllers

{

    public class AuthController : Controller

    {



        private readonly IUserRepository userRepository;

        public AuthController(IUserRepository userRepository)

        {

            this.userRepository = userRepository;

        }

        public IActionResult Registration()

        {

            return View();

        }



        [HttpPost]

        public IActionResult Registration(User model)

        {

            if (!ModelState.IsValid)

            {

                return View(model);



            }

            if (userRepository.ExistsEmail(model.Email))

            {



                ModelState.AddModelError("", "ელ.ფოსტა უკვე რეგისტრირებულია");



                ModelState.AddModelError(nameof(model.PasswordConfirmation), "პაროლები არ ემთხვევა ერთმანეთს");

                return View(model);

            }//



            userRepository.Create(model);



            return RedirectToAction("Index", "Home");



        }

    }

}