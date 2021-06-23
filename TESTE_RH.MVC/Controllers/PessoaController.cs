using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TESTE_RH.MVC.Models;

namespace TESTE_RH.MVC.Controllers
{
    public class PessoaController : BaseController
    {
        public ActionResult Index(string PessoaID)
        {
            PessoaViewModel model = new PessoaViewModel();

            if (PessoaID != null)
            {
                PessoaViewModel pessoa = RequestItem(model, "v1/pessoas/" + Convert.ToInt32(PessoaID));

                if (pessoa != null)
                {
                    model.ListaPessoas = new List<PessoaViewModel>();
                    model.ListaPessoas.Add(pessoa);
                }
            }
            else
            {
                List<PessoaViewModel> listaObj = RequestList(model, "v1/pessoas/ObterTodos");
                model.ListaPessoas = listaObj;
            }

            if ((model.ListaPessoas != null) && (model.ListaPessoas.Count > 0))
            {
                foreach (var item in model.ListaPessoas)
                {
                    item.CPF_MASK = Convert.ToInt64(item.CPF).ToString(@"000\.000\.000\-00");
                    item.CEP_MASK = Convert.ToInt64(item.CEP).ToString(@"00000-000");
                }
            }

            return View(model.ListaPessoas);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PessoaViewModel model)
        {
            try
            {
                PessoaViewModel modelAux = RequestItem(model, "v1/pessoas/" + Convert.ToInt32(model.PessoaID));

                if (modelAux == null)
                    modelAux = RequestItem(model, "v1/pessoas/GetByCpf/" + model.CPF + "/");

                if (modelAux == null)
                    RequestAction(model, "v1/pessoas", "POST");

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            PessoaViewModel model = new PessoaViewModel();
            model = RequestItem(model, "v1/pessoas/" + id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PessoaViewModel model)
        {
            try
            {
                RequestAction(model, "v1/pessoas", "PUT");
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            PessoaViewModel model = new PessoaViewModel();
            model = RequestItem(model, "v1/pessoas/" + id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(PessoaViewModel model)
        {
            try
            {
                RequestAction(model, "v1/pessoas/" + model.PessoaID, "DELETE");
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
