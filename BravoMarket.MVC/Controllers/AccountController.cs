using BravoMarket.DAL.Data;
using BravoMarket.DAL.Entities;
using BravoMarket.MVC.Services;
using BravoMarket.MVC.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BravoMarket.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMailService _mailService;

        public AccountController(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            RoleManager<IdentityRole> roleManager,
            IMailService mailService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _mailService = mailService;
        }

        public IActionResult Register()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("index", "OnlineMarket");
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var user = new AppUser
                {
                    FirstName = viewModel.FirstName,
                    LastName = viewModel.LastName,
                    UserName = viewModel.UserName,
                    Email = viewModel.Email,
                    LastSignInDate = DateTime.Now,
                };

                var existUsername = await _userManager.FindByNameAsync(viewModel.UserName);

                if (existUsername != null)
                {
                    ModelState.AddModelError("UserName", "Bu istifadəçi adı artıq istifadə olunur.");
                    return View(viewModel);
                }

                var result = await _userManager.CreateAsync(user, viewModel.Password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "Member");

                    var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);

                    var confirmationLink = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = token }, Request.Scheme);

                    var mailRequest = new RequestEmail
                    {
                        ToEmail = viewModel.Email,
                        Body = $"Aşağıdakı linkə klikləyərək Email adresinizi təsdiqləyin! \n {confirmationLink}",
                        Subject = "E-poçt ünvanınızı təsdiqləyin"
                    };

                    await _mailService.SendPasswordResetEmailAsync(mailRequest);

                    return RedirectToAction("Login");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(viewModel);
        }

        public async Task<IActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return View("Error");
            }

            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return View("Error");
            }

            var result = await _userManager.ConfirmEmailAsync(user, code);

            if (result.Succeeded)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                return Forbid();
            }
        }

        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("index", "OnlineMarket");
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel viewModel, bool rememberMe)
        {
            if (ModelState.IsValid)
            {
                var existUser = await _userManager.FindByNameAsync(viewModel.UserName);

                if (existUser == null)
                {
                    ModelState.AddModelError("", "İstifadəçi adı və ya şifrə düzgün deyil.");
                    return View(viewModel);
                }

                var result = await _signInManager.PasswordSignInAsync(existUser, viewModel.Password, rememberMe, true);

                if (!result.Succeeded)
                {
                    if (result.IsLockedOut)
                    {
                        var lockoutEndTime = existUser.LockoutEnd;
                        if (lockoutEndTime.HasValue && lockoutEndTime > DateTimeOffset.UtcNow)
                        {
                            var remainingLockoutTime = lockoutEndTime.Value.Subtract(DateTimeOffset.UtcNow);
                            var formattedRemainingTime = $"{(int)remainingLockoutTime.TotalMinutes} dəqiqə {(int)remainingLockoutTime.Seconds} saniyə";
                            ModelState.AddModelError("", $"Sizin hesabınız bir neçə dəqiqəlik bağlıdır. Xahiş edirik sonra cəhd edin. Qalan vaxt: {formattedRemainingTime}");
                        }
                        else
                        {
                            ModelState.AddModelError("", "Bir neçə uğursuz cəhd sonrası hesabınız müvəqqəti olaraq bağlanıb. Xahiş edirik sonra cəhd edin.");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Düzgün giriş cəhd edilmədi. Xahiş edirik istifadəçi adınızı və şifrənizi yoxlayın.");
                    }
                }
                else
                {
                    existUser.LastSignInDate = DateTime.UtcNow;
                    await _userManager.UpdateAsync(existUser);

                    if (string.IsNullOrEmpty(viewModel.ReturnUrl))
                    {
                        return RedirectToAction("index", "OnlineMarket");
                    }
                    else
                    {
                        return Redirect(viewModel.ReturnUrl);
                    }
                }
            }
            return View(viewModel);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Login", "Account");
        }

        [Authorize]
        public async Task<IActionResult> EditProfile(string profileId)
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return NotFound();
            }

            if (user.Id != profileId)
            {
                return Forbid();
            }

            var viewModel = new ProfileViewModel
            {
                UserId = user.Id,
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                BirthDay = user.BirthDay,
                MiddleName = user.MiddleName,
                LastSignInDate = user.LastSignInDate,
            };

            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProfile(ProfileViewModel viewModel)
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            if (!string.IsNullOrWhiteSpace(viewModel.CurrentPassword) && !string.IsNullOrWhiteSpace(viewModel.NewPassword))
            {
                var isCurrentPasswordCorrect = await _userManager.CheckPasswordAsync(user, viewModel.CurrentPassword);

                if (!isCurrentPasswordCorrect)
                {
                    ModelState.AddModelError("CurrentPassword", "Current password is incorrect.");
                    return View(viewModel);
                }

                var passwordChangeResult = await _userManager.ChangePasswordAsync(user, viewModel.CurrentPassword, viewModel.NewPassword);

                if (!passwordChangeResult.Succeeded)
                {
                    foreach (var error in passwordChangeResult.Errors)
                    {
                        ModelState.AddModelError("NewPassword", error.Description);
                    }

                    return View(viewModel);
                }
            }

            user.UserName = viewModel.UserName;
            user.FirstName = viewModel.FirstName;
            user.LastName = viewModel.LastName;
            user.MiddleName = viewModel.MiddleName;
            user.BirthDay = viewModel.BirthDay;
            user.Email = viewModel.Email;

            var result = await _userManager.UpdateAsync(user);

            var existUsername = await _userManager.FindByNameAsync(viewModel.UserName);

            if (existUsername != null)
            {
                ModelState.AddModelError("UserName", "Bu istifadəçi adı artıq istifadə olunur.");
            }

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "OnlineMarket");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View(viewModel);
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "E-poçt ünvanını daxil edin");

                return View();
            }

            var existUser = await _userManager.FindByEmailAsync(model.ToEmail);

            if (existUser == null)
            {
                ModelState.AddModelError("", "Bu e-poçt ünvanı mövcud deyil");

                return View();
            }

            var token = await _userManager.GeneratePasswordResetTokenAsync(existUser);

            var resetLink = Url.Action(nameof(ResetPassword),
                           "Account", new { email = model.ToEmail, token }, Request.Scheme, Request.Host.ToString());

            var mailRequest = new RequestEmail
            {
                ToEmail = model.ToEmail,
                Body = resetLink,
                Subject = "Şifrəni sıfırlamaq linki"
            };

            await _mailService.SendPasswordResetEmailAsync(mailRequest);

            return RedirectToAction(nameof(Login));
        }

        public IActionResult ResetPassword(string email, string token)
        {
            return View(new ResetPasswordViewModel { Email = email, Token = token });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Daxil etdiyiniz məlumatlar yanlışdır");

                return View();
            }

            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null)
            {
                ModelState.AddModelError("", "İstifadəçi tapılmadı");

                return BadRequest();
            }

            var result = await _userManager.ResetPasswordAsync(user, model.Token, model.Password);

            if (result.Succeeded)
            {
                return RedirectToAction(nameof(Login));
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return View();
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
