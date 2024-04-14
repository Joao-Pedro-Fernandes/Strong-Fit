using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Strong_Fit.Models;


namespace Strong_Fit.Controllers
{
    public class AcademiaController : Controller
    {
        public Context context;
        public AcademiaController(Context ctx)
        {
            context = ctx;
        }

        public ActionResult ListTreinos()
        {
            return View(context.Treinos.Include(p => p.Aluno));
        }

        public ActionResult ListTreinoAluno(int id)
        {
            Aluno a = context.Alunos.FirstOrDefault(a => a.AlunoId == id);
            return View(context.Treinos.Where(t => t.AlunoId == a.AlunoId));
        }

        public ActionResult CreateTreino()
        {
            ViewBag.AlunoId = new SelectList(context.Alunos.
                OrderBy(a => a.Nome), "AlunoId", "Nome");
            return View();
        }
        [HttpPost]
        public ActionResult CreateTreino(Treino treino)
        {
            Aluno a = context.Alunos.Where(a => a.AlunoId == treino.AlunoId).FirstOrDefault();
            treino.Aluno = a;
            context.Add(treino);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DetailsTreino(int id)
        {
            var treino = context.Treinos
               .Include(a => a.Aluno)
               .FirstOrDefault(t => t.TreinoId == id);
            return View(treino);
        }

        public ActionResult EditTreino(int id)
        {
            Treino treino = context.Treinos.Find(id);
            ViewBag.AlunoId = new SelectList(context.Alunos.OrderBy(a => a.Nome), "AlunoId", "Nome");
            return View(treino);
        }

        [HttpPost]
        public ActionResult EditTreino(Treino treino)
        {
            Aluno a = context.Alunos.Where(a => a.AlunoId == treino.AlunoId).FirstOrDefault();
            treino.Aluno = a;
            treino.AlunoId = a.AlunoId;
            context.Entry(treino).State = EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteTreino(int id)
        {
            Treino treino = context.Treinos.Find(id);
            ViewBag.AlunoId = new SelectList(context.Alunos.OrderBy(a => a.Nome), "AlunoId", "Nome");
            return View(treino);
        }

        [HttpPost]
        public ActionResult DeleteTreino(Treino exercicio)
        {
            context.Remove(exercicio);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ListExercicios()
        {
            return View(context.Exercicios);
        }

        public ActionResult EditExercicio(int id)
        {
            Exercicio exercicio = context.Exercicios.Find(id);
            return View(exercicio);
        }

        [HttpPost]
        public ActionResult EditExercicio(Exercicio exercicio)
        {
            context.Entry(exercicio).State = EntityState.Modified; ;
            context.SaveChanges();
            return RedirectToAction("ListExercicios");
        }

        public ActionResult DetailsExercicio(int id)
        {
            Exercicio exercicio = context.Exercicios.FirstOrDefault(e => e.ExercicioId == id);
            return View(exercicio);
        }

        public ActionResult DeleteExercicio(int id)
        {
            Exercicio exercicio = context.Exercicios.Find(id);
            return View(exercicio);
        }

        [HttpPost]
        public ActionResult DeleteExercicio(Exercicio exercicio)
        {
            context.Remove(exercicio);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ListPersonais()
        {
            return View(context.Personais);
        }

        public ActionResult EditPersonal(int id)
        {
            Personal personal = context.Personais.Find(id);
            return View(personal);
        }

        [HttpPost]
        public ActionResult EditPersonal(Personal personal)
        {
            context.Entry(personal).State = EntityState.Modified; ;
            context.SaveChanges();
            return RedirectToAction("ListPersonais");
        }

        public ActionResult DetailsPersonal(int id)
        {   
            Personal personal = context.Personais.FirstOrDefault(p => p.PersonalId == id);
            return View(personal);
        }

        public ActionResult DeletePersonal(int id)
        {
            Personal personal = context.Personais.Find(id);
            return View(personal);
        }

        [HttpPost]
        public ActionResult DeletePersonal(Personal personal)
        {
            context.Remove(personal);
            context.SaveChanges();
            return RedirectToAction("Index");
        }







        public ActionResult Index()
        {
            return View(context.Alunos.Include(p => p.Personal));
        }

        public ActionResult CreateAluno()
        {
            ViewBag.PersonalId = new SelectList(context.Personais.
                OrderBy(p => p.Nome), "PersonalId", "Nome");
            return View();
        }
        [HttpPost]
        public ActionResult CreateAluno(Aluno aluno)
        {
            Personal p = context.Personais.Where(p => p.PersonalId == aluno.PersonalId).FirstOrDefault();
            aluno.Personal = p;
            context.Add(aluno);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CreatePersonal()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreatePersonal(Personal personal)
        {
            context.Add(personal);
            context.SaveChanges();
            return RedirectToAction("Index");
        }    

        public ActionResult EditAluno(int id)
        {
            Aluno aluno = context.Alunos.Find(id);
            ViewBag.PersonalId = new SelectList(context.Personais.OrderBy(p => p.Nome), "PersonalId", "Nome");
            return View(aluno);
        }

        [HttpPost]
        public ActionResult EditAluno(Aluno aluno)
        {
            Personal p = context.Personais.Where(p => p.PersonalId == aluno.PersonalId).FirstOrDefault();
            aluno.Personal = p;
            aluno.PersonalId = p.PersonalId;
            context.Entry(aluno).State = EntityState.Modified; ;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DetailsAluno(int id)
        {
            var aluno = context.Alunos
               .Include(p => p.Personal)
               .FirstOrDefault(a => a.AlunoId == id);
            return View(aluno);
        }

        public ActionResult DeleteAluno(int id)
        {
            Aluno aluno = context.Alunos.Find(id);
            ViewBag.PersonalId = new SelectList(context.Personais.OrderBy(p => p.Nome), "PersonalId", "Nome");
            return View(aluno);
        }

        [HttpPost]
        public ActionResult DeleteAluno(Aluno aluno)
        {
            context.Remove(aluno);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CreateExercicio()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateExercicio(Exercicio exercicio)
        {
            context.Add(exercicio);
            context.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}
