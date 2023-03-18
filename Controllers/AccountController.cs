using Microsoft.AspNetCore.Mvc;

namespace ShopGrids.Controllers
{
    public class AccountController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(DataContext dataContext, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _dataContext = dataContext;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(MemberRegisterViewModel memberRegisterViewModel)
        {
            if (!ModelState.IsValid) return View();
            AppUser member = await _userManager.FindByNameAsync(memberRegisterViewModel.UserName);

            if(member != null)
            {
                ModelState.AddModelError("Username", "Username has taken!");
                return View();
            }
            //member = await _userManager.FindByEmailAsync(member.Email);
            ////member = await _dataContext.Users.FirstOrDefaultAsync(x => x.NormalizedEmail == memberRegisterViewModel.Email.ToUpper());

            //if (member != null)
            //{
            //    ModelState.AddModelError("Email", "Email has taken");
            //}

            member = new AppUser
            { 
                FullName = memberRegisterViewModel.FullName,
                //Email = memberRegisterViewModel.Email,
                UserName = memberRegisterViewModel.UserName,
            
            };

            var result = await _userManager.CreateAsync(member, memberRegisterViewModel.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                    return View();
                }

            }

            var roleresult = await _userManager.AddToRoleAsync(member, "Member");
            if (!roleresult.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                    return View();
                }
            }
            await _signInManager.SignInAsync(member, isPersistent: false);
            return RedirectToAction("Index", "Home");

        }

        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View();  
        }
        //[HttpPost]
        //public async Task<IActionResult> Login()
        //{
        //    return View();

        //}

    }
}
