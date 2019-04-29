﻿using ControleEstoque.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControleEstoque.Web.Controllers
{
    public class CadastroController : Controller
    {
        private static List<GrupoProdutoModel> _listaGrupoProduto = new List<GrupoProdutoModel>()
        {
            new GrupoProdutoModel(){ Id=1, Nome="Livros", Ativo=true },
            new GrupoProdutoModel(){ Id=2, Nome="Mouses", Ativo=true },
            new GrupoProdutoModel(){ Id=3, Nome="Monitores", Ativo=false }
        };

        [Authorize]
        public ActionResult GrupoProduto()
        {
            return View(_listaGrupoProduto);
        }

        [HttpPost]
        [Authorize]
        public ActionResult RecuperarGrupoProduto(int id)
        {
            return Json(_listaGrupoProduto.Find(x => x.Id == id));
        }

        [HttpPost]
        [Authorize]
        public ActionResult ExcluirGrupoProduto(int id)
        {
            var ret = false;

            var registroBd = _listaGrupoProduto.Find(x => x.Id == id);
            if (registroBd != null)
            {
                _listaGrupoProduto.Remove(registroBd);
                ret = true;
            }

            return Json(ret);
        }

        [HttpPost]
        [Authorize]
        public ActionResult SalvarGrupoProduto(GrupoProdutoModel model)
        {
            var resultado = "OK";
            var mensagens = new List<string>();
            var idSalvo = string.Empty;

            if (!ModelState.IsValid)
            {
                resultado = "AVISO";
                mensagens = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList();
            }
            else
            {
                try
                {
                    var registroBd = _listaGrupoProduto.Find(x => x.Id == model.Id);

                    if (registroBd == null)
                    {
                        registroBd = model;
                        registroBd.Id = _listaGrupoProduto.Max(x => x.Id) + 1;
                        _listaGrupoProduto.Add(registroBd);
                    }
                    else
                    {
                        registroBd.Nome = model.Nome;
                        registroBd.Ativo = model.Ativo;
                    }
                }
                catch (Exception ex)
                {

                    resultado = "ERRO";
                }

            }


            return Json(new { Resultado = resultado, Mensagens = mensagens, IdSaldo = idSalvo });
        }

        [Authorize]
        public ActionResult MarcaProduto()
        {
            return View();
        }

        [Authorize]
        public ActionResult LocalProduto()
        {
            return View();
        }

        [Authorize]
        public ActionResult UnidadeMedida()
        {
            return View();
        }

        [Authorize]
        public ActionResult Produto()
        {
            return View();
        }

        [Authorize]
        public ActionResult Pais()
        {
            return View();
        }

        [Authorize]
        public ActionResult Estado()
        {
            return View();
        }

        [Authorize]
        public ActionResult Cidade()
        {
            return View();
        }

        [Authorize]
        public ActionResult Fornecedor()
        {
            return View();
        }

        [Authorize]
        public ActionResult PerfilUsuario()
        {
            return View();
        }

        [Authorize]
        public ActionResult Usuario()
        {
            return View();
        }
    }
}