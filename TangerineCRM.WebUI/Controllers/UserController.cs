using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TangerineCRM.Business.Managers;
using TangerineCRM.Core.Helpers;
using TangerineCRM.Core.Helpers.Enums;
using TangerineCRM.DataAccess.Core;
using TangerineCRM.DataAccess.Core.Contexts;
using TangerineCRM.Entities.Base;
using TangerineCRM.WebUI.Models;

namespace TangerineCRM.WebUI.Controllers
{
    public class UserController : Controller
    {
        DatabaseContext context;
        UserManager userManager;

        public UserController()
        {
            context = new DatabaseContext();
            userManager = new UserManager(new UserDal(context));
        }

        public ActionResult Index()
        {
            var model = new UserViewModel()
            {
                UserList = userManager.GetAll()
            };

            return View(model);
        }

        public ActionResult Create()
        {
            var model = new UserViewModel()
            {
                UserTypeList = GetTypeDropDown()
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Add(UserViewModel model)
        {
            var user = ParseValuesFromModel(model);
            userManager.Add(user);

            return RedirectToAction("Index", "User");
        }

        public ActionResult Delete(int id)
        {
            var user = userManager.GetBy(x => x.UserId == id);
            userManager.Delete(user);

            return RedirectToAction("Index", "User");
        }

        public ActionResult Update(int id)
        {
            var user = userManager.GetBy(x => x.UserId == id);

            var model = ParseValuesToModel(user);

            return View(model);
        }

        [HttpPost]
        public ActionResult Update(UserViewModel model)
        {
            var user = ParseValuesFromModel(model);
            userManager.Update(user);


            return RedirectToAction("Index", "User");
        }

        private UserViewModel ParseValuesToModel(User user)
        {
            var model = new UserViewModel()
            {
                SingleUser = user,
                UserTypeList = GetTypeDropDown(),
                SelectedUserType = user.UserType.ToString()
            };

            return model;
        }

        private User ParseValuesFromModel(UserViewModel model)
        {
            var user = model.SingleUser;
            user.UserType = GetUserType(model.SelectedUserType);

            return user;
        }

        private List<SelectListItem> GetTypeDropDown()
        {
            var list = new List<SelectListItem>();

            Enum.GetValues(typeof(UserType)).Cast<UserType>()
                .ToList()
                .ForEach(x => list.Add(new SelectListItem()
                {
                    Text = x.GetStringValue(),
                    Value = x.ToString()
                }));

            return list;
        }

        private UserType GetUserType(string userType)
        {
            return (UserType)Enum.Parse(typeof(UserType), userType);
        }
    }
}