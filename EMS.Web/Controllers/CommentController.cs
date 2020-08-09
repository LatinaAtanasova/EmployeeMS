using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMS.Data.Entities;
using EMS.Services.Interfaces;
using EMS.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace EMS.Web.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpPost]
        public IActionResult Add(CommentViewModel model)
        {
            Comment comment = new Comment
            {
                Author = model.Author,
                Description = model.Description,
                EmployeeId = model.EmployeeId
            };

            int id = _commentService.Add(comment);
            return RedirectToAction("GetEmployee", "Employee", new { id = model.EmployeeId });
        }


        [HttpPost]
        public IActionResult Edit(CommentViewModel model)
        {
            Comment comment = _commentService.GetCommentById(model.Id);

            if (model.Btn == "Delete")
            {
                comment.isDeleted = true;

            }
            else
            {
                comment.Description = model.Description;
            }

            _commentService.Update(comment);
            return RedirectToAction("GetEmployee", "Employee", new { id = comment.EmployeeId });
        }

    }
}