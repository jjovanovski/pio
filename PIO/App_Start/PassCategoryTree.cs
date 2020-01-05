using PIO.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PIO.App_Start
{
    public class PassCategoryTree : ActionFilterAttribute
    {
        private CategoryService _categoryService;

        public PassCategoryTree()
        {
            _categoryService = new CategoryService();
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            var categoryTree = _categoryService.GetCategoryTree();
            filterContext.Controller.ViewBag.CategoryTree = categoryTree;
        }
    }
}