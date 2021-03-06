﻿using AutoMapper;
using BookReader.Models;
using BookReaderManager.Business.Interfaces;
using BookReaderManager.Business.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace BookReader.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorService _authorService;
        private readonly IMapper _mapper;

        public AuthorController(IAuthorService authorService, IMapper mapper)
        {
            _authorService = authorService;
            _mapper = mapper;
        }

        // GET: Author
        [Authorize(Roles = "Admin")]
        public ActionResult Authors()
        {
            var authors = _authorService.GetAllAuthors();
            var authorsViewModel = _mapper.Map<IList<AuthorViewModel>>(authors);

            var model = new GetAuthorsViewModel();
            model.Authors = authorsViewModel;

            return View(model);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            _authorService.DeleteAuthor(id);

            return RedirectToAction("Authors");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            var authorModel = _authorService.GetAuthorById(id);
            var model = _mapper.Map<EditAuthorPostModel>(authorModel);

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(EditAuthorPostModel authorEdit)
        {
            if(ModelState.IsValid)
            {
                var author = _mapper.Map<AuthorModel>(authorEdit);

                _authorService.UpdateAuthor(author);

                return RedirectToAction("Authors");
            }

            var authorModel = _authorService.GetAuthorById(authorEdit.Id);
            var model = _mapper.Map<EditAuthorPostModel>(authorModel);

            return View("Edit", model);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            var model = new CreateAuthorPostModel();

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Create(CreateAuthorPostModel author)
        {
            if(ModelState.IsValid)
            {
                var authorModel = _mapper.Map<AuthorModel>(author);
                _authorService.AddAuthor(authorModel);
                
                return RedirectToAction("Authors");
            }

            var model = new CreateAuthorPostModel();

            return View("Create", model);
        }

        public ActionResult Details(int id)
        {
            var author = _authorService.GetAuthorById(id);
            var authorViewModel = _mapper.Map<AuthorViewModel>(author);

            return View(authorViewModel);
        }
    }
}