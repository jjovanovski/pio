using PIO.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PIO.App_Start
{
    public class PassCategoryTree : ActionFilterAttribute
    {
        private ICategoryRepository _categoryRepository;

        public PassCategoryTree()
        {
            _categoryRepository = new CategoryRepository();
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            var categoryTree = _categoryRepository.GetCategoryTree();
            filterContext.Controller.ViewBag.CategoryTree = categoryTree;
        }
    }
}